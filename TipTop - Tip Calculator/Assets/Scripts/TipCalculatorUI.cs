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
        string fullBillAmount = $"{amount.ToString("0.00")}";
        string dollarAmount = fullBillAmount.Substring(0, fullBillAmount.Length - 3);
        string centsAmount = fullBillAmount.GetLast(3);

        billAmountText.text = $"<size=200>${dollarAmount}</size><size=100>{centsAmount}</size>";
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
}
