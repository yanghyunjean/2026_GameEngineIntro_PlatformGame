using UnityEngine;

public static class HighScore
{
    private const string KEY = "HighScore";

    public static int Load(int PlayScene)
    {
        return PlayerPrefs.GetInt(KEY + "_" + PlayScene, 0);
    }

    public static void TrySet(int PlayScene, int newScore)
    {
        if (newScore <= Load(PlayScene))
            return;

        PlayerPrefs.SetInt(KEY + "_" + PlayScene, newScore) ;
        PlayerPrefs.Save();

    }
}
