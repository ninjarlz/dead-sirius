﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulGenerator : MonoBehaviour
{
    public int ActiveSouls = 0;
    [SerializeField] private GameObject soulPrefab;
    [SerializeField] private int lowerRange;
    [SerializeField] private int upperRange;
    private int delay;
    List<Transform> SoulSpawns = new List<Transform>();
    private Transform spawnPoint;
    bool processingCouroutine = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Transform parent = GameObject.Find("Portals").transform;
        for (int i = 0; i < parent.childCount; i++)
        {
            SoulSpawns.Add(parent.GetChild(i));
            SoulSpawns[i].position = new Vector3(SoulSpawns[i].position.x, SoulSpawns[i].position.y + 15, SoulSpawns[i].position.z);
        }
        int randIndex = Random.Range(0, SoulSpawns.Count - 1);
        spawnPoint = SoulSpawns[randIndex];
        GameObject tyChuju = Instantiate(soulPrefab, spawnPoint.position, spawnPoint.rotation);
        tyChuju.transform.tag = "Soul";
        ActiveSouls++;
        StartCoroutine(SpawnSoul());
    }

    // Update is called once per frame
    void Update()
    {
        if (!processingCouroutine && ActiveSouls < 2)
        {
            StartCoroutine(SpawnSoul());
        }
    }

    private IEnumerator SpawnSoul()
    {
        processingCouroutine = true;
        delay = Random.Range(lowerRange, upperRange);
        yield return new WaitForSeconds(delay);
        int randIndex = Random.Range(0, SoulSpawns.Count - 1);
        spawnPoint = SoulSpawns[randIndex];
        GameObject tyChuju = Instantiate(soulPrefab, spawnPoint.position, spawnPoint.rotation);
        tyChuju.transform.tag = "Soul";

        ActiveSouls++;
        if (ActiveSouls < 2) StartCoroutine(SpawnSoul());
    }
}
