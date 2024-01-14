using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PadButton : MonoBehaviour
{
    // Tip Calculator Instance
    protected TipCalculator TC;

    [Header("Pad Button")]
    [SerializeField] protected NumberPad numberPad;
    [SerializeField] protected Animator animator;

    protected virtual void Start()
    {
        TC = TipCalculator.Instance;
    }

    /// <summary>
    /// Call this method when the button is pressed.
    /// </summary>
    public virtual void OnButtonPressed()
    {
        animator.SetBool("Pressed?", true);
    }

    /// <summary>
    /// Call this method when the button is released.
    /// </summary>
    public virtual void OnButtonReleased()
    {
        animator.SetBool("Pressed?", false);
    }
}
