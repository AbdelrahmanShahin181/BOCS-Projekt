using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using System;
using PlayFab;
using PlayFab.MultiplayerAgent.Model;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;


public class NetworkButtons : MonoBehaviour {

	private List<ConnectedPlayer> _connectedPlayers;
    int playerID = 0;
    public GameObject [] playerPrefabs;
    public string portString = "7777";
    public string ip = "127.0.0.1";

    private void Awake(){
        GetPlayerData();
    }

    private void OnGUI() {
        
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer) {
            /*GUILayout.BeginArea(new Rect(320, 10, 300, 300));
                GUILayout.Label("IP:");
                ip = GUILayout.TextField(ip);
                GUILayout.Label("Port:");
                portString = GUILayout.TextField(portString);
            GUILayout.EndArea();*/
            GUILayout.BeginArea(new Rect(10, 10, 300, 300));
                if (GUILayout.Button("Host")){
                    //NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address = ip;
                    //NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Port = Convert.ToUInt16(portString);
                    NetworkManager.Singleton.StartHost();
                } 
                if (GUILayout.Button("Server")){
                    //NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address = ip;
                    //NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Port = Convert.ToUInt16(portString);
                    StartRemoteServer();
                    NetworkManager.Singleton.StartServer();
                } 
                if (GUILayout.Button("Client")){ 
                    //NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address = ip;
                    //NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Port = Convert.ToUInt16(portString);
                    NetworkManager.Singleton.StartClient();
                    
                }
            GUILayout.EndArea();
        }
        
        NetworkManager.Singleton.NetworkConfig.PlayerPrefab = playerPrefabs[playerID];
        //playerPrefabs[playerID].SetActive(true);
    }

    private void StartRemoteServer()
	{
		Debug.Log("[ServerStartUp].StartRemoteServer");
		_connectedPlayers = new List<ConnectedPlayer>();
		PlayFabMultiplayerAgentAPI.Start();
		StartCoroutine(ReadyForPlayers());
		//get ip address
		ip = NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address;
		print("IP Adresse ist : " + ip);
		ushort port = NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Port;
		print("Port ist : " + port);
		Debug.Log("Server started");
		Debug.Log("IP Adresse ist : " + ip);
		Debug.Log("Port ist : " + port);


	}

	IEnumerator ReadyForPlayers()
	{
		yield return new WaitForSeconds(.5f);
		PlayFabMultiplayerAgentAPI.ReadyForPlayers();
	}

	private void OnAgentError(string error)
	{
		Debug.Log(error);
	}


    // private void Awake() {
    //     GetComponent<UnityTransport>().SetDebugSimulatorParameters(
    //         packetDelay: 120,
    //         packetJitter: 5,
    //         dropRate: 3);
    // }


 public void GetPlayerData()
        {
            Debug.Log("Getting Player Data");
            try
            {
                GetUserDataRequest request = new GetUserDataRequest();
                PlayFabClientAPI.GetUserData(
                    request, 
                    result => {
                        if(result.Data == null || !result.Data.ContainsKey("playerID"))
                        {
                            Debug.Log("No data found");
                            playerID = 0;
                        }else{
                            playerID = int.Parse(result.Data["playerID"].Value);
                        }
                        Debug.Log("playerID: " + playerID);
                    },
                    error => {
                        Debug.Log("Got error retrieving user data:"); 
                    }
                );
            }
            catch (System.Exception)
            {
                playerID = 0;
                Debug.Log("cought playerID: " + playerID);
            }
        }
}