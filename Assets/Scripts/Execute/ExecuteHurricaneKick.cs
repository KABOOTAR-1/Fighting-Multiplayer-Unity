using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecuteHurricaneKick : MonoBehaviour
{
    // Start is called before the first frame update

    Animator anime;

    public ExecuteHurricaneKick(Animator anim)
    {
        anime = anim;
    }

    public void Execute()
    {
        anime.SetTrigger("Hurricane");
    }
}
