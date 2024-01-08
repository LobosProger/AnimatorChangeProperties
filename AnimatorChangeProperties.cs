using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorChangeProperties : MonoBehaviour
{
	/*
	* This script is designed to unlock the ability to modify component properties, 
	* when the property is controlled, for example, by the Animator.
	* Due to the inability to control the property, this script compensates for this limitation.

	///! Attention! The script works only with trigger system and Any State!

	* Therefore, it should be placed ONLY on an Animator that has transitions between animations and trigger system
	*/


	//Name of State in Animator window, which will used in working of script
	[SerializeField] private string changePropertiesStateName = "ChangeProperties";
	[SerializeField] private Animator animator;
	
	private bool flaqOfChangingProperties;

	private void Start()
	{
		animator = GetComponent<Animator>();
		animator.keepAnimatorStateOnDisable = true; // Avoid resetting state of animator after disabling
	}

	private void Update()
	{
		if (animator != null)
		{
			if (animator.GetCurrentAnimatorStateInfo(0).IsName(changePropertiesStateName) && !flaqOfChangingProperties)
			{
				flaqOfChangingProperties = true;
				StartCoroutine(WaitEndFrameToDisableAnimator());
			}
			else if (!animator.GetCurrentAnimatorStateInfo(0).IsName(changePropertiesStateName) && flaqOfChangingProperties)
			{
				flaqOfChangingProperties = false;
				animator.enabled = true;
			}

			if (!animator.enabled)
			{
				if (IsAnyTriggerOfAnimatorChangedValue())
				{
					animator.enabled = true;
				}
			}
		}
	}

	private bool IsAnyTriggerOfAnimatorChangedValue()
	{
		for (int i = 0; i < animator.parameters.Length; i++)
		{
			if (animator.parameters[i].type == AnimatorControllerParameterType.Trigger)
			{
				bool isTriggerActivated = animator.GetBool(animator.parameters[i].name);
				if (isTriggerActivated)
				{
					return true;
				}
			}
		}
		
		return false;
	}

	private IEnumerator WaitEndFrameToDisableAnimator()
	{
		yield return new WaitForEndOfFrame();
		animator.enabled = false;
	}
}
