using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;

    [SerializeField] private Transform player1;
    [SerializeField] private Transform player2;
    void Start()
    {
        PhotonNetwork.Instantiate(Player1.name, player1.position, Quaternion.identity,0);
        PhotonNetwork.Instantiate(Player2.name, player2.position, Quaternion.identity, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
