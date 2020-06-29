
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
            player.GetBonePosition(HumanBodyBones.Head),
            player.GetBonePosition(HumanBodyBones.Neck),
            player.GetBonePosition(HumanBodyBones.Chest),
            player.GetBonePosition(HumanBodyBones.Spine),
            player.GetBonePosition(HumanBodyBones.Hips),
            player.GetBonePosition(HumanBodyBones.LeftUpperLeg),
            player.GetBonePosition(HumanBodyBones.LeftLowerLeg),
            player.GetBonePosition(HumanBodyBones.LeftFoot)
        };
        */

        float height = 0;

        height += Vector3.Distance(
            player.GetBonePosition(HumanBodyBones.Head),
            player.GetBonePosition(HumanBodyBones.Neck)
            );

        height += Vector3.Distance(
            player.GetBonePosition(HumanBodyBones.Neck),
            player.GetBonePosition(HumanBodyBones.Chest)
            );

        height += Vector3.Distance(
            player.GetBonePosition(HumanBodyBones.Chest),
            player.GetBonePosition(HumanBodyBones.Spine)
            );

        height += Vector3.Distance(
            player.GetBonePosition(HumanBodyBones.Spine),
            player.GetBonePosition(HumanBodyBones.Hips)
            );

        height += Vector3.Distance(
            player.GetBonePosition(HumanBodyBones.Hips),
            player.GetBonePosition(HumanBodyBones.LeftUpperLeg)
            );

        height += Vector3.Distance(
            player.GetBonePosition(HumanBodyBones.LeftUpperLeg),
            player.GetBonePosition(HumanBodyBones.LeftLowerLeg)
            );

        height += Vector3.Distance(
            player.GetBonePosition(HumanBodyBones.LeftLowerLeg),
            player.GetBonePosition(HumanBodyBones.LeftFoot)
            );


        return height;
    }
}
