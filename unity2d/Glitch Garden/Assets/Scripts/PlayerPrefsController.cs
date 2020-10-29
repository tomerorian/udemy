using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 1f;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Trying to set master volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return Mathf.Clamp(PlayerPrefs.GetFloat(MASTER_VOLUME_KEY), MIN_VOLUME, MAX_VOLUME);
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Trying to set difficulty out of range");
        }
    }

    public static float GetDifficulty()
    {
        return Mathf.Clamp(PlayerPrefs.GetFloat(DIFFICULTY_KEY), MIN_DIFFICULTY, MAX_DIFFICULTY);
    }
}
