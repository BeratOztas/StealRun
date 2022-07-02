using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Animancer;

public class CharacterAnimation :MonoSingleton<CharacterAnimation>
{
    [SerializeField] private SimpleAnimancer animancer;

    [Header("Animations")]
    //idle ,react ,run ,attack
    [SerializeField] private string idleAnimName = "Texting";
    [SerializeField] private float idleAnimSpeed = 1f;

    [SerializeField] private string reactAnimName = "Reacting";
    [SerializeField] private float reactAnim_Speed = 1f;

    [SerializeField] private string runningAnimName = "Fast Running";
    [SerializeField] private float runningAnim_Speed = 1f;

    [SerializeField] private string attackAnimName = "Jump Attack";
    [SerializeField] private float attackAnim_Speed = 1f;

     void Awake()
    {
        idleAnimation();
    }

    public void PlayAnimation(string animName, float animSpeed)
    {
        animancer.PlayAnimation(animName);
        animancer.SetStateSpeed(animSpeed);
    }
    public void idleAnimation()
    {
        PlayAnimation(idleAnimName, idleAnimSpeed);
    }
    public void reactAnimation() {
        PlayAnimation(reactAnimName, reactAnim_Speed);
    }
    public void runAnimation()
    {
        PlayAnimation(runningAnimName, runningAnim_Speed);
    }
    public void attackAnimation()
    {
        PlayAnimation(attackAnimName, attackAnim_Speed);
    }
}
