### StayOnPlatform

---
#### --- What it does ---

Moves players with platforms they're standing on as you would irl.

#### --- Usage Notes ---

- Attach this script to a moving object containing a box collider or any collider with a flat top. Curved colliders, such as spheres, will likely not grab the player unless they're on the top/bottom-most points.
- Default variables values are designed for carrying players above the object.
- **Platform rotations are not supported** (see issue #2).

##### Variables:

- ***(Optional)*** **Platform**: Overrides the object you want the player to stand on. Must contain a collider. Leave this empty to use the parent object of the script.
- **Grab Height**: First value is maximum distance above the top of the collider; second value is maximum distance below the bottom of the collider. Player will follow the platform when within these values.
- **Lock Player Y**: Prevents changes to the player's Y transform. Main use case is to disable gravity when the player is under the object to prevent them from falling. Another use could be to prevent jumping while above the object as jumping above the grab height while in motion can cause odd effects.

#### --- Examples ---

Import the Unity package after importing [VRC](https://api.vrchat.cloud/home/download)[SDK3](https://vrchat.com/home/download) and [UdonSharp](https://github.com/Merlin-san/UdonSharp). It should be immediately ready to build and test. Includes an example for standing on a platform and being moved by a platform above you.

Unity package is currently up to date with the most recent version of the script.

#### --- Known Issues/Limitations ---

1) Jumping past the maximum grab height gives the player velocity in the direction opposite of the platform. Example: While standing still on a platform moving towards positive X (+X), jumping will have you land farther towards -X than where you jumped from.

2) Rotations will not move the player as expected in reality. Example: standing on the corner of a cube while it spins will not move you with that corner; you will instead stay still and fall as if the script wasn't activated.

3) Due to my very odd coding decisions, this script might cause odd behaviour to players under -10000 Y. If your map enables players to reach -10000 Y or lower, you'll likely need to edit some parts of the script.

#### --- Misc Info ---

- This script does not rely on a certain framerate or frequency of execution - you can replace Update with FixedUpdate, or make your own function which can be called as frequently as you want.
- To fix this script and allow it to function on maps going below -10000 Y, replace the numbers in lines 15 and 43.