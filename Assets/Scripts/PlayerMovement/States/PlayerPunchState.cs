using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunchState : PlayerBaseState
{
    // Start is called before the first frame update
    public PlayerPunchState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }

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
