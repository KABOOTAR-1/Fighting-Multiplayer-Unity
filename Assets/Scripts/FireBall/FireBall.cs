using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform != null)
        {
            transform.Translate(transform.right * 0.06f);
            StartCoroutine(Destroying());
        }


    }

    IEnumerator Destroying()
    {
       yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
       
    }
}
