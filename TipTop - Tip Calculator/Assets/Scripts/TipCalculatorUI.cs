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

    private void Start()
    {
        TC = TipCalculator.Instance;
    }

    public void SetBillAmountText(float amount)
    {
        string fullBillAmount = $"{amount.ToString("0.00")}";
        string dollarAmount = fullBillAmount.Substring(0, fullBillAmount.Length - 3);
        string centsAmount = fullBillAmount.GetLast(3);

        billAmountText.text = $"<size=200>${dollarAmount}</size><size=100>{centsAmount}</size>";
    }

    public void SetTipPercentageText(float percentage)
    {
        float percent = percentage * 100f;
        tipPercentageText.text = $"{percent.ToString("0")}%";
    }

    public void SetSplitText(int split)
    {
        string peopleString = split == 1 ? "Person" : "People";
        splitText.text = $"{split} {peopleString}";
    }
}
