using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsConnectedRoom : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    public override void OnJoinedRoom()
    {
        
            // Tạo người chơi local trong phòng.
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(Random.Range(0,10), 1, Random.Range(0, 10)), Quaternion.identity);
        
    }
}
