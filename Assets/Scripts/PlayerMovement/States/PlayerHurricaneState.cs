using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurricaneState : PlayerBaseState
{
    public PlayerHurricaneState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }

    public override void EnterState()
    {
        Debug.Log("In HUrricane");
    }
    public override void ExitState() { }

    public override void CheckStates()
    {          
        _stateManager.Anime.SetTrigger("Hurricane Kick");
        SwitchState(_factory.Walk());
    }

}
