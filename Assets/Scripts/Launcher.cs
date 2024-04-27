using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Launcher : MonoBehaviourPunCallbacks
{
    void Start()
    {
        // conectar al master
        Debug.Log("Conectando");
        //MenuManager.Instance.OpenMenuName("Loading"); (paso 60)
        PhotonNetwork.ConnectUsingSettings();
        MenuManager.Instance.OpenMenuName("Loading");
    }
    public override void OnConnectedToMaster()
    {
        //borran la siguiente linea es el comportamiento base del metodo
        // base.OnConnectedToMaster();
        Debug.Log("Conectado");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        //borran la base
        // base.OnJoinedLobby();
        //MenuManager.Instance.OpenMenuName("Home"); (paso 61)
        Debug.Log("Conectado al lobby ");
        MenuManager.Instance.OpenMenuName("Home");
    }
}