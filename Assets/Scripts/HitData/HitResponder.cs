using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitResponder : MonoBehaviour,IHitResponder
{
    [SerializeField] private bool m_attack;
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

    // Start is called before the first frame update
    void Start()
    {
        m_box.hitResponder = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_attack)
        {
            m_box.CheckHit();
        }
    }
}
