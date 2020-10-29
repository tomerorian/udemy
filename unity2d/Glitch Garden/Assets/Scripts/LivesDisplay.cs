using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int leastLives = 1;
    [SerializeField] int mostLives = 15;
    [SerializeField] int damagePerEnemy = 1;

    int lives;
    Text livesText;

    void Start()
    {
        lives = leastLives + Mathf.RoundToInt((mostLives - leastLives) * (1 - PlayerPrefsController.GetDifficulty()));
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void ReduceLife()
    {
        lives -= damagePerEnemy;
        UpdateDisplay();

        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
