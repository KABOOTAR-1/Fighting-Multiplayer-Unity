using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKickState : PlayerBaseState
{
    // Start is called before the first frame update
    public PlayerKickState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }

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
