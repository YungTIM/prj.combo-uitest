using UnityEngine;

public static class GameConstants
{
    #region Colors
    public static Color COLOR_TEXT_P_ONE = Color.blue;
    public static Color COLOR_TEXT_P_TWO = Color.red;
    public static Color COLOR_TEXT_P_THR = Color.red;
    public static Color COLOR_TEXT_P_FOU = Color.red;
    #endregion

    #region GAME VALUES
    /// <summary>
    /// 
    /// </summary>
    #endregion

    //this needs to be refactored into a look table-lookup using json
    #region LocStrings 
    public static string loc_s_press_start = "PRESS START";

    public static string loc_s_arena = "ARENA";
    public static string loc_s_online = "ONLINE";
    public static string loc_s_dojo = "DOJO";
    public static string loc_s_lore = "LORE";
    public static string loc_s_settings = "SETTINGS";

    public static string loc_s_volleyball = "VOLLEYBALL";
    public static string loc_s_board = "BOARD THE PLATFORMS";
    public static string loc_s_target = "TARGET TEST";
    public static string loc_s_practice = "PRACTICE";

    public static string loc_s_choose = "CHOOSE YOUR FIGHTER";
    public static string loc_s_profile = "PROFILE";
    #endregion

    #region AnimStrings 
    public static string SHOW_ANIMATOR_PARAMETER = "show";
    public static string HIDE_ANIMATOR_PARAMETER = "hide";
    #endregion
}