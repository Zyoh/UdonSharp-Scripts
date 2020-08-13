
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OnInteractAnimationPlayer : UdonSharpBehaviour
{
    public Animator animator;
    public String[] animationNames;
    [UdonSynced]
    private int counter = 0;
    public bool synced;

    private void Start()
    {
        if (animator == null)
        {
            animator = this.gameObject.GetComponent<Animator>();
        }
    }
    
    public override void Interact()
    {
        if (synced)
        {
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "PlayAnimation");
        }
        else
        {
            PlayAnimation();
        }
    }

    public void PlayAnimation()
    {
        animator.Play(animationNames[counter]);
        counter++;
        if (counter >= animationNames.Length)
        {
            counter = 0;
        }
    }
}
