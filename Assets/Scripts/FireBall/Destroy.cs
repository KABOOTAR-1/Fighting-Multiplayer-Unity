using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] LayerMask layer1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.layer==LayerMask.NameToLayer("HurtBox"))
            Debug.Log(other.name);
        //Destroy(gameObject);
    }
}
