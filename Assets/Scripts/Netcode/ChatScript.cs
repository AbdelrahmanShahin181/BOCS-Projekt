using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;



public class ChatScript : NetworkBehaviour
{
    [SerializeField] private ChatMessage chatMessagePrefab;
    [SerializeField] private Transform messageParent;
    [SerializeField] private TMP_InputField chatInputField;
    private Button sendButton;
    private const int MaxNumberOfMessagesInList = 20;
    private List<ChatMessage> _messages;

    private const float MinIntervalBetweenChatMessages = 1f;
    private float _clientSendTimer;
    
    //private readonly ProfanityFilter.ProfanityFilter _profanityFilter = new ();

    private void Start() {
        _messages = new List<ChatMessage>();
        sendButton = chatInputField.GetComponentInChildren<Button>();
    }

    private void Update() {
        _clientSendTimer += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Return)) {
            SendMessage(); 
        }
    }

    public void SendMessage() {
        string message = "Hallo Ich bin Abdo ";
        
        if (string.IsNullOrWhiteSpace(message)) {
            return;
        }

        _clientSendTimer = 0;
        SendChatMessageServerRpc(message, NetworkManager.Singleton.LocalClientId);
    }

    private void AddMessage(string message, ulong senderPlayerId) {
        var msg = Instantiate(chatMessagePrefab, messageParent);
        //message = _profanityFilter.CensorString(message);
        //msg.SetMessage(LobbyOrchestrator.PlayersInLobby[senderPlayerId].playerName, message);
        
        _messages.Add(msg);

        if (_messages.Count > MaxNumberOfMessagesInList) {
            Destroy(_messages[0]);
            _messages.RemoveAt(0);
        }
    }

    [ClientRpc]
    private void ReceiveChatMessageClientRpc(string message, ulong senderPlayerId) {
        //AddMessage(message, senderPlayerId);
        Debug.Log("ReceiveChatMessageServerRpc");
    }
    
    [ServerRpc(RequireOwnership = false)]
    private void SendChatMessageServerRpc(string message, ulong senderPlayerId) {
        Debug.Log("SendChatMessageServerRpc");
        ReceiveChatMessageClientRpc(message, senderPlayerId);
    }
}
