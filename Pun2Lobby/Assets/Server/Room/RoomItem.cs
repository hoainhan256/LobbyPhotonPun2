using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class RoomItem : MonoBehaviourPunCallbacks
{
    public TMP_Text RoomName;
    LobbyMananger LobbyMananger;
    private void Start()
    {
      LobbyMananger = FindObjectOfType<LobbyMananger>();
    }
    public void SetRoomName(string _info)
    {
       
        RoomName.text = _info;
    }
    public void OnClick()
    {
        LobbyMananger.JoinRoom(RoomName.text);
    }
}
