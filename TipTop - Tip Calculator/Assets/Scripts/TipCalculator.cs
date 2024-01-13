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
    [SerializeField] private float tipPercentage;
    [SerializeField] private int split;

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

    [Header("UI"), Space(8)]
    public TipCalculatorUI UI;
    [SerializeField] private Slider tipPercentageSlider;
    [SerializeField] private Slider splitSlider;
    [SerializeField] private Color colorPref;
    public Color ColorPreference { get { return colorPref; } }

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
        tipPercentageSlider.value = tipPercentage;
        UI.SetSplitText(split);
        splitSlider.value = split;
    }

    private void Update()
    {
        //PerformTipCalculations();
    }

    #region Tip Calculation Method(s)
    public void PerformTipCalculations()
    {
        CalculateTotalBillAmount();
        CalculateTotalTipAmount();
        CalculateTotalBillPerPerson();
        CalculateTipPerPerson();
    }

    public void SetTipPercentage()
    {
        tipPercentage = tipPercentageSlider.value;
        UI.SetTipPercentageText(tipPercentage);
    }

    public void SetSplit()
    {
        split = (int)splitSlider.value;
        UI.SetSplitText(split);
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
