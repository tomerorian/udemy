﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackerPrefabs;

    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackerPrefabs.Length);
        Spawn(attackerPrefabs[attackerIndex]);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(
                                    attacker,
                                    transform.position,
                                    transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
