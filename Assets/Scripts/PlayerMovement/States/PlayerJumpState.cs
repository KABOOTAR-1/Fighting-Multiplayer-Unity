using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState :PlayerBaseState
{
    public PlayerJumpState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }
    public override void EnterState() { }
    public override void ExitState() { }
}
