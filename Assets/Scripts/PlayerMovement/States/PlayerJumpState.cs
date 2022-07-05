using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState :PlayerBaseState
{
    public PlayerJumpState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }
    public override void EnterState() {
        Debug.Log("I am Jumping");
        _stateManager.StartCoroutine(ExecuteJump());

    }
    public override void ExitState() {
    

    }
    public override void CheckStates() 
    {
       

    }

    IEnumerator ExecuteJump()
    {
        _stateManager.Anime.SetTrigger("Jumping");
        yield return new WaitForSeconds(_stateManager.Anime.GetCurrentAnimatorClipInfo(0).Length);
        _stateManager._isJumping = false;
        SwitchState(_factory.Walk());
        yield return null;
    }

}
