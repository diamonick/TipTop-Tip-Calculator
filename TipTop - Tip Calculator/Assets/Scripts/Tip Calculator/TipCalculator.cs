using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipCalculator : MonoBehaviour
{
    // Tip Calculator Singleton
    public static TipCalculator Instance { get; private set; }

    [Header("Tip Calculator")]
    [SerializeField] private float billAmount;
    [SerializeField] private int tipPercentage;
    [SerializeField] private int split;

    public float BillAmount { get { return billAmount; } }
    public float TipPercentage { get { return tipPercentage; } }
    public float Split { get { return split; } }

    [SerializeField] private float totalBillAmount;
    [SerializeField] private float totalTipAmount;
    [SerializeField] private float totalBillPerPerson;
    [SerializeField] private float tipPerPerson;
    public float TotalBillAmount { get { return totalBillAmount; } }
    public float TotalTipAmount { get { return totalTipAmount; } }
    public float TotalBillPerPerson { get { return totalBillPerPerson; } }
    public float TipPerPerson { get { return tipPerPerson; } }

    [Header("User Interface"), Space(8)]
    public TipCalculatorUI UI;
    public SettingsMenu Settings;

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

        // Allow app to accept multiple touch inputs from the user.
        Input.multiTouchEnabled = true;
    }

    private void Start()
    {
        UI.SetBillAmountText(billAmount);
        UI.SetTipPercentageText(tipPercentage);
        UI.SetSplitText(split);
    }

    private void Update()
    {
        PerformTipCalculations();
    }

    #region Tip Calculation Method(s)
    /// <summary>
    /// Perform all necessary tip calculations.
    /// </summary>
    public void PerformTipCalculations()
    {
        CalculateTotalBillAmount();
        CalculateTotalTipAmount();
        CalculateTotalBillPerPerson();
        CalculateTipPerPerson();
    }

    public void SetBillAmount(float amount)
    {
        billAmount = amount;
        UI.SetBillAmountText(billAmount);
    }

    public void SetTipPercentage()
    {
        tipPercentage = (int)UI.tipPercentageSlider.value;
        UI.SetTipPercentageText(tipPercentage);
    }

    public void SetSplit()
    {
        split = (int)UI.splitSlider.value;
        UI.SetSplitText(split);
    }

    /// <summary>
    /// Calculate the Total Bill Amount.
    /// </summary>
    public void CalculateTotalBillAmount()
    {
        float result = billAmount * (1f + ((float)tipPercentage / 100f));
        totalBillAmount = result;
        UI.SetTotalBillAmountText(totalBillAmount);
    }

    /// <summary>
    /// Calculate the Total Tip Amount.
    /// </summary>
    public void CalculateTotalTipAmount()
    {
        float result = billAmount * ((float)tipPercentage / 100f);
        totalTipAmount = result;
        UI.SetTotalTipAmountText(totalTipAmount);
    }

    /// <summary>
    /// Calculate the Total Bill Per Person.
    /// </summary>
    public void CalculateTotalBillPerPerson()
    {
        float result = totalBillAmount / split;
        totalBillPerPerson = result;
        UI.SetTotalBillPerPersonText(totalBillPerPerson);
    }

    /// <summary>
    /// Calculate the Tip Per Person.
    /// </summary>
    public void CalculateTipPerPerson()
    {
        float result = totalTipAmount / split;
        tipPerPerson = result;
        UI.SetTipPerPersonText(tipPerPerson);
    }
    #endregion
}
