using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private const string RUN_PARAMETER = "isRun";
    private const string CARRY_PARAMETER = "isCarry";

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void RunAnimation(bool isRun)
    {
        animator.SetBool(RUN_PARAMETER, isRun);
    }

    public void CarryAnimation(bool isCarry)
    {
        animator.SetBool(CARRY_PARAMETER, isCarry);
    }
}
