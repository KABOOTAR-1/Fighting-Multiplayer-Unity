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
        CommandManager.ICommand command = new ExecuteJumping(_stateManager.Anime);
        CommandManager.Instance.AddCommand(command);
        SwitchState(_factory.Walk());
        
    }

    


}
