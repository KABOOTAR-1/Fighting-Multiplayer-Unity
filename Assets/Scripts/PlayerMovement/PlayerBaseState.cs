using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState 
{
    protected PlayerStateManager _stateManager;
    protected PlayerStateFactory _factory;

    public PlayerBaseState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) {
        _stateManager = currentContext;
        _factory = playerStateFactory;
    }

    public abstract void EnterState();
    public abstract void ExitState();

    public abstract void CheckStates();
    void UpdateStates() { }
   protected void SwitchState(PlayerBaseState newState) {
        ExitState();
        newState.EnterState();
        _stateManager.currentState = newState;
    }
    protected void SetSuperState() { }
    void SetSubState() { }
    
}
