using System;
using UnityEngine;

public class CheckingAnimalFallen : MonoBehaviour
{
    public event Action GameOverChanged;

    private void OnTriggerEnter(Collider other)
    {
        GameOverChanged?.Invoke();
        Destroy(other.gameObject);
    }
}