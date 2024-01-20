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

    public void SetButtonColors()
    {
        TC = TipCalculator.Instance;
        ColorTheme colorTheme = TC.UI.ColorThemePref;

        bool darkMode = TC.UI.DarkMode;
        lightColor = colorTheme.lightColor;
        pressedColor = colorTheme.primaryColor;
        releasedColor = darkMode ? colorTheme.darkColor : colorTheme.lightColor;

        // Get button's colors (Normal, Highlighted, Pressed, Selected, and Disabled).
        ColorBlock buttonColors = button.colors;
        buttonColors.normalColor = releasedColor;
        buttonColors.highlightedColor = releasedColor;
        buttonColors.pressedColor = colorTheme.primaryColor;
        buttonColors.selectedColor = releasedColor;

        // Reassign button's colors.
        button.colors = buttonColors;
        dropShadow.effectColor = new Color(colorTheme.primaryColor.r, colorTheme.primaryColor.g, colorTheme.primaryColor.b, 0.25f);

        // Set button text color.
        if (buttonText != null)
        {
            SetTextColor(pressedColor);
        }

        // Set icon color.
        if (icon != null)
        {
            SetIconColor(pressedColor);
        }
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
