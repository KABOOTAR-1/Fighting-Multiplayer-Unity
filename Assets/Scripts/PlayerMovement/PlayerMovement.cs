using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anime;
    public float x;
    void Start()
    {
        anime = GetComponent<Animator>();
       x= anime.GetFloat("Movement");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            anime.SetLayerWeight(1, 1);
        }
    }
}
