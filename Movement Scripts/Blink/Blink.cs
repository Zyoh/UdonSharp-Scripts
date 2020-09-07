
using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class Blink : UdonSharpBehaviour
{
    private VRCPlayerApi playerLocal;
    private RaycastHit rayHit;
    private Vector3 headPos;
    private Quaternion headRot;
    private float blinkDist;
    private float timeSinceLastBlink;
    private float timeSinceLastRecharge;
    private int charges;

    [Tooltip("Blink will move the player to a maximum of this distance. Hitting a collider will end blink early.")]
    public float maxBlinkDistance = 7;
    [Tooltip("How far the player appears from the collider they hit when using blink.")]
    public float destinationDistFromCollider = 0.5f;
    
    public int maxCharges = 3;
    [Tooltip("Cooldown between charges. (Seconds)")]
    public float cooldownBlink = 0.5f;
    [Tooltip("Time between recharge cycles. (Seconds)")]
    public float cooldownRecharge = 2.0f;
    [Tooltip("How many charges to restore per recharge cycle.")]
    public int refillAmount = 1;

    void Start()
    {
        playerLocal = Networking.LocalPlayer;
    }

    private void Update()
    {
        timeSinceLastBlink += Time.deltaTime;
        timeSinceLastRecharge += Time.deltaTime;

        if (timeSinceLastRecharge > cooldownRecharge)
        {
            charges += refillAmount;
            if (charges > maxCharges)
            {
                charges = maxCharges;
            }
            
            timeSinceLastRecharge = 0;
        }
        
        // TODO: Some other button might be better for this but idk which one yet.
        // If jump button is pressed.
        if ((Input.GetButtonDown("Oculus_CrossPlatform_SecondaryThumbstick") || Input.GetButtonDown("Jump")) && timeSinceLastBlink > cooldownBlink && charges > 0)
        {
            blinkDist = maxBlinkDistance;
            // TODO: This may need to be changed to avatar origin position to prevent clipping into ground with tall avatars.
            headPos = playerLocal.GetBonePosition(HumanBodyBones.Head);
            headRot = playerLocal.GetBoneRotation(HumanBodyBones.Head);
            if (Physics.Raycast(headPos, headRot * Vector3.forward, out rayHit))
            {
                if (rayHit.distance <= maxBlinkDistance)
                {
                    blinkDist = rayHit.distance;
                }
            }
            playerLocal.TeleportTo(playerLocal.GetPosition() + (headRot * Vector3.forward) * (blinkDist - destinationDistFromCollider), playerLocal.GetRotation());
            
            timeSinceLastBlink = 0;
            charges--;
        }
    }
}
