using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitResponder : MonoBehaviour,IHitResponder
{
    public bool m_attack=false;
    
    [SerializeField] private int m_damage = 10;
    [SerializeField] private HitBox m_box;
   
    public int Damage { get => m_damage; } 

    public bool Checkhit(HitData hitData)
    {
        return true;
    }

    public void Response(HitData hitData)
    {
 
    }
    void Start()
    {
        m_box = GetComponent<HitBox>();
        m_attack = false;
        m_box.hitResponder = this;
       enabled = false;
       
    }
    void Update()
    {
        if (m_attack)
        {
            m_box.CheckHit();
            
        }
    }


}
