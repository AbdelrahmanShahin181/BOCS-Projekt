using UnityEngine;
using System;
using Photon.Chat;
using Photon.Pun;
using ExitGames.Client.Photon;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using Unity.Netcode;

namespace KnoxGameStudios
{
    public class PhotonChatController : MonoBehaviour, IChatClientListener
    {
        [SerializeField] private string nickName;
        private ChatClient chatClient;

        //public static Action<string, string> OnRoomInvite = delegate { };
        public static Action<ChatClient> OnChatConnected = delegate { };
        public static Action<PhotonStatus> OnStatusUpdated = delegate { };

        #region Unity Methods

        private void Awake()
        {
            //nickName = PlayerPrefs.GetString("USERNAME");
            GetPlayerData();
            Debug.Log("nickname: " + nickName);
        }

        private void Start()
        {
            chatClient = new ChatClient(this);
            ConnectoToPhotonChat();
        }

        private void Update()
        {
            chatClient.Service();
        }

        #endregion

        #region  Private Methods

        private void ConnectoToPhotonChat()
        {
            Debug.Log("Connecting to Photon Chat");
            chatClient.AuthValues = new AuthenticationValues(nickName);
            chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new Photon.Chat.AuthenticationValues(nickName));
        }
        public void SendChatMessage(string recipient)
        {
            string message = "Marhaba";
            Debug.Log($"Sending Chat Message {message} to {recipient}");
            chatClient.SendPrivateMessage(recipient, message);
        }
        public void PublischChatMessage(string kanal)
        {
            string message = "Marhaba";
            Debug.Log($"Sending Chat Message {message} to {kanal}");
            chatClient.PublishMessage(kanal, message);
        }

        public void GetPlayerData()
        {
            Debug.Log("Getting Player Data");
            try
            {
                GetUserDataRequest request = new GetUserDataRequest();
                PlayFabClientAPI.GetUserData(request, 
                result => {
                    if(result.Data == null || !result.Data.ContainsKey("name") || !result.Data.ContainsKey("age") || !result.Data.ContainsKey("color"))
                    {
                        nickName = "Guest";
                    }else{
                        nickName = result.Data["name"].Value;
                    }
                    Debug.Log("NickName is: " + nickName);
                }, 
                error => {
                    Debug.Log("Got error retrieving user data:"); 
                });
            }
            catch (System.Exception)
            {
                nickName = "Guest";
                Debug.Log("NickName is: " + nickName + "You are not logged in ");
            }
        }
        #endregion

        #region Photon Chat Callbacks

        public void DebugReturn(DebugLevel level, string message)
        {
            Debug.Log($"Photon Chat DebugReturn: {message}");
        }

        public void OnDisconnected()
        {
            Debug.Log("You have disconnected from the Photon Chat");
            chatClient.SetOnlineStatus(ChatUserStatus.Offline);
        }

        public void OnConnected()
        {
            Debug.Log("You have connected to the Photon Chat");
            OnChatConnected?.Invoke(chatClient);
            chatClient.SetOnlineStatus(ChatUserStatus.Online);
            chatClient.Subscribe(new string[] { "channelA" });
        }

        public void OnChatStateChange(ChatState state)
        {
            Debug.Log($"Photon Chat OnChatStateChange: {state.ToString()}");
        }

        public void OnGetMessages(string channelName, string[] senders, object[] messages)
        {
            Debug.Log($"Photon Chat OnGetMessages from {nickName} in {channelName}");
            for (int i = 0; i < senders.Length; i++)
            {
                Debug.Log($"{senders[i]} messaged: {messages[i]}");
            }
        }

        public void OnPrivateMessage(string sender, object message, string channelName)
        {
            Debug.Log($"Photon Chat OnPrivateMessage {channelName}");
            if (!string.IsNullOrEmpty(message.ToString()))
            {
                // Channel Name format [Sender : Recipient]
                string[] splitNames = channelName.Split(new char[] { ':' });
                string senderName = splitNames[0];

                if (!sender.Equals(senderName, StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Log($"{sender}: {message}");
                    //OnRoomInvite?.Invoke(sender, message.ToString());
                }
            }
        }

        public void OnSubscribed(string[] channels, bool[] results)
        {
            Debug.Log($"Photon Chat OnSubscribed");
            for (int i = 0; i < channels.Length; i++)
            {
                Debug.Log($"{channels[i]}");
            }
        }

        public void OnUnsubscribed(string[] channels)
        {
            Debug.Log($"Photon Chat OnUnsubscribed");
            for (int i = 0; i < channels.Length; i++)
            {
                Debug.Log($"{channels[i]}");
            }
        }

        public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
        {
            Debug.Log($"Photon Chat OnStatusUpdate: {user} changed to {status}: {message}");
            PhotonStatus newStatus = new PhotonStatus(user, status, (string)message);
            Debug.Log($"Status Update for {user} and its now {status}.");
            OnStatusUpdated?.Invoke(newStatus);
        }

        public void OnUserSubscribed(string channel, string user)
        {
            Debug.Log($"Photon Chat OnUserSubscribed: {channel} {user}");
        }

        public void OnUserUnsubscribed(string channel, string user)
        {
            Debug.Log($"Photon Chat OnUserUnsubscribed: {channel} {user}");
        }

        private void OnDestroy()
        {
            Debug.Log("Disconnecting from Photon Chat");
        }
        #endregion
    }
}