using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshotter : MonoBehaviour
{
    public int count = 0;
    public bool enableScreenshot;

    private void Update()
    {
        if (Input.touchCount > 0 && enableScreenshot)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ScreenCapture.CaptureScreenshot(Application.dataPath + $"/Screenshots/TipTop_Iphone_5.5_Photo{count++}.png");
            }
        }
    }
}