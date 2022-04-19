using UnityEngine;

public class SaveController
{
    private static string RESULT = "Result";
    private static string SECONDS = "Seconds";

    public static bool isHasSave => PlayerPrefs.HasKey(RESULT);

    public static void Save(bool res, int sec)
    {
        PlayerPrefs.SetInt(RESULT, res ? 1 : 0);
        PlayerPrefs.SetInt(SECONDS, sec);
    }

    public static SaveData Load()
    {
        SaveData data;
        if (PlayerPrefs.HasKey(SECONDS))
        {
            data = new SaveData
            {
                res = PlayerPrefs.GetInt(RESULT) == 1 ? true : false,
                sec = PlayerPrefs.GetInt(SECONDS)
            };
            return data;
        }
        else
        {
            return null;
        }
    }
}
