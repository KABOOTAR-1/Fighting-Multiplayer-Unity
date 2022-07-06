using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attacked
{
    Idle,
    Punch,
    Kick,
    HurricaneKick,
    Fireball
}
public class PlayerAttackState : PlayerBaseState
{
    // Start is called before the first frame update
    Attacked state;
    public PlayerAttackState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory,Attacked _state) : base(currentContext, playerStateFactory) {
    state = _state;
    }

    public override void EnterState()
    {
        Debug.Log("Attack");
        if (state == Attacked.Kick)
            SwitchState(_factory.Kick());
        if(state == Attacked.Punch)
            SwitchState(_factory.Punch());
        if (state == Attacked.HurricaneKick)
            SwitchState(_factory.HurricaneKick());
        if (state == Attacked.Fireball)
            SwitchState(_factory.FireBall());

        state = Attacked.Idle;
        _stateManager._isAttacking = false;
    }
    public override void ExitState() { }

    public override void CheckStates()
    {
        if (state == Attacked.Idle)
            SwitchState(_factory.Walk());
    }
}
    


