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

    private bool _inProximity;
    
    private void Update()
    {
        var dist = Vector3.Distance(Networking.LocalPlayer.GetPosition(), referencePoint.transform.position);
        if (dist < threshold)
        {
            var boost = targetPoint.transform.position - Networking.LocalPlayer.GetPosition();
            Networking.LocalPlayer.SetVelocity(boost.normalized * boostSpeed);
        }
    }
}