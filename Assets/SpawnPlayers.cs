using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private float[] minMaxVals;

    private void Start()
    {
        Vector2 randPos = new Vector2(Random.Range(minMaxVals[0], minMaxVals[1]), Random.Range(minMaxVals[2], minMaxVals[3]));
        PhotonNetwork.Instantiate(playerPrefab.name, randPos, Quaternion.identity);
    }
}
