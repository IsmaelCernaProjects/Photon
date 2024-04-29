using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;




public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text roomName;
    [SerializeField] TMP_Text ErrorMessage;
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
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenuName("Loading");
    }
    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenuName("Home");
    }
    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenuName("Room");
        roomName.text = PhotonNetwork.CurrentRoom.Name;
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        ErrorMessage.text = "Error al crear la sala" + message;
        MenuManager.Instance.OpenMenuName("Error");
    }

        public void CreateRoom()
{
    // si presionamos el boton y este esta vacio no procedera
    if (string.IsNullOrEmpty(roomNameInputField.text))
    {
        return;
    }
    // Llamamos la Funcion CreateRoom de photon para enviarle el nombre
PhotonNetwork.CreateRoom(roomNameInputField.text);
        //Abrimos Loading Menu para cargar
        MenuManager.Instance.OpenMenuName("Loading");
}
}

