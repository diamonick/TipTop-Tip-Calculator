using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [Header("Settings Menu")]
    [SerializeField] private ColorThemeSlot[] colorThemeSlots;
    [SerializeField] private Animator animator;

    /// <summary>
    /// Show the Settings Menu.
    /// </summary>
    public void ShowSettingsMenu()
    {
        Activate();
        animator.SetBool("Show Menu?", true);
    }

    /// <summary>
    /// Hide the Settings Menu.
    /// </summary>
    public void HideSettingsMenu()
    {
        animator.SetBool("Show Menu?", false);
    }

    /// <summary>
    /// Activate this menu.
    /// </summary>
    public void Activate()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Deactivate this menu.
    /// </summary>
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
