using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

//Written by Ben
//Used to initialize game objects that are local to the client's game

public class OnlineGameManager : MonoBehaviourPunCallbacks
{
	public GameObject playerPrefab;
	
	//Checks if the playerPrefab is set, and creates an instance of it on the network if it is
	void Start()
		{
			if (playerPrefab == null)
			{
				Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'",this);
			}
			else
			{
				if (OnlinePlayerMovement.LocalPlayerInstance == null)
				{
					Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
					PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
				}
				else
				{
					Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
				}
			}
		}
	
	//If the player is the master client, loads the online scene
	void LoadArena()
	{
		if (!PhotonNetwork.IsMasterClient)
		{
			Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
			return;
		}
		Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
		PhotonNetwork.LoadLevel("FarmSimOnline");
	}
	
	//Used when the player leaves the lobby. Resets the time to 1, since it may be called from a pause menu.
	public void LeaveRoom()
    {
        Time.timeScale = 1f;
        PhotonNetwork.LeaveRoom();
    }
	
	//Called when the player has left the multiplayer lobby. Resets the scene to the main menu.
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
	
	//When a player enters the lobby, shows the other player in the lobby. If the first player in, loads the scene. 
	public override void OnPlayerEnteredRoom(Player other)
	{
		Debug.LogFormat("OnPlayerEnteredRoom() {0}", other.NickName);  // not seen if you're the player connecting
		if (PhotonNetwork.IsMasterClient)
		{
			Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom
			LoadArena();
		}
	}
	
	//When a player leaves the lobby, shows who left. If the first player in leaves, reloads the area with the remaining power.
	public override void OnPlayerLeftRoom(Player other)
	{
		Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); // seen when other disconnects
		if (PhotonNetwork.IsMasterClient)
		{
			Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom
			LoadArena();
		}
	}
}
