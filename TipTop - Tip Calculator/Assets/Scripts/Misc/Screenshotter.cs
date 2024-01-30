using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshotter : MonoBehaviour
{
    public enum Display
    {
        iPhone6_5 = 0,      // iPhone - 6.5" Display
        iPhone5_5 = 1,      // iPhone - 5.5" Display
        iPadPro_6Gen = 2,   // iPad Pro (6th Gen) - 12.9" Display
        iPadPro_2Gen = 3,   // iPad Pro (2nd Gen) - 12.9" Display
    }

    public bool enableScreenshot;
    public Display display;
    public int count = 0;

    private void Update()
    {
        if (Input.touchCount > 0 && enableScreenshot)
        {
            string displayName = GetDisplayName();
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                ScreenCapture.CaptureScreenshot(Application.dataPath + $"/Screenshots/TipTop_{displayName}_Photo{count++}.png");
            }
        }
    }

    private string GetDisplayName()
    {
        string displayName = "";

        switch (display)
        {
            // iPhone - 6.5" Display
            case Display.iPhone6_5:
                displayName = "iPhone_6.5";
                break;
            // iPhone - 5.5" Display
            case Display.iPhone5_5:
                displayName = "iPhone_5.5";
                break;
            // iPad Pro (6th Gen) - 12.9" Display
            case Display.iPadPro_6Gen:
                displayName = "iPadPro_(6th Gen)";
                break;
            // iPad Pro (2nd Gen) - 12.9" Display
            case Display.iPadPro_2Gen:
                displayName = "iPadPro_(2nd Gen)";
                break;
        }

        return displayName;
    }
}