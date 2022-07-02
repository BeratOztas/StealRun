using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Run(bool run)
    {
        anim.SetBool("Run", run);
    }
    public void React()
    {
        anim.SetTrigger("React");
    }
    public void Attack()
    {
        anim.SetTrigger("Attack");
    }
    public void Miss(bool miss) {
        anim.SetBool("Miss", miss);
    }


}
