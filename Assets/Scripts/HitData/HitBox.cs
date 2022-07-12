using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour,IHitDetector
{
    [SerializeField]private BoxCollider m_collider;
    [SerializeField] LayerMask m_layermask;
    [SerializeField] public HurtBoxMask m_boxMask=HurtBoxMask.enemy;
    public RaycastHit[] hits;
    private float m_thickness = 0.5f;
    public IHitResponder m_hitResponder;
    IHurtBox own;
    Vector3 _halfextends;
    public Vector3 centre;
    [SerializeField] HitResponder res;
    public IHitResponder hitResponder { get => m_hitResponder; set => m_hitResponder= value; }

    void Start()
    {
        m_collider = GetComponent<BoxCollider>();
        m_layermask = LayerMask.GetMask("HurtBox");
        own=transform.parent.GetComponentInChildren<IHurtBox>();    
        res=transform.GetComponent<HitResponder>();
    }

    void Update()
    {

       
    }
    public void CheckHit()
    {
        Vector3 scale = new Vector3(
           m_collider.size.x * transform.lossyScale.x,
           m_collider.size.y * transform.lossyScale.y,
           m_collider.size.z * transform.lossyScale.z
       );
        float _distance = scale.y - m_thickness;
        Vector3 direction = transform.up;
         centre= transform.TransformPoint(m_collider.center);
        Vector3 start = centre - direction * (_distance / 2);
        _halfextends = new Vector3(scale.x / 2 - 0.01f, scale.y / 2 - 0.01f, scale.z / 2 - 0.01f);
        Quaternion orientation = transform.rotation;

        hits = Physics.BoxCastAll(start, _halfextends, direction, orientation, 0.4f, m_layermask);
       centre = transform.TransformPoint(m_collider.center);

        HitData hitdata = null;
        IHurtBox _hurtbox = null;

        foreach(var ray in hits)
        {
            _hurtbox=ray.collider.GetComponent<IHurtBox>();
            if (_hurtbox != null)
            {
                if (_hurtbox.Active)
                    if(m_boxMask.HasFlag((HurtBoxMask)_hurtbox.Type))
                {
                    hitdata = new HitData
                    {
                        damage = m_hitResponder == null ? 0 : m_hitResponder.Damage,
                        hitpoint = ray.point == Vector3.zero ? centre : ray.point,
                        hitnormal = ray.normal,
                        hurtbox = _hurtbox,
                        hitDetector = this,
                    };

                    if (hitdata.Validate())
                    {
                        hitdata.hitDetector.hitResponder?.Response(hitdata);
                        hitdata.hurtbox.hurtResponder?.Response(hitdata);
                        hits = null;
                        res.m_attack = false;
                        res.enabled = false;
                    }

                }
            }
        }
       
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (hits!=null)
        {
            //Draw a Ray forward from GameObject toward the hit
            //Gizmos.DrawRay(transform.position, transform.lossyScale);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube (transform.TransformPoint (m_collider.center),new Vector3(_halfextends.x*2,_halfextends.y*2,_halfextends.z*2) );
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.lossyScale);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.TransformPoint(m_collider.center),new Vector3(_halfextends.x * 2, _halfextends.y * 2, _halfextends.z * 2));
        }
    }

}
