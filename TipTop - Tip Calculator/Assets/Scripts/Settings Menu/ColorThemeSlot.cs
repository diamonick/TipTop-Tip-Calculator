using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JoshH.UI;
using UnityEngine.EventSystems;

public class ColorThemeSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Tip Calculator Instance
    private TipCalculator TC;

    [Header("Color Theme Slot")]
    [SerializeField] private ColorTheme colorTheme;
    [SerializeField] private UIGradient uiGradient;
    [SerializeField] private Image slotBox;
    [SerializeField] private GameObject checkmark;
    [SerializeField] private Image blurShadow;
    [SerializeField] private Animator animator;
    public ColorTheme ColorTheme => colorTheme;
    [SerializeField] private bool isChecked;

    private void Start()
    {
        TC = TipCalculator.Instance;

        InitializeSlot();
    }

    /// <summary>
    /// Initialize color theme slot.
    /// </summary>
    private void InitializeSlot()
    {
        uiGradient.LinearGradient = colorTheme.mainGradent;
        blurShadow.color = TC.Settings.ColorThemePref.primaryColor;
        blurShadow.color *= new Color(1f, 1f, 1f, 0.25f);

        if (isChecked)
        {
            Check();
        }
        else
        {
            Uncheck();
        }
    }

    /// <summary>
    /// Update the UI elements of the color theme slot.
    /// </summary>
    public void UpdateUI()
    {
        if (TC == null)
        {
            TC = TipCalculator.Instance;
            InitializeSlot();
        }

        ColorTheme colorTheme = TC.Settings.ColorThemePref;
        bool darkMode = TC.Settings.DarkMode;

        slotBox.color = darkMode ? colorTheme.darkColor : colorTheme.lightColor;
        blurShadow.color = colorTheme.primaryColor;
        blurShadow.color *= new Color(1f, 1f, 1f, 0.25f);
    }

    /// <summary>
    /// Mark this slot as checked.
    /// </summary>
    public void Check()
    {
        isChecked = true;
        checkmark.SetActive(true);

        // Update the UI's color theme.
        TC.Settings.SetColorTheme(this);
    }

    /// <summary>
    /// Mark this slot as unchecked.
    /// </summary>
    public void Uncheck()
    {
        isChecked = false;
        checkmark.SetActive(false);
    }

    #region On Pointer Method(s)
    public void OnPointerDown(PointerEventData eventData)
    {
        animator.SetBool("Pressed?", true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        animator.SetBool("Pressed?", false);
    }
    #endregion
}
