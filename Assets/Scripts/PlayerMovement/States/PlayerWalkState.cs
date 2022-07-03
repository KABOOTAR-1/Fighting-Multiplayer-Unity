using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    float x = 0;
    public PlayerWalkState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }
    public override void EnterState() {
        Debug.Log("I am walking");
       
    }
    public override void ExitState() { }

    public override void CheckStates()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SwitchState(_factory.Jump());
            return;
        }
        x = Mathf.MoveTowards(x, Input.GetAxis("Horizontal") , 1f);
        _stateManager.Anime.SetFloat("Movement", x);
    }
}
