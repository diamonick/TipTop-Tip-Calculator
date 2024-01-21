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

    [Header("Settings Menu")]
    [SerializeField] private Animator animator;
    [SerializeField] private GraphicRaycaster graphicRaycaster;

    [Header("Color Theme"), Space(8)]
    [SerializeField] private ColorTheme colorThemePref;
    public ColorTheme ColorThemePref { get { return colorThemePref; } }
    [SerializeField] private ColorThemeSlot[] colorThemeSlots;
    private ColorThemeSlot markedColorThemeSlot;

    [SerializeField] private bool darkMode;
    public bool DarkMode { get { return darkMode; } }

    [Header("UI Elements"), Space(8)]
    [SerializeField] private UIGradient gradientMenuHeader;
    [SerializeField] private UIGradient gradientBackground;
    [SerializeField] private TMP_Text colorThemeHeaderText;
    [SerializeField] private Image colorThemeScrollBar;
    [SerializeField] private Image colorThemeScrollBarBkg;
    [SerializeField] private TMP_Text darkModeText;
    [SerializeField] private TMP_Text roundTipText;
    [SerializeField] private Image roundTipDropdownBox;
    [SerializeField] private TMP_Text roundTipDropdownLabel;
    [SerializeField] private Image roundTipDropdownArrow;
    [SerializeField] private TMP_Text roundTotalText;
    [SerializeField] private Image roundTotalDropdownBox;
    [SerializeField] private TMP_Text roundTotalDropdownLabel;
    [SerializeField] private Image roundTotalDropdownArrow;

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
        darkMode = !darkMode;

        UpdateUI();
        TC.UI.UpdateUI();
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

        darkModeText.color = colorThemePref.primaryColor;
        roundTipText.color = colorThemePref.primaryColor;
        roundTipDropdownLabel.color = colorThemePref.primaryColor;
        roundTipDropdownArrow.color = colorThemePref.primaryColor;
        roundTotalText.color = colorThemePref.primaryColor;
        roundTotalDropdownLabel.color = colorThemePref.primaryColor;
        roundTotalDropdownArrow.color = colorThemePref.primaryColor;

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
