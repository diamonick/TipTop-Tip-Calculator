using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StringExtensionMethods;

public class TipCalculatorUI : MonoBehaviour
{
    // Tip Calculator Instance
    private TipCalculator TC;

    // Constants
    private const int NUM_OF_DECIMAL_PLACES = 2;

    [Header("UI")]
    [SerializeField] private TMP_Text billAmountText;
    [SerializeField] private TMP_Text tipPercentageText;
    [SerializeField] private TMP_Text splitText;

    [SerializeField] private TMP_Text totalBillAmountText;
    [SerializeField] private TMP_Text totalTipAmountText;
    [SerializeField] private TMP_Text totalBillPerPersonText;
    [SerializeField] private TMP_Text tipPerPersonText;

    [Header("Sliders"), Space(8)]
    public Slider tipPercentageSlider;
    public Slider splitSlider;

    private void Start()
    {
        TC = TipCalculator.Instance;

        tipPercentageSlider.value = TC.TipPercentage;
        splitSlider.value = TC.Split;
    }

    /// <summary>
    /// Set text for Bill Amount. [Range: $0.00 - $9999.99]
    /// </summary>
    /// <param name="amount">Bill amount ($).</param>
    public void SetBillAmountText(float amount)
    {
        billAmountText.text = FormatText(amount, 200);
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
        totalBillAmountText.text = FormatText(amount, 128);
    }

    /// <summary>
    /// Set text for Total Tip Amount. [Range: $0.00 - $9999.99]
    /// </summary>
    /// <param name="amount">Total Tip amount ($).</param>
    public void SetTotalTipAmountText(float amount)
    {
        totalTipAmountText.text = FormatText(amount, 128);
    }

    /// <summary>
    /// Set text for Total Bill Per Person. [Range: $0.00 - $9999.99]
    /// </summary>
    /// <param name="amount">Total Bill Per Person ($).</param>
    public void SetTotalBillPerPersonText(float amount)
    {
        totalBillPerPersonText.text = FormatText(amount, 128);
    }

    /// <summary>
    /// Set text for Tip Per Person. [Range: $0.00 - $9999.99]
    /// </summary>
    /// <param name="amount">Tip Per Person ($).</param>
    public void SetTipPerPersonText(float amount)
    {
        tipPerPersonText.text = FormatText(amount, 128);
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
