using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Incresaex : MonoBehaviour
{
    [SerializeField]
    public static int x=0;
    PhotonView view;
    void Start()
    {
        view = GetComponent<PhotonView>();
        view.RPC("Increase", RpcTarget.Others);
    }

    [PunRPC]
    void Increase()
    {
        x++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
