using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFireball : MonoBehaviour
{
    GameObject prefabball;  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if(prefabball)
        Call();
    }
    public void InstanatiteFireBall(GameObject FireBallPrefab)
    {
        prefabball=Instantiate(FireBallPrefab, transform.position, Quaternion.identity);
        StartCoroutine(Destroying());
    }

    void Call()
    {
       
            prefabball.transform.Translate(transform.forward * 0.1f);
            
        
    }
    IEnumerator Destroying()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(prefabball);

    }
}
