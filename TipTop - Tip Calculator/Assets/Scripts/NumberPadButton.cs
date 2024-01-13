using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberPadButton : MonoBehaviour
{
    // Tip Calculator Instance
    private TipCalculator TC;

    [Header("Number Pad Button")]
    [SerializeField] private NumberPad numberPad;
    [SerializeField] private TMP_Text numberPadText;
    [SerializeField] private int number;
    [SerializeField] private Animator animator;

    private void Start()
    {
        TC = TipCalculator.Instance;
        SetNumberPadText(number);
    }

    private void SetNumberPadText(int num)
    {
        numberPadText.text = $"{num}";
    }

    public void OnButtonPressed()
    {
        animator.SetBool("Pressed?", true);
    }

    public void OnButtonReleased()
    {
        animator.SetBool("Pressed?", false);
    }

    public void InputNumber()
    {
        numberPadText.color = TC.ColorPreference;
        numberPad.AppendBillAmount(number);
    }
}
