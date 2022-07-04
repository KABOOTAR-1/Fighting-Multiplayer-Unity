using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutePunch : MonoBehaviour
{

    Animator anime;

    public ExecutePunch(Animator anim)
    {
        anime = anim;
    }

    public void Execute()
    {
        anime.SetTrigger("Jumping");
    }
}
