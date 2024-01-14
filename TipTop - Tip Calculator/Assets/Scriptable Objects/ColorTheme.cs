using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Color Theme", menuName = "Color Theme")]
public class ColorTheme : ScriptableObject
{
    [Header("Gradients")]
    public Gradient mainGradent;
    public Gradient lightBackgroundGradent;
    public Gradient darkBackgroundGradent;

    [Header("Colors"), Space(8)]
    public Color primaryColor;
    public Color secondaryColor;
    public Color tertiaryColor;
}
