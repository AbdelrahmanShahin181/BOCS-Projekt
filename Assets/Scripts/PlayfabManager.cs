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
    }
    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
    }
    void OnLoginSuccess(LoginResult result)
    {
        messageText.text = "Login Success";
        // switch scene 
        SceneManager.LoadScene(2);
    }
    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password Reset Success";
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest { CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }
}