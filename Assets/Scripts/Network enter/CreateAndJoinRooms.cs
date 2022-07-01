using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TMP_InputField CreateInput,JoinInput;
     
  public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(CreateInput.text, new Photon.Realtime.RoomOptions() { MaxPlayers = 2 }, Photon.Realtime.TypedLobby.Default);

    }

    public void JoinRoom()
    {
        Photon.Realtime.RoomOptions roomoptions = new Photon.Realtime.RoomOptions();
        roomoptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(JoinInput.text, roomoptions, Photon.Realtime.TypedLobby.Default);

    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
