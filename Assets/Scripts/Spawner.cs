using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject pickUp;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public int counter = 4;
    public bool isActive;

    public static Spawner Instance { get; private set; }
    void Awake()
    {


        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;

        }
    }
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (isActive == false)
        {
            SpawnerReady();
            isActive = true;
        }
    }

    void Spawn()
    {

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(pickUp, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    void SpawnerReady()
    {
        if (counter == 4 || counter == 3 || counter == 2 || counter == 1)
        {
            Spawn();
            isActive = true;
        }
        if (counter == 0)
        {
            Debug.Log("Ganaste");
        }

    }
}
