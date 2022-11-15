using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using System;
using PlayFab;
using PlayFab.MultiplayerAgent.Model;


public class NetworkButtons : MonoBehaviour {

	private List<ConnectedPlayer> _connectedPlayers;

	//public NetworkManager networkManager;


    private void Awake(){
        //new UnityLogger();
        print("Call Awake");
        Application.targetFrameRate = 30;
		//StartRemoteServer();
        //NetworkManager.Singleton.StartServer();
        string [] args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++){
            if (args[i] == "-server"){
				StartRemoteServer();
                NetworkManager.Singleton.StartServer();
            }
            else if (args[i] == "-client"){
                NetworkManager.Singleton.StartClient();
            }
            else if (args[i] == "-host"){
                NetworkManager.Singleton.StartHost();
            }
        }
        //NetworkManager.Singleton.StartClient();
    }

    private void OnGUI() {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer) {
            if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
            if (GUILayout.Button("Server")){
				StartRemoteServer();
                NetworkManager.Singleton.StartServer();
            } 
            if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
        }

        GUILayout.EndArea();
    }

    private void StartRemoteServer()
	{
		Debug.Log("[ServerStartUp].StartRemoteServer");
		_connectedPlayers = new List<ConnectedPlayer>();
		PlayFabMultiplayerAgentAPI.Start();
		StartCoroutine(ReadyForPlayers());
		//get ip address
		string ip = NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address;
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
}