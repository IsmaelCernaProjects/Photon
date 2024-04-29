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
        //Conectar al master
        Debug.Log("Conectando");

        //conectar a settings
        PhotonNetwork.ConnectUsingSettings();

        MenuManager.Instance.OpenMenuName("Loading");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectando");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        
        Debug.Log("Conectando Al Lobby");
        MenuManager.Instance.OpenMenuName("Home");
    }

    public void createRoom()
    {
        //Se verifica si el Input esta vacio para evitar errores
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }

        //Se llama a la función crear Room y se le pasa el nombre que se ingresa en el InputText
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        // Se carga loading para el tiempo de carga
        MenuManager.Instance.OpenMenuName("Loading");
    }

    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenuName("Room");
        roomName.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        ErrorMessage.text = "Error al crear sala" + message;
        MenuManager.Instance.OpenMenuName("Error");
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
}
