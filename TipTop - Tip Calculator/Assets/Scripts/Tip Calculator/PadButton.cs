using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PadButton : MonoBehaviour
{
    // Tip Calculator Instance
    protected TipCalculator TC;

    [Header("Pad Button")]
    [SerializeField] protected NumberPad numberPad;
    [SerializeField] protected Button button;
    [SerializeField] protected TMP_Text buttonText;
    [SerializeField] protected Image icon;
    [SerializeField] protected Shadow dropShadow;

    protected Color lightColor;
    protected Color pressedColor;
    protected Color releasedColor;

    protected virtual void Start()
    {
        TC = TipCalculator.Instance;
    }

    /// <summary>
    /// Set button's colors (Normal, Highlighted, Pressed, Selected, and Disabled).
    /// </summary>
    public void SetButtonColors()
    {
        if (TC == null)
        {
            TC = TipCalculator.Instance;
        }

        ColorTheme colorTheme = TC.Settings.ColorThemePref;
        bool darkMode = TC.Settings.DarkMode;

        lightColor = colorTheme.lightColor;
        pressedColor = colorTheme.primaryColor;
        releasedColor = darkMode ? colorTheme.darkColor : colorTheme.lightColor;

        // Get button's colors (Normal, Highlighted, Pressed, and Selected).
        ColorBlock buttonColors = button.colors;
        buttonColors.normalColor = releasedColor;
        buttonColors.highlightedColor = releasedColor;
        buttonColors.pressedColor = colorTheme.primaryColor;
        buttonColors.selectedColor = releasedColor;

        // Reassign button's colors.
        button.colors = buttonColors;
        dropShadow.effectColor = darkMode ? colorTheme.darkColor : colorTheme.primaryColor;
        dropShadow.effectColor *= new Color(1f, 1f, 1f, 0.25f);

        // Set button text color.
        SetTextColor(pressedColor);

        // Set icon color.
        SetIconColor(pressedColor);
    }

    /// <summary>
    /// Call this method when the button is pressed.
    /// </summary>
    public virtual void OnButtonPressed()
    {
        SetTextColor(lightColor);
        SetIconColor(lightColor);
    }

    /// <summary>
    /// Call this method when the button is released.
    /// </summary>
    public virtual void OnButtonReleased()
    {
        SetTextColor(pressedColor);
        SetIconColor(pressedColor);
    }

    /// <summary>
    /// Set button text color.
    /// </summary>
    /// <param name="color">Text color.</param>
    private void SetTextColor(Color color)
    {
        if (buttonText != null)
        {
            buttonText.color = color;
        }
    }

    /// <summary>
    /// Set icon color.
    /// </summary>
    /// <param name="color">Icon color.</param>
    private void SetIconColor(Color color)
    {
        if (icon != null)
        {
            icon.color = color;
        }
    }
}
