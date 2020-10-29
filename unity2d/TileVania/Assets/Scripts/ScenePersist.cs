using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is not a good solution. It has a major issue when loading a new scene since Update is called after Awake and then
// the ScenePersist of the next level is destroying itself
public class ScenePersist : MonoBehaviour
{
    int sceneBuildIndex;

    private void Awake()
    {
        int gameObjectCount = FindObjectsOfType<ScenePersist>().Length;

        if (gameObjectCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != sceneBuildIndex)
        {
            Destroy(gameObject);
        }
    }
}
