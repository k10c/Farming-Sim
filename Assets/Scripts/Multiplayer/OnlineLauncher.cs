using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OnlineLauncher : MonoBehaviourPunCallbacks
{
	[SerializeField] private byte maxPlayers = 2;
	bool isConnecting;
	string gameVersion = "1";
	
	void Awake()
	{
		PhotonNetwork.AutomaticallySyncScene = true;
	}
	
	void Start()
	{
		
	}
	
	public void Connect()
	{
		if (PhotonNetwork.IsConnected)
		{
			PhotonNetwork.JoinRandomRoom();
		}
		else
		{
			isConnecting = PhotonNetwork.ConnectUsingSettings();
			PhotonNetwork.GameVersion = gameVersion;
		}
	}
	
	public override void OnConnectedToMaster()
	{
		Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
		if (isConnecting)
		{
			PhotonNetwork.JoinRandomRoom();
			isConnecting = false;
		}
	}
	
	public override void OnDisconnected(DisconnectCause cause)
	{
		isConnecting = false;
		Debug.LogWarningFormat("Disconnected with reason {0}", cause);
	}
	
	public override void OnJoinRandomFailed(short returnCode, string message)
	{
		Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");
		PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayers });
	}
	
	public override void OnJoinedRoom()
	{
		Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
		if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
			{
				Debug.Log("Loading 'FarmSimOnline' ");

				// #Critical
				// Load the Room Level.
				PhotonNetwork.LoadLevel("FarmSimOnline");
			}
	}
}
