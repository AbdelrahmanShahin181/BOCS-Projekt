using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using System;


public class NetworkButtons : MonoBehaviour {
    private void Awake(){
        //new UnityLogger();
        print("Call Awake");
        Application.targetFrameRate = 30;
        string [] args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++){
            if (args[i] == "-server"){
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
            if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
            if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
        }

        GUILayout.EndArea();
    }

    // private void Awake() {
    //     GetComponent<UnityTransport>().SetDebugSimulatorParameters(
    //         packetDelay: 120,
    //         packetJitter: 5,
    //         dropRate: 3);
    // }
}