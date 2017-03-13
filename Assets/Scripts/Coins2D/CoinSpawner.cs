using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

    [SerializeField] private float upForce, sideForceCap, spawnDelay;
    [SerializeField] private int coinValue;

    private float spawnDelayTimer;

	void Start () {
        spawnDelayTimer = spawnDelay;
	}
	
	void Update () {
        if (spawnDelayTimer > 0.0f)
            spawnDelayTimer -= Time.deltaTime;
	}

    void FixedUpdate()
    {
        if(spawnDelayTimer <= 0.0f)
        {

        }
    }
}
