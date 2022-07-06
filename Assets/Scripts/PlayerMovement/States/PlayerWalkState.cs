using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
   float x=0f;
    public PlayerWalkState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }
    public override void EnterState() 
    {
        Debug.Log("I am walking");
    }
    public override void ExitState() { }

    public override void CheckStates()
    {
        _stateManager.StartCoroutine(Walk());
        x = Mathf.MoveTowards(x, Input.GetAxis("Horizontal"), 1f);
        _stateManager.Anime.SetFloat("Movement", x);
    }

    IEnumerator Walk()
    {
        if (_stateManager.isJumping)
        {
            SwitchState(_factory.Jump());
            _stateManager.isJumping = false;
        }
        if (_stateManager._isAttacking)
        {
            SwitchState(_factory.Attack(_stateManager.states));
        }
       
        yield return null;
    }
}
