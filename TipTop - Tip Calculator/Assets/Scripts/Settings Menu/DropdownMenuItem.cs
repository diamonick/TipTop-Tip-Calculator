using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JoshH.UI;

public class DropdownMenuItem : MonoBehaviour
{
    // Tip Calculator Instance
    private TipCalculator TC;

    [Header("Dropdown Menu Item")]
    [SerializeField] private Toggle itemToggle;
    [SerializeField] private Image itemCheckmark;
    [SerializeField] private TMP_Text itemLabel;

    private Color lightColor;
    private Color pressedColor;
    private Color releasedColor;

    private void Start()
    {
        SetItemColors();
    }

    public void SetItemColors()
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

        // Get dropdown item's colors (Normal, Highlighted, Pressed, and Selected).
        ColorBlock itemColors = itemToggle.colors;
        itemColors.normalColor = releasedColor;
        itemColors.highlightedColor = releasedColor;
        itemColors.pressedColor = colorTheme.primaryColor;
        itemColors.selectedColor = colorTheme.tertiaryColor;

        // Reassign dropdown item's colors.
        itemToggle.colors = itemColors;

        // Set dropdown item's label color.
        SetLabelColor(pressedColor);
        // Set dropdown item's checkmark color.
        SetCheckmarkColor(pressedColor);
    }

    #region Event Trigger Method(s)
    /// <summary>
    /// Call this method when the dropdown item is pressed.
    /// </summary>
    public void OnItemPressed()
    {
        SetLabelColor(lightColor);
        SetCheckmarkColor(lightColor);
    }

    /// <summary>
    /// Call this method when the dropdown item is released.
    /// </summary>
    public void OnItemReleased()
    {
        SetLabelColor(pressedColor);
        SetCheckmarkColor(pressedColor);
    }
    #endregion

    #region Set Color Method(s)
    /// <summary>
    /// Set dropdown item's label color.
    /// </summary>
    /// <param name="color">Item label color.</param>
    private void SetLabelColor(Color color)
    {
        if (itemLabel != null)
        {
            itemLabel.color = color;
        }
    }

    /// <summary>
    /// Set checkmark color.
    /// </summary>
    /// <param name="color">Item checkmark color.</param>
    private void SetCheckmarkColor(Color color)
    {
        if (itemCheckmark != null)
        {
            itemCheckmark.color = color;
        }
    }
    #endregion
}
