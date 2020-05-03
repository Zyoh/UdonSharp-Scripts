
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OnInteractAnimationPlayer : UdonSharpBehaviour
{
    public Animator animator;
    public String animationName;

    private void Start()
    {
        if (animator == null)
        {
            animator = this.gameObject.GetComponent<Animator>();
        }
    }
    
    public override void Interact()
    {
        animator.Play(animationName);
    }
}
