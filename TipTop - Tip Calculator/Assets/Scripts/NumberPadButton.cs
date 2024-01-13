using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberPadButton : MonoBehaviour
{
    [Header("Number Pad Button")]
    [SerializeField] private TMP_Text numberPadText;
    [SerializeField] private int number;

    private void Start()
    {
        SetNumberPadText(number);
    }

    private void SetNumberPadText(int num)
    {
        numberPadText.text = $"{num}";
    }

    public void OnButtonPressed()
    {
        numberPadText.color = Color.white;
    }

    public void InputNumber()
    {
        //TipCalculator.Instance.userInterface.
    }
}
