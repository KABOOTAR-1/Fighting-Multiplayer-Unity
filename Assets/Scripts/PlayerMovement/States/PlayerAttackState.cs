using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Attack
{
    Punch,
    Kick,
    HurricaneKick,
    Fireball
}
public class PlayerAttackState : PlayerBaseState
{
    // Start is called before the first frame update
    public PlayerAttackState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }

    public override void EnterState()
    {
        Debug.Log("Attack");
    }
    public override void ExitState() { }

    public override void CheckStates()
    {
        SwitchState(_factory.Walk());
    }
}
    // Start is called before the first frame update


