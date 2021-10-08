﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCoin : MonoBehaviour
{
    public Vector2 scaleRandomValue;

    private Transform Player;

    private void Awake()
    {
        Player = FindObjectOfType<TapController>().transform;
    }

    public void Spawn()
    {
        bool boxSpawned = false;
        while (!boxSpawned)
        {
            Vector2 spawnPosition = GameManager.Instance.GetRandomPosition();
            if(((Vector2)Player.position - spawnPosition).magnitude < 2)
            {
                continue;
            }
            else
            {
                transform.position = spawnPosition;
                Setup();
                boxSpawned = true;
            }
        }
    }

    private void Setup()
    {
        float xScale = Random.Range(scaleRandomValue.x, scaleRandomValue.y);
        float yScale = Random.Range(scaleRandomValue.x, scaleRandomValue.y);

        transform.localScale = new Vector2(xScale, yScale);
    }
}
