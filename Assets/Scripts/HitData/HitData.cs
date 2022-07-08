using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitData
{
    public int damage;
    public Vector3 hitpoint;
    public Vector3 hitnormal;
    public IHurtBox hurtbox;
    public IHitDetector hitDetector;

    public bool Validate()
    {
        if (hurtbox != null)
        {
            if (hurtbox.Checkhit(this))
            {
                if (hurtbox.hurtResponder == null || hurtbox.hurtResponder.Checkhit(this))
                {
                    if (hitDetector == null|| hitDetector.hitResponder.Checkhit(this)){
                        return true;
                    }
                }
            }
        }
        return false;
    }
   
}

public enum HurtboxType
{
    Player=1<<0,
    Enemy=1<<1,
    Ally=1<<2    
}

[System.Flags]
public enum HurtBoxMask
{
    none=0,
    player=1<<0,
    enemy=1<<1,
    ally=1<<2
}

public interface IHitResponder
{
    int Damage { get; }
    public bool Checkhit(HitData hitData);
    public void Response (HitData hitData);
}

public interface IHitDetector
{
    public IHitResponder hitResponder { get; set; }
    public void CheckHit();  
}

public interface IHurtResponder
{
    public bool Checkhit(HitData hitData);
    public void Response(HitData hitData);
}

public interface IHurtBox
{
    public bool Active { get; }
    public GameObject owner { get;  }
    public Transform Transform { get; }
    public HurtboxType Type { get; }
    public IHurtResponder hurtResponder { get; set; }
    public bool Checkhit(HitData hitData);

}