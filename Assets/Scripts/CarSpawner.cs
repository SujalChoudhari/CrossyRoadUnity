using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Car
    {
        public GameObject carPrefab; // The car prefab to spawn
        public float spawnProbability; // The probability of this car being spawned
    }

    public List<Car> cars; // List of car prefabs with their probabilities
    public float spawnInterval = 3.0f; // Time interval between spawns

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnCar();
            timer = spawnInterval * Random.Range(0.8f, 1.2f);
        }
    }

    void SpawnCar()
    {
        float totalProbability = 0f;
        foreach (Car car in cars)
        {
            totalProbability += car.spawnProbability;
        }

        float randomPoint = Random.value * totalProbability;

        foreach (Car car in cars)
        {
            if (randomPoint < car.spawnProbability)
            {
                Instantiate(car.carPrefab, transform.position, transform.rotation);
                return;
            }
            else
            {
                randomPoint -= car.spawnProbability;
            }
        }
    }
}
