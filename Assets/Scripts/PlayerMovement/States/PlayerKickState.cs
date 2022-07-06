using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKickState : PlayerBaseState
{
    // Start is called before the first frame update
    public PlayerKickState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }

    public override void EnterState()
    {
        Debug.Log("Kicking");
        _stateManager.StartCoroutine(ExecuteKick());
    }
    public override void ExitState() { }

    public override void CheckStates()
    {
       
    }

    IEnumerator ExecuteKick()
    {
        _stateManager.Anime.SetTrigger("Kicking");
        yield return new WaitForSeconds(_stateManager.Anime.GetCurrentAnimatorClipInfo(0).Length);
        _stateManager.Anime.ResetTrigger("Kicking");
        SwitchState(_factory.Walk());
        yield return null;
    }

}
