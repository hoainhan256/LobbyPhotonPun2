using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ConnecToServer : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField UserNameInput;
    [SerializeField] TMP_Text buttonText;
    void Start()
    {
        
    }
    public void OnClickConnect()
    {
        if(UserNameInput.text.Length >1)
        {
            PhotonNetwork.NickName = UserNameInput.text;
            buttonText.text = "Connecting...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Application.LoadLevel("Lobby");

    }
    
}
