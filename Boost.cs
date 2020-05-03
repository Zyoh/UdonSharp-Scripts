using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Boost : UdonSharpBehaviour
{
    [Tooltip("Place this in the centre of the boost area.")]
    public GameObject referencePoint;
    [Tooltip("Radius around referencePoint which triggers boost.")]
    public float threshold = 2.0f;
    [Tooltip("Direction of boost.")]
    public GameObject targetPoint;
    [Tooltip("Boost power.")]
    public float boostSpeed = 20;

    private Boolean isActivated = false;
    private VRCPlayerApi localPlayer;
    private Vector3 boost; 

    private void Start()
    {
        if (referencePoint == null)
        {
            referencePoint = this.gameObject;
        }
        localPlayer = Networking.LocalPlayer;
        boost = targetPoint.transform.position - referencePoint.transform.position;
    }
    private void Update()
    {
        var dist = Vector3.Distance(localPlayer.GetPosition(), referencePoint.transform.position);
        if (dist < threshold)
        {
            if (!isActivated)
            {
                isActivated = true;
                localPlayer.SetVelocity(boost.normalized * boostSpeed);
            }
        }
        else if (isActivated)
        {
            isActivated = false;
        }
    }
}
