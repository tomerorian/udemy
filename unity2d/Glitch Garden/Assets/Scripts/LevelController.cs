using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject lostLabel;
    [SerializeField] AudioClip winSFX;
    [SerializeField] float waitToLoad = 4f;

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        lostLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerDestroyed()
    {
        numberOfAttackers--;
        TestAndEndLevel();
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
        TestAndEndLevel();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (var spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }

    private void TestAndEndLevel()
    {
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    private IEnumerator HandleWinCondition()
    {
        AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position);
        winLabel.SetActive(true);

        yield return new WaitForSeconds(waitToLoad);

        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        lostLabel.SetActive(true);
        Time.timeScale = 0;
    }
}
