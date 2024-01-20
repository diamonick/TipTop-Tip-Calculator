using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StringExtensionMethods;

public class NumberPad : MonoBehaviour
{
    private const int BILL_AMOUNT_CHAR_LIMIT = 6;

    [Header("Number Pad")]
    [SerializeField] private string billAmountInput;
    [SerializeField] private PadButton[] numpadButtons;

    public void UpdateButtonColors()
    {
        foreach (PadButton pb in numpadButtons)
        {
            pb.SetButtonColors();
        }
    }

    /// <summary>
    /// Add numerical digit to the Bill Amount field.
    /// </summary>
    /// <param name="number">The digit to add to the Bill Amount field.</param>
    public void AddDigit(int number)
    {
        // Return early if the Bill Amount input field contains at least 6 digits.
        if (billAmountInput.Length >= BILL_AMOUNT_CHAR_LIMIT)
            return;

        billAmountInput = billAmountInput.Insert(billAmountInput.Length, $"{number}");
        UpdateBillAmount();
    }

    /// <summary>
    /// Remove leftmost digit from the Bill Amount field.
    /// </summary>
    public void RemoveDigit()
    {
        // Return early if the Bill Amount input field is ($0.00).
        if (billAmountInput.Length <= 0)
            return;

        billAmountInput = billAmountInput.Remove(billAmountInput.Length - 1);
        UpdateBillAmount();
    }

    /// <summary>
    /// Remove leftmost digit from the Bill Amount field.
    /// </summary>
    public void ClearBillAmount()
    {
        // Return early if the Bill Amount input field is ($0.00).
        if (billAmountInput.Length <= 0)
            return;

        billAmountInput = "";
        UpdateBillAmount();
    }

    /// <summary>
    /// Update the Bill Amount field.
    /// </summary>
    private void UpdateBillAmount()
    {
        float bill;

        if (billAmountInput.IsEmpty())
        {
            bill = 0f;
            TipCalculator.Instance.SetBillAmount(bill);
            return;
        }

        // Parse the Bill Amount string into a float value. If TRUE, set the Bill Amount.
        if (float.TryParse(billAmountInput, out bill))
        {
            if (bill == 0f)
            {
                billAmountInput = "";
            }
            else
            {
                bill = bill / 100f;
                TipCalculator.Instance.SetBillAmount(bill);
            }
        }
    }
}
