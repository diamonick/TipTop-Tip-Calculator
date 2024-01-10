using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipCalculator : MonoBehaviour
{
    // Tip Calculator Singleton
    public static TipCalculator Instance { get; private set; }

    [Header("Tip Calculator")]
    [SerializeField] private float billAmount;
    [SerializeField] private float tipPercentage;
    [SerializeField] private int split;

    [Header("UI"), Space(8)]
    public TipCalculatorUI userInterface;
    public float BillAmount { get { return billAmount; } }
    public float TipPercentage { get { return tipPercentage; } }
    public float Split { get { return split; } }

    private float totalBillAmount;
    private float totalTipAmount;
    private float totalBillPerPerson;
    private float tipPerPerson;
    public float TotalBillAmount { get { return totalBillAmount; } }
    public float TotalTipAmount { get { return totalTipAmount; } }
    public float TotalBillPerPerson { get { return totalBillPerPerson; } }
    public float TipPerPerson { get { return tipPerPerson; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
            Debug.LogWarning($"WARNING: There can only be one TipCalculator instance.");
        }
    }

    #region Tip Calculation Method(s)
    public void PerformTipCalculations()
    {
        CalculateTotalBillAmount();
        CalculateTotalTipAmount();
        CalculateTotalBillPerPerson();
        CalculateTipPerPerson();
    }

    /// <summary>
    /// Calculate the Total Bill Amount.
    /// </summary>
    public void CalculateTotalBillAmount()
    {
        float result = billAmount * (1f + tipPercentage);
        totalBillAmount = result;
    }

    /// <summary>
    /// Calculate the Total Tip Amount.
    /// </summary>
    public void CalculateTotalTipAmount()
    {
        float result = billAmount * tipPercentage;
        totalTipAmount = result;
    }

    /// <summary>
    /// Calculate the Total Bill Per Person.
    /// </summary>
    public void CalculateTotalBillPerPerson()
    {
        float result = totalBillAmount / split;
        totalBillPerPerson = result;
    }

    /// <summary>
    /// Calculate the Tip Per Person.
    /// </summary>
    public void CalculateTipPerPerson()
    {
        float result = totalTipAmount / split;
        tipPerPerson = result;
    }
    #endregion
}
