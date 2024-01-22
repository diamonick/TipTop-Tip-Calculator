using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPrefs : MonoBehaviour
{
    // Constants
    private const string COLOR_THEME_ID_KEY = "Color Theme ID";
    private const string DARK_MODE_ID_KEY = "Dark Mode ID";
    private const string ROUND_TIP_ID_KEY = "Round Tip ID";
    private const string ROUND_TOTAL_ID_KEY = "Round Total ID";

    #region Save/Load Method(s)
    #region Color Theme
    /// <summary>
    /// Save the user's preferred color theme.
    /// </summary>
    /// <param name="id">Color Theme ID</param>
    public static void SaveColorThemeID(int id)
    {
        PlayerPrefs.SetInt(COLOR_THEME_ID_KEY, id);
    }

    /// <summary>
    /// Loads the user's preferred color theme.
    /// </summary>
    /// <returns> The Color Theme ID. If the key doesn't exist, the color theme ID returns 0.</returns>
    public static int LoadColorThemeID()
    {
        return PlayerPrefs.GetInt(COLOR_THEME_ID_KEY, 0);
    }
    #endregion

    #region Dark Mode
    /// <summary>
    /// Saves the user's Dark Mode setting.
    /// </summary>
    /// <param name="boolID">Dark Mode boolean ID</param>
    public static void SaveDarkModeID(bool boolID)
    {
        PlayerPrefs.SetInt(DARK_MODE_ID_KEY, boolID ? 1 : 0);
    }

    /// <summary>
    /// Loads the user's Dark Mode setting.
    /// </summary>
    /// <returns> The Dark Mode ID. If the key doesn't exist, the dark mode ID returns 0 (False).</returns>
    public static bool LoadDarkModeID()
    {
        return PlayerPrefs.GetInt(DARK_MODE_ID_KEY) == 1;
    }
    #endregion

    #region Round Tip
    /// <summary>
    /// Saves the user's preferred rounding type for Round Tip.
    /// </summary>
    /// <param name="id">Round Tip ID</param>
    public static void SaveRoundTipID(int id)
    {
        PlayerPrefs.SetInt(ROUND_TIP_ID_KEY, id);
    }

    /// <summary>
    /// Loads the user's preferred rounding type for Round Tip.
    /// </summary>
    /// <returns> The Round Tip ID. If the key doesn't exist, the round tip ID returns 0 (Exact).</returns>
    public static int LoadRoundTipID()
    {
        return PlayerPrefs.GetInt(ROUND_TIP_ID_KEY, 0);
    }
    #endregion

    #region Round Total
    /// <summary>
    /// Saves the user's preferred rounding type for Round Total.
    /// </summary>
    /// <param name="id">Round Total ID</param>
    public static void SaveRoundTotalID(int id)
    {
        PlayerPrefs.SetInt(ROUND_TOTAL_ID_KEY, id);
    }

    /// <summary>
    /// Loads the user's preferred rounding type for Round Total.
    /// <summary>
    /// <returns> The Round Total ID. If the key doesn't exist, the round total ID returns 0 (Exact).</returns>
    public static int LoadRoundTotalID()
    {
        return PlayerPrefs.GetInt(ROUND_TOTAL_ID_KEY, 0);
    }
    #endregion

    /// <summary>
    /// Deletes the user's preferences.
    /// </summary>
    public static void DeleteUserPreferences()
    {
        PlayerPrefs.DeleteKey(COLOR_THEME_ID_KEY);
        PlayerPrefs.DeleteKey(DARK_MODE_ID_KEY);
        PlayerPrefs.DeleteKey(ROUND_TIP_ID_KEY);
        PlayerPrefs.DeleteKey(ROUND_TOTAL_ID_KEY);
    }
    #endregion
}
