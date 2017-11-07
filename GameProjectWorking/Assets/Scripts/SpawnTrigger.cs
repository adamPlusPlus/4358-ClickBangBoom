using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour {

    public int spawnCount;
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 1.0f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating("Spawn", 0.5f, spawnTime);
           // InvokeRepeating("Spawn", spawnTime, spawnTime);
           //InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            //InvokeRepeating("Spawn", 0.5f, spawnTime);
            // InvokeRepeating("Spawn", spawnTime, spawnTime);
            //InvokeRepeating("Spawn", spawnTime, spawnTime);
        }
    }

    void Spawn()
    {
        //no more spawns after spanCount enemies have appeared
        if (spawnCount<=0)
        {
            Destroy(gameObject);
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        spawnCount--;
    }
}
