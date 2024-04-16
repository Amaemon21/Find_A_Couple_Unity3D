using System;
using UnityEngine;

public class TransportationController : MonoBehaviour
{
    [SerializeField] private Transform _resetPosition;

    [Space(10)]
    [SerializeField] private Transform _fistPlatform;
    [SerializeField] private Transform _secondPlatform;

    [Space(10)]
    [SerializeField] private PlatformController _platformController;

    public bool IsFistEmpty { get; private set; } = true;
    public bool IsSecondEmpty { get; private set; } = true;

    public event Action SoundChanged;

    private void OnEnable()
    {
        _platformController.DestoryChanged += OnDestoryChanged;
    }

    private void OnDisable()
    {
        _platformController.DestoryChanged -= OnDestoryChanged;
    }

    public void SetAnimalToPlatform(Animal animal)
    {
        if (!IsFistEmpty && !IsSecondEmpty)
            return;

        animal.Rigidbody.velocity = Vector3.zero;
        animal.transform.rotation = Quaternion.identity;

        if (IsFistEmpty)
        {
            animal.transform.position = _fistPlatform.position;
            animal.SetFist();
            IsFistEmpty = false;
        }
        else if (!IsFistEmpty && IsSecondEmpty)
        {
            animal.transform.position = _secondPlatform.position;
            animal.SetSecond();
            IsSecondEmpty = false;
        }

        SoundChanged?.Invoke();
    }

    public void ResetAnimalToPlatform(Animal animal)
    {
        if (IsFistEmpty && IsSecondEmpty)
            return;

        animal.transform.Rotate(0f, 180, 0f);

        if (animal.IsFist)
        {
            _platformController.ResetFist();
            animal.transform.position = _resetPosition.position;
            IsFistEmpty = true;
        }
        else if (!animal.IsFist)
        {
            _platformController.ResetSecond();
            animal.transform.position = _resetPosition.position;
            IsSecondEmpty = true;
        }
    }

    private void OnDestoryChanged()
    {
        IsFistEmpty = true;
        IsSecondEmpty = true;
    }
}