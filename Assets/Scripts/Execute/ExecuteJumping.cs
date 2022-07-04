using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteJumping :CommandManager.ICommand
{

    Animator anime;

    public ExecuteJumping(Animator anim)
    {
        anime = anim;
    }

    public void Execute()
    {
        anime.SetTrigger("Jumping");
    }
}
