
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ToggleObject : UdonSharpBehaviour
{
    [Tooltip("Put object here")]
    public GameObject toggledObject;

    public override void Interact()
    {
        toggledObject.SetActive(!toggledObject.activeSelf);
    }
}
