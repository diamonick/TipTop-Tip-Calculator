using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPad : MonoBehaviour
{
    private const int BILL_AMOUNT_CHAR_LIMIT = 6;

    [Header("Number Pad")]
    [SerializeField] private string billAmountInput;
    [SerializeField] private NumberPadButton[] numpadButtons;

    public void AppendBillAmount(int number)
    {
        if (billAmountInput.Length >= BILL_AMOUNT_CHAR_LIMIT)
            return;

        billAmountInput = billAmountInput.Insert(billAmountInput.Length, $"{number}");

        float bill;
        if (float.TryParse(billAmountInput, out bill))
        {
            bill = bill / 100f;
            TipCalculator.Instance.SetBillAmount(bill);
        }

    }
}
