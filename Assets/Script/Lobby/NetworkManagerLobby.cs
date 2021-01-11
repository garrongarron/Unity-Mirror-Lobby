using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManagerLobby : NetworkManager
{
    public List<string> GamePlayers { get; } = new List<string>();

    public override void OnStartServer()
    {
        Debug.Log("1-OnStartServer");
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        Debug.Log("2-OnServerConnect");
    }

    public override void OnStartClient()
    {
        Debug.Log("3-OnStartClient");
    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);
        Debug.Log("4-OnServerAddPlayer");
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        Debug.Log("5-OnClientConnect");
    }
}