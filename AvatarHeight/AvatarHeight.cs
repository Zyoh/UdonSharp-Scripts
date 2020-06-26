
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class AvatarHeight : UdonSharpBehaviour
{
    public float getAvatarHeight(VRCPlayerApi player)
    {
        /*
        // Array no work :<

        Vector3[] bones = {
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Head),
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Neck),
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Chest),
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Spine),
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Hips),
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.LeftUpperLeg),
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.LeftLowerLeg),
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.LeftFoot)
        };
        */

        float height = 0;

        height += Vector3.Distance(
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Head),
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Neck)
            );

        height += Vector3.Distance(
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Neck),
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Chest)
            );

        height += Vector3.Distance(
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Chest),
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Spine)
            );

        height += Vector3.Distance(
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Spine),
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Hips)
            );

        height += Vector3.Distance(
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.Hips),
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.LeftUpperLeg)
            );

        height += Vector3.Distance(
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.LeftUpperLeg),
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.LeftLowerLeg)
            );

        height += Vector3.Distance(
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.LeftLowerLeg),
            Networking.LocalPlayer.GetBonePosition(HumanBodyBones.LeftFoot)
            );


        return height;
    }
}
