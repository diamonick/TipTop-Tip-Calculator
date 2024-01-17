using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handle : MonoBehaviour
{
    [Header("Handle")]
    [SerializeField] private Animator animator;

    /// <summary>
    /// Call this method when the button is pressed.
    /// </summary>
    public void OnHandlePressed()
    {
        animator.SetBool("Selected?", true);
    }

    /// <summary>
    /// Call this method when the button is released.
    /// </summary>
    public void OnHandleReleased()
    {
        animator.SetBool("Selected?", false);
    }
}
