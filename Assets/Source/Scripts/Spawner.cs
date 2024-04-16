using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Space(10)]
    [SerializeField] private TransportationController _controller;
    [SerializeField] private CheckingAnimalFallen _checkingAnimalFallen;
    [SerializeField] private Score _score;

    [Space(10)]
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _offsetSpawnPosition;

    [Space(10)]
    [SerializeField] private float _startSpawnStep = 2f;

    [Space(10)]
    [SerializeField] private List<Animal> _animalPrefabs = new();

    private List<GameObject> _spawnedAnimals = new();
    private float _currentStep;
    private Transform _transform;
    private bool _isWorking = true;

    public void Restart()
    {
        StartCoroutine(RestartLevelRewarded());
    }

    private void Awake()
    {
        _currentStep = _startSpawnStep;
        _transform = transform;

        StartCoroutine(SpawnAnimals());
    }

    private void InstantiateAnimal()
    {
        int randAnimal = Random.Range(0, _animalPrefabs.Count);
        float randPosition = Random.Range(-_offsetSpawnPosition, _offsetSpawnPosition);
        Vector3 positionAnimal = new Vector3(randPosition, _spawnPosition.position.y, _spawnPosition.position.z);

        Animal animal = Instantiate(_animalPrefabs[randAnimal], positionAnimal, _transform.rotation, _transform);
        _spawnedAnimals.Add(animal.gameObject);
        animal.Init(_controller);
    }

    private IEnumerator SpawnAnimals()
    {
        while (_isWorking)
        {
            InstantiateAnimal();
            yield return new WaitForSeconds(_currentStep);
        }
    }

    private IEnumerator RestartLevelRewarded()
    {
        foreach(var animal in _spawnedAnimals)
        {
            Destroy(animal);
        }

        _spawnedAnimals.Clear();
        _score.RestartRewardGame();

        yield return new WaitForSeconds(5f);
        _isWorking = true;
        StartCoroutine(SpawnAnimals());
    }

    private void OnEnable() => _checkingAnimalFallen.GameOverChanged += OnGameOverChanged;
    private void OnDisable() => _checkingAnimalFallen.GameOverChanged -= OnGameOverChanged;
    private void OnGameOverChanged()
    {
        StopCoroutine(SpawnAnimals());
        _isWorking = false;
    }
}