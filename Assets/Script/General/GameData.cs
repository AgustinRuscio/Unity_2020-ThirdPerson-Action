using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameData
{
    public static string saveLvl(string lvlName)
    {
        PlayerPrefs.SetString("Level", lvlName);

        return lvlName;
    }

    public static LevelDetection GetLvlEnum(string lvlName)
    {
        switch (lvlName)
        {
            case "Lobby":
                return LevelDetection.Menu;

            case "Tutorial":
                return LevelDetection.Tutorial;

            default:
                return LevelDetection.Level;
        }
    }
}
