using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleVehicleSpawner : MonoBehaviour
{

    [SerializeField]
    protected List<GameObject> vehiclePrefabs;

    [SerializeField]
    protected float minSpawnTime = 1f;
    [SerializeField]
    protected float maxSpawnTime = 3f;

    private void Start()
    {
        StartCoroutine(SpawnVehicle());
    }

    IEnumerator SpawnVehicle()
    {
        while (true)
        {
            float spawnTime = Random.Range(this.minSpawnTime, this.maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);
            int prefabIndex = Random.Range(0, this.vehiclePrefabs.Count);
            GameObject vehiclePrefab = this.vehiclePrefabs[prefabIndex];
            Instantiate(vehiclePrefab, transform.position, transform.rotation);
        }
    }

}
