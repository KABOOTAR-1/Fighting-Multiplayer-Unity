using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteKicking : MonoBehaviour
{

    Animator anime;

    public ExecuteKicking(Animator anim)
    {
        anime = anim;
    }

    public void Execute()
    {
        anime.SetTrigger("Kicking");
    }
}
