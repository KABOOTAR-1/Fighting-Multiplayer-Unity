using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurricaneState : PlayerBaseState
{
    public PlayerHurricaneState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }

    public override void EnterState()
    {
        Debug.Log("In HUrricane");
        _stateManager.StartCoroutine(ExecuteHurricaneKick());
    }
    public override void ExitState() { }

    public override void CheckStates()
    {
      
    }

    IEnumerator ExecuteHurricaneKick()
    {
        _stateManager.Anime.SetTrigger("Hurricane Kick");
        yield return new WaitForSeconds(_stateManager.Anime.GetCurrentAnimatorClipInfo(0).Length);
        _stateManager.Anime.ResetTrigger("Hurricane Kick");
        SwitchState(_factory.Walk());
        yield return null;
        _stateManager.hr[1].m_attack = false;
        _stateManager.hr[1].enabled = false;

    }
}
