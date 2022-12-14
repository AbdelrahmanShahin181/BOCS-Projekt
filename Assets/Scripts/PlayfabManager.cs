using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayfabManager : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField usernameInput;
    public TMP_InputField ageInput;

    
    public GameObject spritegameobject;
    SpriteRenderer spriteRenderer;
    public int playerID;

    public void Registerbutton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "Password must be at least 6 characters";
            return;
        }
        var request = new RegisterPlayFabUserRequest { 
            Email = emailInput.text, 
            Password = passwordInput.text, 
            RequireBothUsernameAndEmail = false 
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    
    public void Loginbutton()
    {
        var request = new LoginWithEmailAddressRequest { Email = emailInput.text, Password = passwordInput.text };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    
    public void ResetPasswordbutton()
    {
        var request = new SendAccountRecoveryEmailRequest { Email = emailInput.text, TitleId = PlayFabSettings.TitleId };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }
    
   
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Register Success";
        SceneManager.LoadScene(4);
    }
    
    void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Login Success";
        
        // switch scene
        GetPlayerData();
        //usernameInput.text = userData["username"];
         SceneManager.LoadScene(2);

    }
    void OnUserDataSuccess(GetUserDataResult result)
    {
        messageText.text = "User Data Success";
    }
    
    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password Reset Success";
    }

        void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest { CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true};
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }
   
   public void SetUserData() {
    PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest() {
        Data = new Dictionary<string, string>() {
            {"username",usernameInput.text },
            {"age",ageInput.text },
            {"playerID",playerID.ToString() }
        }
    }, 
    result => Debug.Log("Successfully updated user data"),
    error => {
        Debug.Log("Got error setting user data Ancestor to Arthur");
        Debug.Log(error.GenerateErrorReport());
    });
    SceneManager.LoadScene(2);
    }

    public void SetPlayerID(int playerID) {
        this.playerID = playerID;
    }

    public void UserDataScuccess(GetUserDataResult result)
    {
        if(result.Data == null || !result.Data.ContainsKey("username"))
        {
            Debug.Log("No data found");
            SceneManager.LoadScene(4);
        }else{
            SceneManager.LoadScene(2);
        }
    }


    public void GetPlayerData()
    {
        GetUserDataRequest request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, 
        result => {

            if(result.Data == null || !result.Data.ContainsKey("username"))
            {
                Debug.Log("No data found");
                SceneManager.LoadScene(4);
            }else{
                SceneManager.LoadScene(2);
            }
        }, 
        error => {
            Debug.Log("Got error retrieving user data:");
            Debug.Log(error.GenerateErrorReport());
            
        });

        
    }


    // color zu String umwandeln
    private string DecToHex(int value)
    {
        return value.ToString("X2");
    }
}

