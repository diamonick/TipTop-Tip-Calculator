using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StringExtensionMethods;
using JoshH.UI;

public class TipCalculatorUI : MonoBehaviour
{
    // Tip Calculator Instance
    private TipCalculator TC;

    // Constants
    private const int BILL_AMOUNT_TEXT_SIZE = 200;
    private const int VALUE_TEXT_SIZE = 108;

    [Header("Color Theme"), Space(8)]
    [SerializeField] private ColorTheme colorThemePref;
    public ColorTheme ColorThemePref { get { return colorThemePref; } }
    [SerializeField] private bool darkMode;
    public bool DarkMode { get { return darkMode; } }
    [SerializeField] private bool testColorTheme;

    [Header("UI Text")]
    [SerializeField] private TMP_Text billAmountText;
    [SerializeField] private TMP_Text tipPercentageHeader;
    [SerializeField] private TMP_Text tipPercentageText;
    [SerializeField] private TMP_Text splitHeader;
    [SerializeField] private TMP_Text splitText;

    [SerializeField] private TMP_Text totalBillAmountText;
    [SerializeField] private TMP_Text totalTipAmountText;
    [SerializeField] private TMP_Text totalBillPerPersonText;
    [SerializeField] private TMP_Text tipPerPersonText;

    [SerializeField] private UIGradient gradientBackground;
    [SerializeField] private UIGradient gradientTopBackground;
    [SerializeField] private UIGradient gradienBillAmountBox;

    [Header("Sliders"), Space(8)]
    public Slider tipPercentageSlider;
    [SerializeField] private Image tipPercentageSliderBlurShadow;
    [SerializeField] private Image tipPercentageSliderOutline;
    [SerializeField] private Image tipPercentageSliderBkg;
    [SerializeField] private UIGradient gradientTipPercentageFill;
    public Slider splitSlider;
    [SerializeField] private Image splitSliderBlurShadow;
    [SerializeField] private Image splitSliderOutline;
    [SerializeField] private Image splitSliderBkg;
    [SerializeField] private UIGradient gradientSplitFill;

    [Header("Number Pad"), Space(8)]
    [SerializeField] private NumberPad numberPad;


    private void Start()
    {
        TC = TipCalculator.Instance;

        tipPercentageSlider.value = TC.TipPercentage;
        splitSlider.value = TC.Split;

        UpdateUIColorTheme();
    }

    private void UpdateUIColorTheme()
    {
        tipPercentageHeader.color = colorThemePref.primaryColor;
        tipPercentageText.color = colorThemePref.primaryColor;
        splitHeader.color = colorThemePref.primaryColor;
        splitText.color = colorThemePref.primaryColor;

        gradienBillAmountBox.LinearGradient = colorThemePref.mainGradent;

        tipPercentageSliderBkg.color = darkMode ? colorThemePref.darkColor : colorThemePref.tertiaryColor;
        tipPercentageSliderBlurShadow.color = colorThemePref.primaryColor;
        tipPercentageSliderOutline.color = colorThemePref.secondaryColor;
        gradientTipPercentageFill.LinearGradient = colorThemePref.mainGradent;
        splitSliderBkg.color = darkMode ? colorThemePref.darkColor : colorThemePref.tertiaryColor;
        splitSliderBlurShadow.color = colorThemePref.primaryColor;
        splitSliderOutline.color = colorThemePref.secondaryColor;
        gradientSplitFill.LinearGradient = colorThemePref.mainGradent;

        gradientTopBackground.LinearGradient = colorThemePref.mainGradent;
        gradientBackground.LinearGradient = darkMode ? colorThemePref.darkBackgroundGradent : colorThemePref.lightBackgroundGradent;

        numberPad.UpdateButtonColors();
    }

    /// <summary>
    /// Set user's color theme.
    /// </summary>
    /// <param name="colorTheme">New color theme.</param>
    public void SetColorTheme(ColorTheme colorTheme)
    {
        colorThemePref = colorTheme;
        UpdateUIColorTheme();
    }

    /// <summary>
    /// Toggle the Dark Mode setting and update the UI's color theme accordingly.
    /// </summary>
    /// <param name="isOn">Boolean to toggle the Dark Mode setting.</param>
    public void ToggleDarkMode(bool isOn)
    {
        darkMode = isOn;
        UpdateUIColorTheme();
    }

    /// <summary>
    /// Set text for Bill Amount. [Range: $0.00 - $9999.99]
    /// </summary>
    /// <param name="amount">Bill amount ($).</param>
    public void SetBillAmountText(float amount)
    {
        billAmountText.text = FormatText(amount, BILL_AMOUNT_TEXT_SIZE);
    }

    /// <summary>
    /// Set text for Tip Percentage. [Range: 0% - 100%]
    /// </summary>
    /// <param name="percentage">Tip percentage (%).</param>
    public void SetTipPercentageText(float percentage)
    {
        tipPercentageText.text = $"{percentage.ToString("0")}%";
    }

    /// <summary>
    /// Set text for Split. [Range: 1 Person - 10 People]
    /// </summary>
    /// <param name="split">Split (No. of People).</param>
    public void SetSplitText(int split)
    {
        string peopleString = split == 1 ? "Person" : "People";
        splitText.text = $"{split} {peopleString}";
    }

    /// <summary>
    /// Set text for Total Bill Amount. [Range: $0.00 - $9999.99]
    /// </summary>
    /// <param name="amount">Total Bill amount ($).</param>
    public void SetTotalBillAmountText(float amount)
    {
        totalBillAmountText.text = FormatText(amount, VALUE_TEXT_SIZE);
    }

    /// <summary>
    /// Set text for Total Tip Amount. [Range: $0.00 - $9999.99]
    /// </summary>
    /// <param name="amount">Total Tip amount ($).</param>
    public void SetTotalTipAmountText(float amount)
    {
        totalTipAmountText.text = FormatText(amount, VALUE_TEXT_SIZE);
    }

    /// <summary>
    /// Set text for Total Bill Per Person. [Range: $0.00 - $9999.99]
    /// </summary>
    /// <param name="amount">Total Bill Per Person ($).</param>
    public void SetTotalBillPerPersonText(float amount)
    {
        totalBillPerPersonText.text = FormatText(amount, VALUE_TEXT_SIZE);
    }

    /// <summary>
    /// Set text for Tip Per Person. [Range: $0.00 - $9999.99]
    /// </summary>
    /// <param name="amount">Tip Per Person ($).</param>
    public void SetTipPerPersonText(float amount)
    {
        tipPerPersonText.text = FormatText(amount, VALUE_TEXT_SIZE);
    }

    /// <summary>
    /// Format currency ($) text.
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="mainFontSize">Main font size.</param>
    /// <returns></returns>
    private string FormatText(float amount, int mainFontSize)
    {
        string fullAmount = $"{amount.ToString("0.00")}";
        string dollarAmount = fullAmount.Substring(0, fullAmount.Length - 3);
        string centsAmount = fullAmount.GetLast(3);

        return $"<size={mainFontSize}>${dollarAmount}</size><size={mainFontSize / 2}>{centsAmount}</size>";
    }
}
