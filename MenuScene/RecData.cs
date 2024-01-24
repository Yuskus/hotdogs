using UnityEngine;
using UnityEngine.SceneManagement;

public static class RecData
{
    [SerializeField] private static int continueGame; //save1
    [SerializeField] private static int availableLevels; //save2
    [SerializeField] private static string soundChanged = ""; //save3
    [SerializeField] private static int[] lvlRec = new int[50]; //save4
    private static readonly string continueKey = "continueLevel"; //key1
    private static readonly string availableKey = "openLevels"; //key2
    private static readonly string stateSoundKey = "keyForSound"; //key3
    private static readonly string[] keyForLevel = new string[50] { "Rec_01", "Rec_02", "Rec_03", "Rec_04", "Rec_05", "Rec_06", "Rec_07", "Rec_08", "Rec_09", "Rec_10", "Rec_11", "Rec_12", "Rec_13", "Rec_14", "Rec_15", "Rec_16", "Rec_17", "Rec_18", "Rec_19", "Rec_20", "Rec_21", "Rec_22", "Rec_23", "Rec_24", "Rec_25", "Rec_26", "Rec_27", "Rec_28", "Rec_29", "Rec_30", "Rec_31", "Rec_32", "Rec_33", "Rec_34", "Rec_35", "Rec_36", "Rec_37", "Rec_38", "Rec_39", "Rec_40", "Rec_41", "Rec_42", "Rec_43", "Rec_44", "Rec_45", "Rec_46", "Rec_47", "Rec_48", "Rec_49", "Rec_50" }; //key4
    public static readonly int[] plans = new int[50] { 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1800, 1900, 2000, 2100, 2200, 2300, 2400, 2500, 2600, 2700, 2800, 2900, 2950, 3000, 3050, 3100, 3150, 3200, 3250, 3300, 3350, 3400, 3450, 3500, 3550, 3600, 3650, 3700, 3750, 3800, 3850, 3900, 3950, 4000, 4050, 4100, 4200 };
    public static readonly int canCookBurger = 10;
    public static readonly int canCookCola = 40;
    public static readonly int canCookDrink = 2;
    public static readonly int canCookFree = 5; //and 10-14
    public static readonly int canCookSauseG = 20;
    public static readonly int canCookOnion = 30;
    public static bool youCompletedTheGame = false;
    public static int theLastLevelIs = lvlRec.Length;
    public static int ContinueGame
    {
        get { return continueGame; }
        private set
        {
            if (value <= availableLevels && value < lvlRec.Length) { continueGame = value; }
            else if (value == lvlRec.Length) { youCompletedTheGame = true; }
        }
    }
    public static int AvailableLevels
    {
        get { return availableLevels; }
        private set
        {
            if (value < lvlRec.Length) { availableLevels = value; }
            else if (value == lvlRec.Length) { youCompletedTheGame = true; }
        }
    }
    public static void SaveLastLevel(int nowLevel)
    {
        ContinueGame = nowLevel + 1;
        PlayerPrefs.SetInt(continueKey, ContinueGame);
        PlayerPrefs.Save();
    }
    public static void LoadLastLevel()
    {
        if (PlayerPrefs.HasKey(continueKey)) { ContinueGame = PlayerPrefs.GetInt(continueKey); }
    }
    public static void SaveOpenedLevel(int openedLevel) //в конце каждого уровня при сохранении рекорда
    {
        if (AvailableLevels == openedLevel)
        {
            AvailableLevels++;
            PlayerPrefs.SetInt(availableKey, AvailableLevels);
            PlayerPrefs.Save();
        }
    }
    public static void LoadOpenedLevel() //в сцене меню
    {
        if (PlayerPrefs.HasKey(availableKey)) { AvailableLevels = PlayerPrefs.GetInt(availableKey); }
    }
    public static void SaveStateOfSound()
    {
        if (soundChanged == "false") { soundChanged = "true"; }
        else { soundChanged = "false"; }
        PlayerPrefs.SetString(stateSoundKey, soundChanged);
        PlayerPrefs.Save();
    }
    public static void LoadStateOfSound()
    {
        if (PlayerPrefs.HasKey(stateSoundKey)) { soundChanged = PlayerPrefs.GetString(stateSoundKey); }
        else { soundChanged = "true"; }
    }
    public static void DeleteRecords()
    {
        PlayerPrefs.DeleteAll();
        ContinueGame = 0;
        AvailableLevels = 0;
        for (int i = 0; i < lvlRec.Length; i++) { lvlRec[i] = 0; }
    }
    public static void CountAllLevelsRecords(out int sum)
    {
        sum = 0;
        for (int i = 0; i < lvlRec.Length; i++) { sum += lvlRec[i]; }
    }
    public static void LoadAllLevelsRecords()
    {
        for (int i = 0; i < lvlRec.Length; i++)
        {
            if (PlayerPrefs.HasKey(keyForLevel[i])) { lvlRec[i] = PlayerPrefs.GetInt(keyForLevel[i]); }
        }
    }
    public static void SaveMyRecord(int salary, int level)
    {
        if (salary > lvlRec[level])
        {
            lvlRec[level] = salary;
            PlayerPrefs.SetInt(keyForLevel[level], lvlRec[level]);
            PlayerPrefs.Save();
        }
    }
    public static int LoadMyRecord(int level)
    {
        return PlayerPrefs.GetInt(keyForLevel[level], 0);
    }
    public static void SavingAtTheEndOfLevel(int mySalary, int level, string key)
    {
        if (mySalary > plans[level])
        {
            SaveOpenedLevel(level);
            SaveLastLevel(level);
        }
        if (mySalary > lvlRec[level])
        {
            lvlRec[level] = mySalary;
            PlayerPrefs.SetInt(key, lvlRec[level]);
            PlayerPrefs.Save();
        }
    }
    public static void StartOrRetryLevel(int level)
    {
        ContinueGame = level;
        SceneManager.LoadScene("GameLevel1");
    }
    public static string MyRecordIs() => "Record: " + lvlRec[ContinueGame]; //ok
    public static string MyPlanIs() => "Plan: " + plans[ContinueGame]; //ok
    public static bool IsSoundChanged() => soundChanged == "false"; //ok
    public static bool IsAllLevelsCompleted() => lvlRec[^1] > plans[^1]; //ok
}
