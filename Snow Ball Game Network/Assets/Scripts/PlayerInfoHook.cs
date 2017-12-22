using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using  Prototype.NetworkLobby;

public class PlayerInfoHook :LobbyHook 
{
	public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer) 
	{ 
		LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer> ();
		PlayerInfo playerInf = gamePlayer.GetComponent<PlayerInfo> ();

		playerInf.name = lobby.playerName;
		playerInf.color = lobby.playerColor;
	}
}
