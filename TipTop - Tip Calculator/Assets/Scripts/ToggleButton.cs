using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleButton : MonoBehaviour
{
    [Header("Toggle Button")]
    [SerializeField] private bool toggledOnStart;
    [SerializeField] private Animator animator;
    private bool isToggled;

    [Serializable]
    public class ToggleButtonClickCallBack : UnityEvent<bool> { }
    public ToggleButtonClickCallBack OnToggle = new ToggleButtonClickCallBack();

    private void Start()
    {
        isToggled = toggledOnStart;
        InvokeToggle();

        if (isToggled)
        {
            animator.SetTrigger("Toggled On Start?");
        }
    }

    /// <summary>
    /// Toggle this button.
    /// </summary>
    public void Toggle()
    {
        isToggled = !isToggled;
        InvokeToggle();
    }

    /// <summary>
    /// Invoke the OnToggle method.
    /// </summary>
    private void InvokeToggle()
    {
        animator.SetBool("Toggled?", isToggled);
        OnToggle.Invoke(isToggled);
    }
}
