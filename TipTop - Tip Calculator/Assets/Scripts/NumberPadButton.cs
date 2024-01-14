using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberPadButton : PadButton
{
    [Header("Number Pad Button"), Space(8)]
    [SerializeField] protected TMP_Text numberPadText;
    [SerializeField] protected int number;

    protected override void Start()
    {
        base.Start();
        SetNumberPadText(number);
    }

    private void OnValidate()
    {
        //SetNumberPadText(number);
    }

    protected void SetNumberPadText(int num)
    {
        numberPadText.text = $"{num}";
    }

    public void InputNumber()
    {
        numberPad.AddDigit(number);
    }
}
