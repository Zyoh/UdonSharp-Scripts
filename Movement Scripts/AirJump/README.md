### AirJump

---

Enables jumping while in the air.

#### --- Usage ---
Place the script anywhere in your world.
##### Variables:
- **Air Jumps**: Number of jumps that can be performed after leaving the ground.
- **Air Jump Power Ratio**: Jump impulse is multiplied by this value for air jumps. Jump impulse is checked the same frame as the calculation. Example: setting to 2 would make air jumps give twice the velocity of ground jumps.

#### --- Misc Info ---

- Jumps refresh when touching the ground. This is checked using `.IsPlayerGrounded()`.
- Tested on keyboard only but should be compatible with Oculus and Valve headsets.