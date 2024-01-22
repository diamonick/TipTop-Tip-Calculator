using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JoshH.UI;

public class DropdownMenu : MonoBehaviour
{
    // Tip Calculator Instance
    private TipCalculator TC;

    [Header("Dropdown Menu")]
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private Image dropdownListBkg;
    [SerializeField] private TMP_Text label;
    [SerializeField] private Image arrow;
    [SerializeField] private Image blurShadow;

    [Header("Dropdown Item"), Space(8)]
    [SerializeField] private DropdownMenuItem item;

    private Color lightColor;
    private Color primaryColor;
    private Color pressedColor;
    private Color releasedColor;

    private void Start()
    {
        SetDropdownColors();
    }

    public void SetDropdownColors()
    {
        if (TC == null)
        {
            TC = TipCalculator.Instance;
        }

        ColorTheme colorTheme = TC.Settings.ColorThemePref;
        bool darkMode = TC.Settings.DarkMode;

        lightColor = colorTheme.lightColor;
        primaryColor = colorTheme.primaryColor;
        pressedColor = darkMode ? colorTheme.tertiaryColor : colorTheme.primaryColor;
        releasedColor = darkMode ? colorTheme.darkColor : colorTheme.lightColor;

        // Get dropdown's colors (Normal, Highlighted, Pressed, and Selected).
        ColorBlock dropdownColors = dropdown.colors;
        dropdownColors.normalColor = releasedColor;
        dropdownColors.highlightedColor = releasedColor;
        dropdownColors.pressedColor = colorTheme.primaryColor;
        dropdownColors.selectedColor = releasedColor;

        // Reassign dropdown's colors.
        dropdown.colors = dropdownColors;

        // Set dropdown's blur shadow color.
        blurShadow.color = darkMode ? colorTheme.darkColor : colorTheme.primaryColor;
        blurShadow.color *= new Color(1f, 1f, 1f, 0.25f);

        // Set dropdown label color.
        SetLabelColor(pressedColor);

        // Set dropdown arrow color.
        SetArrowColor(primaryColor);

        // Set dropdown item's colors.
        item.SetItemColors();

        // Set dropdown list's background color.
        dropdownListBkg.color = releasedColor;
    }

    public void SetValue(int value)
    {
        dropdown.value = value;
    }

    #region Event Trigger Method(s)
    /// <summary>
    /// Call this method when the dropdown is pressed.
    /// </summary>
    public void OnDropdownPressed()
    {
        SetLabelColor(lightColor);
        SetArrowColor(lightColor);
    }

    /// <summary>
    /// Call this method when the dropdown is released.
    /// </summary>
    public void OnDropdownReleased()
    {
        SetLabelColor(pressedColor);
        SetArrowColor(primaryColor);
    }
    #endregion

    #region Set Color Method(s)
    /// <summary>
    /// Set dropdown label color.
    /// </summary>
    /// <param name="color">Label color.</param>
    private void SetLabelColor(Color color)
    {
        if (label != null)
        {
            label.color = color;
        }
    }

    /// <summary>
    /// Set dropdown arrow color.
    /// </summary>
    /// <param name="color">Arrow color.</param>
    private void SetArrowColor(Color color)
    {
        if (arrow != null)
        {
            arrow.color = color;
        }
    }
    #endregion
}
