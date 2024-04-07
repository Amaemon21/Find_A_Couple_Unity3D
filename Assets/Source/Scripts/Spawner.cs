using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Animal> _animals = new();

    [SerializeField] private float _maxSpawnedAnimals = 10;

    private float _spawnedAnimal = 0;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;

        StartCoroutine(SpawnAnimals());
    }

    private void InstantiateAnimal()
    {
        int randAnimal = Random.Range(0, _animals.Count - 1);

        Instantiate(_animals[randAnimal], _transform.position, _transform.rotation, _transform);
        _spawnedAnimal++;
    }

    private IEnumerator SpawnAnimals()
    {
        bool isWorking = true;

        while (isWorking)
        {
            if (_spawnedAnimal < _maxSpawnedAnimals)
            {
                InstantiateAnimal();
            }
            else
            {
                isWorking = false;
            }

            yield return new WaitForSeconds(1f);
        }
    }
}