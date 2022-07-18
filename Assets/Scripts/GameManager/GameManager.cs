using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject[] Player = new GameObject[2];
    public int x = 0;
    public Transform[] pos=new Transform[2];
   

    private void Awake()
    {
      
        
    }
    void Start()
    {
        PhotonNetwork.Instantiate(Player[PhotonNetwork.LocalPlayer.ActorNumber - 1].name, pos[PhotonNetwork.LocalPlayer.ActorNumber - 1].position, Player[PhotonNetwork.LocalPlayer.ActorNumber - 1].transform.rotation, 0);

    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
