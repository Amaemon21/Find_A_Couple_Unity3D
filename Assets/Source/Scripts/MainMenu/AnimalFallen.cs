using NTC.Pool;
using UnityEngine;

public class AnimalFallen : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        NightPool.Despawn(other.gameObject);
    }
}