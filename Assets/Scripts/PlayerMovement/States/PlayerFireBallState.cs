using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireBallState : PlayerBaseState
{
    // Start is called before the first frame update
    public PlayerFireBallState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }

    public override void EnterState()
    {
        Debug.Log("FireBall");
        _stateManager.StartCoroutine(ExecuteFireBall());
    }
    public override void ExitState() { }

    public override void CheckStates()
    { 
    }

    IEnumerator ExecuteFireBall()
    {
        _stateManager.Anime.SetTrigger("Fireball");
        yield return new WaitForSeconds(_stateManager.Anime.GetCurrentAnimatorClipInfo(0).Length);      
        _stateManager.Anime.ResetTrigger("Fireball");
        SwitchState(_factory.Walk());
        yield return null;
    }
}
