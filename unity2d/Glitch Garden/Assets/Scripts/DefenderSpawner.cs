using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    const string DEFENDER_PARENT_NAME = "Defenders";

    Defender defenderPrefab;
    GameObject defenderParent;

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defender)
    {
        defenderPrefab = defender;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        if (!defenderPrefab) { return;  }

        var starsDisplay = FindObjectOfType<StarsDisplay>();
        int defenderCost = defenderPrefab.GetStarCost();

        if (starsDisplay.HaveEnoughStars(defenderCost))
        {
            starsDisplay.SpendStars(defenderCost);
            SpawnDefender(gridPos);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);

        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 spawnPos)
    {
        if (!defenderPrefab) { return;  }

        Defender newDefender = Instantiate(
            defenderPrefab,
            spawnPos,
            Quaternion.identity) as Defender;

        newDefender.transform.parent = defenderParent.transform;
    }
}
