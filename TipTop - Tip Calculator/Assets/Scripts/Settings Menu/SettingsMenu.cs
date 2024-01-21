using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JoshH.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    // Tip Calculator Instance
    private TipCalculator TC;

    public enum RoundingType
    {
        Exact = 0,
        RoundUp = 1,
        RoundDown = 2
    }

    [Header("Settings Menu")]
    [SerializeField] private Animator animator;
    [SerializeField] private GraphicRaycaster graphicRaycaster;

    [Header("Color Theme"), Space(8)]
    [SerializeField] private ColorTheme colorThemePref;
    public ColorTheme ColorThemePref { get { return colorThemePref; } }
    [SerializeField] private ColorThemeSlot[] colorThemeSlots;
    private ColorThemeSlot markedColorThemeSlot;

    [Header("Dark Mode"), Space(8)]
    [SerializeField] private bool darkMode;
    public bool DarkMode { get { return darkMode; } }
    [SerializeField] private ToggleButton darkModeToggleButton;

    [Header("Rounding"), Space(8)]
    [SerializeField] private RoundingType roundTip;
    public RoundingType RoundTip => roundTip;
    [SerializeField] private RoundingType roundTotal;
    public RoundingType RoundTotal => roundTotal;

    [Header("UI Elements"), Space(8)]
    [SerializeField] private UIGradient gradientMenuHeader;
    [SerializeField] private UIGradient gradientBackground;
    [SerializeField] private TMP_Text colorThemeHeaderText;
    [SerializeField] private Image colorThemeScrollBar;
    [SerializeField] private Image colorThemeScrollBarBkg;
    [SerializeField] private TMP_Text darkModeText;
    [SerializeField] private TMP_Text roundTipText;
    [SerializeField] private DropdownMenu roundTipDropdownMenu;
    [SerializeField] private TMP_Text roundTotalText;
    [SerializeField] private DropdownMenu roundTotalDropdownMenu;

    private void Start()
    {
        TC = TipCalculator.Instance;

        UpdateUI();
        TC.UI.UpdateUI();
    }

    #region Settings Method(s)
    /// <summary>
    /// Set user's color theme.
    /// </summary>
    /// <param name="colorTheme">New color theme.</param>
    public void SetColorTheme(ColorThemeSlot slot)
    {
        markedColorThemeSlot = slot;

        for (int i = 0; i < colorThemeSlots.Length; i++)
        {
            if (colorThemeSlots[i] == markedColorThemeSlot)
            {
                colorThemePref = slot.ColorTheme;

                UpdateUI();
                TC.UI.UpdateUI();
            }
            else
            {
                colorThemeSlots[i].Uncheck();
            }
        }
    }

    /// <summary>
    /// Toggle the Dark Mode setting and update the UI's color theme accordingly.
    /// </summary>
    public void ToggleDarkMode()
    {
        darkModeToggleButton.Toggle(ref darkMode);
        UpdateUI();
        TC.UI.UpdateUI();
    }

    /// <summary>
    /// Set the Round Tip Setting.
    /// </summary>
    /// <param name="value">The Rounding Type in integer form.</param>
    public void SetRoundTip(int value)
    {
        roundTip = (RoundingType)value;
    }

    /// <summary>
    /// Set the Round Total Setting.
    /// </summary>
    /// <param name="value">The Rounding Type in integer form.</param>
    public void SetRoundTotal(int value)
    {
        roundTotal = (RoundingType)value;
    }
    #endregion

    public void UpdateUI()
    {
        gradientMenuHeader.LinearGradient = colorThemePref.mainGradent;
        gradientBackground.LinearGradient = darkMode ? colorThemePref.darkBackgroundGradent : colorThemePref.lightBackgroundGradent;
        gradientBackground.Intensity = darkMode ? 1f : 0.5f;

        colorThemeHeaderText.color = colorThemePref.primaryColor;
        colorThemeScrollBar.color = colorThemePref.primaryColor;
        colorThemeScrollBarBkg.color = darkMode ? colorThemePref.darkColor : colorThemePref.tertiaryColor;

        darkModeToggleButton.UpdateUI();

        darkModeText.color = colorThemePref.primaryColor;
        roundTipText.color = colorThemePref.primaryColor;
        roundTipDropdownMenu.SetDropdownColors();
        roundTotalText.color = colorThemePref.primaryColor;
        roundTotalDropdownMenu.SetDropdownColors();

        foreach (ColorThemeSlot slot in colorThemeSlots)
        {
            slot.UpdateUI();
        }
    }

    #region Show/Hide Menu Method(s)
    /// <summary>
    /// Show the Settings Menu.
    /// </summary>
    public void ShowSettingsMenu()
    {
        Activate();
        animator.SetBool("Show Menu?", true);
    }

    /// <summary>
    /// Hide the Settings Menu.
    /// </summary>
    public void HideSettingsMenu()
    {
        DisableRaycast();
        animator.SetBool("Show Menu?", false);
    }

    /// <summary>
    /// Enable Graphic Raycaster component.
    /// </summary>
    public void EnableRaycast()
    {
        graphicRaycaster.enabled = true;
    }

    /// <summary>
    /// Disable Graphic Raycaster component.
    /// </summary>
    public void DisableRaycast()
    {
        graphicRaycaster.enabled = false;
    }

    /// <summary>
    /// Activate this menu.
    /// </summary>
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Deactivate this menu.
    /// </summary>
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
    #endregion
}
