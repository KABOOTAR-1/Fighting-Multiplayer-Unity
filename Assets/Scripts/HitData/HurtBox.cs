using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class HurtBox : MonoBehaviour,IHurtBox
{
    [SerializeField] private bool m_Active = true;
    [SerializeField] private GameObject m_owner = null;
    [SerializeField] private HurtboxType m_hurtboxtype;
    private PhotonView view;
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
    void Awake()
    {
        view = GetComponentInParent<PhotonView>();
    }

    void Start()
    {
        m_owner = transform.parent.gameObject;

        if (view.IsMine)
            m_hurtboxtype = HurtboxType.Player;
        else
            m_hurtboxtype = HurtboxType.Enemy;
    }

   
}
