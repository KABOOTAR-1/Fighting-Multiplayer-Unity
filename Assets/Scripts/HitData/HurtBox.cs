using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour,IHurtBox
{
    [SerializeField] private bool m_Active = true;
    [SerializeField] private GameObject m_owner = null;
    [SerializeField] private HurtboxType m_hurtboxtype = HurtboxType.Enemy;
    private IHurtResponder m_hurtResponder;  

    public bool Active { get=>m_Active;}

    public GameObject owner { get=>m_owner;}

    public Transform Transform { get=>transform;}  

    public IHurtResponder hurtResponder { get => m_hurtResponder; set => m_hurtResponder=value; }

    public HurtboxType Type { get => m_hurtboxtype; }
    public bool Checkhit(HitData hitData)
    {
        if (m_hurtResponder == null)
            Debug.Log("hurtResponder is null");

        return true;
    }

    void Start()
    {
        m_owner = transform.parent.gameObject;
    }

   
}
