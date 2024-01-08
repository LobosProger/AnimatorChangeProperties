# AnimatorChangeProperties
Script created in 2020 during developing Quadroom game. This script, **AnimatorChangeProperties**, is created to overcome the limitation of modifying component properties controlled by the Animator. When properties are controlled by the Animator, this script compensates for the inability to directly modify them. 

### How it works:

1. **State Name Setup:**
   - Set the `changePropertiesStateName` variable to the name of the state in the Animator window that will trigger property changes.

2. **Trigger System and Any State:**
   - This script works specifically with the trigger system and Any State. Therefore, it should be placed on an Animator that has transitions between animations and uses triggers.

3. **Operation:**
   - When the Animator's state matches the specified state name, the script disables the Animator component temporarily using a coroutine (`WaitEndFrameToDisableAnimator()`).
   - It re-enables the Animator when the state changes to something other than the specified state name.

4. **Additional Check:**
   - If the Animator is disabled and any trigger is activated, it re-enables the Animator. This check ensures that triggers can activate changes even when the Animator is initially disabled.

### How to Use:
1. Attach the script to the GameObject with the Animator component.
2. Set the `changePropertiesStateName` to the desired state triggering property changes.
3. Ensure the Animator has transitions between animations and uses triggers.
4. The script will handle enabling and disabling the Animator based on the specified state and trigger conditions.
