using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState :PlayerBaseState
{
    public PlayerJumpState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }
    public override void EnterState() {
        Debug.Log("I am Jumping");
    }
    public override void ExitState() {
    

    }
    public override void CheckStates() {
        _stateManager.Anime.SetTrigger("Jumping");
        _stateManager.Move();
        SwitchState(_factory.Walk());
        
    }
}
