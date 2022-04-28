using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI createText;

    [SerializeField]
    private TextMeshProUGUI joinText;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createText.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinText.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel ("DevScene00");
    }
}
