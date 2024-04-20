using NTC.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerForMainMenu : MonoBehaviour
{
    [Space(10)]
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _offsetSpawnPosition;

    [Space(10)]
    [SerializeField] private float _startSpawnStep = 2f;

    [Space(10)]
    [SerializeField] private List<GameObject> _animalPrefabs = new();

    private Transform _transform;
    private bool _isWorking = true;

    private void Awake()
    {
        _transform = transform;

        StartCoroutine(SpawnAnimals());
    }

    private void InstantiateAnimal()
    {
        int randAnimal = Random.Range(0, _animalPrefabs.Count);
        float randPosition = Random.Range(-_offsetSpawnPosition, _offsetSpawnPosition);
        Vector3 positionAnimal = new Vector3(randPosition, _spawnPosition.position.y, _spawnPosition.position.z);

        NightPool.Spawn(_animalPrefabs[randAnimal], positionAnimal, _transform.rotation, _transform);
    }

    private IEnumerator SpawnAnimals()
    {
        while (_isWorking)
        {
            InstantiateAnimal();
            yield return new WaitForSeconds(_startSpawnStep);
        }
    }
}