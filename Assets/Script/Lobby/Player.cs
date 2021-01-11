using System;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public static Player instance = null;
    [SerializeField] private Vector3 movement = new Vector3();
    private NetworkManagerLobby room;
    private NetworkManagerLobby Room
    {
        get
        {
            if (room != null) { return room; }
            return room = NetworkManager.singleton as NetworkManagerLobby;
        }
    }
    
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [Client]
    private void Update()
    {
        if (!hasAuthority) { return; }
        if (!Input.GetKeyDown(KeyCode.Space)) { return; }
        CmdRunServer();
    }

    [Command]
    void CmdRunServer()
    {
        RpcRunClient();
    }

    [ClientRpc]
    void RpcRunClient()
    {
        transform.Translate(movement);
    }

    public override void OnStartAuthority()
    {
        Debug.Log("6-OnStartAuthority");
        if (hasAuthority)
        {
            CmdSetName(Auxiliar.playerName);
        }
    }

    public override void OnStartClient()
    {
        Debug.Log("7-OnStartClient");
    }

    [Command]
    void CmdSetName(string str)
    {
        Room.GamePlayers.Add(str);
        string tmp = "";
        foreach (var name in Room.GamePlayers)
        {
            tmp += name + " ";
        }
        RpcListNames(tmp);
    }

    [ClientRpc]
    void RpcListNames(string str)
    {
        Auxiliar.instance.List(str);
    }

    public override void OnStopAuthority()
    {
        // nunca se ejecuto
        Debug.Log("OnStopAuthority");
    }

    public override void OnStopClient()
    {
        // se ejecuto cuando se cierra el servidor
        Debug.Log("OnStopClient");
    }
}
