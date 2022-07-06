using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunchState : PlayerBaseState
{
    // Start is called before the first frame update
    public PlayerPunchState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }

    public override void EnterState()
    {
        Debug.Log("Punch");
        _stateManager.StartCoroutine(ExecutePunch());
    }
    public override void ExitState() { }

    public override void CheckStates()
    {
       
    }

    IEnumerator ExecutePunch()
    {
        _stateManager.Anime.SetTrigger("Punch");
        yield return new WaitForSeconds(_stateManager.Anime.GetCurrentAnimatorClipInfo(0).Length);
        _stateManager.Anime.ResetTrigger("Punch");
        SwitchState(_factory.Walk());
        yield return null;
    }
}
