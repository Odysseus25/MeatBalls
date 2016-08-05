using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";
    const string MENU_ANIMATION_KEY = "menu_animation";

    public static void SetMasterVolume(float volume)
    {
        if (volume > 0f && volume < 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level < SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);  //use 1 as true
        }
        else
        {
            Debug.LogError("Level not in game");
        }
    }

    public static bool isLevelLocked(int level)
    {
        if (level < SceneManager.sceneCountInBuildSettings - 1)
        {
            bool unlocked = (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1);
            return unlocked;
        }
        else
        {
            Debug.LogError("Level not found in game");
            return false;
        }
    }

    public static void SetDifficulty(float diff)
    {
        if (diff >= 1f && diff <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        }
        else
        {
            Debug.LogError("Difficulty out of bounds");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void SetMenuAnimationState(bool state)
    {
        if (state)
        {
            PlayerPrefs.SetInt(MENU_ANIMATION_KEY, 1);  //use 1 as true
        }
        else
        {
            PlayerPrefs.SetInt(MENU_ANIMATION_KEY, 0);
        }
        Debug.Log("State saved");
    }

    public static bool GetMenuAnimationState()
    {
        bool enabled = (PlayerPrefs.GetInt(MENU_ANIMATION_KEY) == 1);
        return enabled;
    }
}