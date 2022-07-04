using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteFireball :CommandManager.ICommand
{
    Animator anime;

    public ExecuteFireball(Animator anim)
    {
        anime = anim;
    }

    public void Execute()
    {
        anime.SetTrigger("Fireball");
    }

   
}
