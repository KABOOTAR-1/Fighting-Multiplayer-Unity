using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour,IHitDetector
{
    [SerializeField]private BoxCollider m_collider;
    [SerializeField] LayerMask m_layermask;
    [SerializeField] private HurtBoxMask m_boxMask=HurtBoxMask.enemy;

    private float m_thickness = 0.5f;
    private IHitResponder m_hitResponder;
    public IHitResponder hitResponder { get => m_hitResponder; set => m_hitResponder= value; }

    public void CheckHit()
    {
        Vector3 scale = new Vector3(
            m_collider.size.x * transform.lossyScale.x,
            m_collider.size.y * transform.lossyScale.y,
            m_collider.size.z*transform.lossyScale.z
        );
        float _distance = scale.y - m_thickness;
        Vector3 direction = transform.up;
        Vector3 centre=transform.TransformPoint(m_collider.center);
        Vector3 start = centre - direction * (_distance / 2);
        Vector3 _halfextends=new Vector3(scale.x/2, m_thickness/2, scale.z/2);
        Quaternion orientation = transform.rotation;

        RaycastHit[] hits=Physics.BoxCastAll(start,_halfextends,direction,orientation,_distance,m_layermask);

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
                    }

                }
            }
        }
    }



}
