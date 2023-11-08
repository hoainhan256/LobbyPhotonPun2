using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LobbyMananger : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField RoomNameInput;
    [SerializeField] GameObject LobbyPannel;
    [SerializeField] GameObject RoomPannel;
    [SerializeField] TMP_Text RoomNameText;
    public RoomItem RoomItemPrefab;
    [SerializeField] List<RoomItem> RoomItemsList = new List<RoomItem>();
    public Transform contentObject;
    private void Start()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    public void OnClickCreate()
    {
        if (RoomNameInput.text.Length > 2)
        {
            PhotonNetwork.CreateRoom(RoomNameInput.text, new RoomOptions()
            {
                MaxPlayers = 3
                
            }
            
            );Application.LoadLevel("GamePlay");
        }

    }
    public override void OnJoinedRoom()
    {
        LobbyPannel.SetActive( false );
        RoomPannel.SetActive( true );
        RoomNameText.text = PhotonNetwork.CurrentRoom.Name;
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
        
    }
    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach(RoomItem item in RoomItemsList)
        {
            Destroy(item.gameObject);
        }
        RoomItemsList.Clear();
        foreach(RoomInfo room in list)
        {
          RoomItem newRoom =  Instantiate(RoomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            RoomItemsList.Add(newRoom);
            
        }
       
    }
    public void JoinRoom(string Roomname)
    {
        PhotonNetwork.JoinRoom(Roomname);
        
        
    }
    private void Update()
    {
       
    }
}
