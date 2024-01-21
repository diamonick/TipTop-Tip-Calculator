using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ToggleButton : MonoBehaviour
{
    // Tip Calculator Instance
    private TipCalculator TC;

    [Header("Toggle Button")]
    [SerializeField] private bool toggledOnStart;
    [SerializeField] private Animator animator;
    [SerializeField] private Image toggleFill;
    [SerializeField] private Image toggleBackground;
    private bool isToggled;

    private void OnEnable()
    {
        InitializeToggleButton();
    }

    /// <summary>
    /// Initialize toggle button.
    /// </summary>
    private void InitializeToggleButton()
    {
        if (TC == null)
        {
            TC = TipCalculator.Instance;
        }

        if (TC.Settings.DarkMode)
        {
            animator.SetTrigger("Toggled On Start?");
            animator.SetBool("Toggled?", true);
        }
    }

    /// <summary>
    /// Update the UI elements of the toggle button.
    /// </summary>
    public void UpdateUI()
    {
        if (TC == null)
        {
            TC = TipCalculator.Instance;
        }

        ColorTheme colorTheme = TC.Settings.ColorThemePref;
        bool darkMode = TC.Settings.DarkMode;

        toggleFill.color = colorTheme.primaryColor;
        toggleBackground.color = darkMode ? colorTheme.darkColor : colorTheme.tertiaryColor;
    }

    /// <summary>
    /// Toggle this button.
    /// </summary>
    /// <param name="toggleVar">Boolean to toggle the referenced bool variable.</param>
    public void Toggle(ref bool toggleVar)
    {
        toggleVar = !toggleVar;
        animator.SetBool("Toggled?", toggleVar);
    }
}
