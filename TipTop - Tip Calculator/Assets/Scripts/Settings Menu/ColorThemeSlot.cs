using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JoshH.UI;

public class ColorThemeSlot : MonoBehaviour
{
    // Tip Calculator Instance
    private TipCalculator TC;

    [Header("Color Theme Slot")]
    [SerializeField] private ColorTheme colorTheme;
    [SerializeField] private UIGradient uiGradient;
    [SerializeField] private GameObject checkmark;
    [SerializeField] private Image blurShadow;
    public ColorTheme ColorTheme => colorTheme;
    [SerializeField] private bool isChecked;

    private void Start()
    {
        TC = TipCalculator.Instance;

        uiGradient.LinearGradient = colorTheme.mainGradent;
        blurShadow.color = TC.UI.ColorThemePref.primaryColor;
        blurShadow.color *= new Color(1f, 1f, 1f, 0.25f);

        checkmark.SetActive(isChecked);
    }

    /// <summary>
    /// Set the UI's color theme.
    /// </summary>
    public void SetColorTheme()
    {
        TC.UI.SetColorTheme(colorTheme);

        isChecked = true;
        checkmark.SetActive(true);
    }
}
