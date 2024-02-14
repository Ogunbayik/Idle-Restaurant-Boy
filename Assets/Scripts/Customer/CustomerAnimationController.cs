using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAnimationController : MonoBehaviour
{
    private const string WALK_PARAMETER = "isWalk";
    private const string SIT_ANIMATION = "isSit";

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void WalkAnimation(bool isWalk)
    {
        animator.SetBool(WALK_PARAMETER, isWalk);
    }
    
    public void SitAnimation(bool isSit)
    {
        animator.SetBool(SIT_ANIMATION, isSit);
    }
}
