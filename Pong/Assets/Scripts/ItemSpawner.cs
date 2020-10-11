using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    //Item Prefabs
    public GameObject extenderPrefabs;
    public GameObject fireBallPrefabs;
    //Time random
    public float maxTime = 5;
    public float minTime = 2;
    //time
    private float time;
    //sppawn time
    private float spawnTime;
    private bool stopSpawn;

    // Start is called before the first frame update
    void Start()
    {
        RandomTime();
        time = minTime;
        Debug.Log(spawnTime.ToString());
    }

    void FixedUpdate()
    {
        //ngitung waktu
        if (!stopSpawn)
        {
            time += Time.deltaTime;
        }
        if (time >= spawnTime)
        {
            SpawnObject();
            StopSpawn();
        }

    }
    void SpawnObject()
    {
        time = minTime;
        float randonItem = Random.Range(0.0f, 1.0f);
        if (randonItem < 1f)
        {
            Instantiate(fireBallPrefabs, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(extenderPrefabs, transform.position, transform.rotation);
        }
    }
    public void RandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
        stopSpawn = false;
    }
    void StopSpawn()
    {
        stopSpawn = true;
    }
}
