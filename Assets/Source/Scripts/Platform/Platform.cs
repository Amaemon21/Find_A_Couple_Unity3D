using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Platform : MonoBehaviour
{
    [SerializeField] private PlatformController _platformController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Animal>(out Animal animal))
        {
            _platformController.InitAnimal(animal);
        }
    }
}