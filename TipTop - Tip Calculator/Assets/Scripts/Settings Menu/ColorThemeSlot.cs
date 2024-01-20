using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JoshH.UI;
using UnityEngine.EventSystems;

public class ColorThemeSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Tip Calculator Instance
    private TipCalculator TC;

    [Header("Color Theme Slot")]
    [SerializeField] private ColorTheme colorTheme;
    [SerializeField] private UIGradient uiGradient;
    [SerializeField] private GameObject checkmark;
    [SerializeField] private Image blurShadow;
    [SerializeField] private Animator animator;
    public ColorTheme ColorTheme => colorTheme;
    [SerializeField] private bool isChecked;

    private void Start()
    {
        TC = TipCalculator.Instance;

        InitializeSlot();
    }

    private void InitializeSlot()
    {
        uiGradient.LinearGradient = colorTheme.mainGradent;
        blurShadow.color = TC.Settings.ColorThemePref.primaryColor;
        blurShadow.color *= new Color(1f, 1f, 1f, 0.25f);

        if (isChecked)
        {
            Check();
        }
        else
        {
            Uncheck();
        }
    }

    public void Check()
    {
        isChecked = true;
        checkmark.SetActive(true);

        TC.Settings.SetColorTheme(this);
    }

    public void Uncheck()
    {
        isChecked = false;
        checkmark.SetActive(false);
    }

    #region On Pointer Method(s)
    public void OnPointerDown(PointerEventData eventData)
    {
        animator.SetBool("Pressed?", true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        animator.SetBool("Pressed?", false);
    }
    #endregion
}
