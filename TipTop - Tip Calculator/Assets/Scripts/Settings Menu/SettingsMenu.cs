using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        TC = TipCalculator.Instance;

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
        TC.UI.UpdateUI();
    }
    #endregion

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
}
