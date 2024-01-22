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
    [SerializeField] private bool deletePreferences;

    [Header("Color Theme"), Space(8)]
    [SerializeField] private ColorTheme colorThemePref;
    public ColorTheme ColorThemePref { get { return colorThemePref; } }
    [SerializeField] private List<ColorThemeSlot> colorThemeSlots;
    [SerializeField] private ColorThemeSlot markedColorThemeSlot;
    [SerializeField] private Scrollbar scrollBar;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private RectTransform contentPanel;

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

        // Set scroll bar's default position to 0.
        scrollBar.value = 0f;

        if (deletePreferences)
        {
            UserPrefs.DeleteUserPreferences();
        }

        // Load settings.
        LoadSettings();
    }

    /// <summary>
    /// Update the UI elements in the Settings Menu.
    /// </summary>
    public void UpdateUI()
    {
        gradientMenuHeader.LinearGradient = colorThemePref.mainGradent;
        gradientBackground.LinearGradient = darkMode ? colorThemePref.darkBackgroundGradent : colorThemePref.lightBackgroundGradent;
        gradientBackground.Intensity = darkMode ? 1f : 0.5f;

        colorThemeHeaderText.color = darkMode ? colorThemePref.tertiaryColor : colorThemePref.primaryColor;
        colorThemeScrollBar.color = colorThemePref.primaryColor;
        colorThemeScrollBarBkg.color = darkMode ? colorThemePref.darkColor : colorThemePref.tertiaryColor;

        darkModeToggleButton.UpdateUI();

        darkModeText.color = darkMode ? colorThemePref.tertiaryColor : colorThemePref.primaryColor;
        roundTipText.color = darkMode ? colorThemePref.tertiaryColor : colorThemePref.primaryColor;
        roundTipDropdownMenu.SetDropdownColors();
        roundTotalText.color = darkMode ? colorThemePref.tertiaryColor : colorThemePref.primaryColor;
        roundTotalDropdownMenu.SetDropdownColors();

        foreach (ColorThemeSlot slot in colorThemeSlots)
        {
            slot.UpdateUI();
        }
    }

    #region Save/Load Settings Method(s)
    /// <summary>
    /// Save user's preferred Color Theme.
    /// </summary>
    public void SaveColorTheme() => UserPrefs.SaveColorThemeID(markedColorThemeSlot.ID);

    /// <summary>
    /// Save user's preferred Dark Mode setting.
    /// </summary>
    public void SaveDarkMode() => UserPrefs.SaveDarkModeID(darkMode);

    /// <summary>
    /// Save user's preferred rounding type for Round Tip.
    /// </summary>
    public void SaveRoundTip() => UserPrefs.SaveRoundTipID((int)roundTip);

    /// <summary>
    /// Save user's preferred rounding type for Round Total.
    /// </summary>
    public void SaveRoundTotal() => UserPrefs.SaveRoundTotalID((int)roundTotal);

    /// <summary>
    /// Load user's preferences in the Settings menu.
    /// </summary>
    private void LoadSettings()
    {
        darkMode = UserPrefs.LoadDarkModeID();
        SetRoundTip(UserPrefs.LoadRoundTipID());
        SetRoundTotal(UserPrefs.LoadRoundTotalID());

        markedColorThemeSlot = colorThemeSlots[UserPrefs.LoadColorThemeID()];
        if (markedColorThemeSlot != null)
        {
            markedColorThemeSlot.Check();
        }

        UpdateUI();
        TC.UI.UpdateUI();
    }
    #endregion

    #region Settings Method(s)
    /// <summary>
    /// Set user's color theme.
    /// </summary>
    /// <param name="colorTheme">New color theme.</param>
    public void SetColorTheme(ColorThemeSlot slot)
    {
        markedColorThemeSlot = slot;

        for (int i = 0; i < colorThemeSlots.Count; i++)
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

        SaveColorTheme();
    }

    /// <summary>
    /// Toggle the Dark Mode setting and update the UI's color theme accordingly.
    /// </summary>
    public void ToggleDarkMode()
    {
        darkModeToggleButton.Toggle(ref darkMode);
        UpdateUI();
        TC.UI.UpdateUI();

        SaveDarkMode();
    }

    /// <summary>
    /// Set the Round Tip Setting.
    /// </summary>
    /// <param name="value">The Rounding Type in integer form.</param>
    public void SetRoundTip(int value)
    {
        if (value == (int)roundTip)
            return;

        roundTip = (RoundingType)value;
        roundTipDropdownMenu.SetValue(value);

        SaveRoundTip();
    }

    /// <summary>
    /// Set the Round Total Setting.
    /// </summary>
    /// <param name="value">The Rounding Type in integer form.</param>
    public void SetRoundTotal(int value)
    {
        if (value == (int)roundTotal)
            return;

        roundTotal = (RoundingType)value;
        roundTotalDropdownMenu.SetValue(value);

        SaveRoundTotal();
    }
    #endregion

    #region Show/Hide Menu Method(s)
    /// <summary>
    /// Show the Settings Menu.
    /// </summary>
    public void ShowSettingsMenu()
    {
        Activate();
        animator.SetBool("Show Menu?", true);
        UpdateUI();

        // Snap the scroll view's position to the user's preferred color theme.
        SnapTo(markedColorThemeSlot.slotRect);
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
    /// Snap the scroll view's position to the user's preferred color theme.
    /// </summary>
    /// <param name="target">Target.</param>
    private void SnapTo(RectTransform target)
    {
        Canvas.ForceUpdateCanvases();

        Vector2 localContentPos = (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position);
        Vector2 localTargetPos = (Vector2)scrollRect.transform.InverseTransformPoint(target.position);

        contentPanel.anchoredPosition = localContentPos - localTargetPos;
        contentPanel.anchoredPosition *= Vector2.right;
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
