using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtResponder : MonoBehaviour,IHurtResponder
{
    private List<HurtBox> m_hurtbox= new List<HurtBox>();
    public bool Checkhit(HitData hitData)
    {
       return true; 
    }

    public void Response(HitData hitData)
    {
        Debug.Log("Hurt Response");
    }

    private void Start()
    {
        m_hurtbox=new List<HurtBox>(GetComponentsInChildren<HurtBox>());
        
        foreach (HurtBox box in m_hurtbox)
            box.hurtResponder = this;
    }
}
