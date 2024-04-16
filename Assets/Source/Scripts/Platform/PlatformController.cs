using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _destroyForSeconds;
    [SerializeField] private float _reductionDuration;

    private Animal _fistAnimal = null;
    private Animal _secondAnimal = null;

    public event Action AddScoreChanged;
    public event Action DestoryChanged;

    public void InitAnimal(Animal animal)
    {
        if (_fistAnimal == null) _fistAnimal = animal;
        else if (_secondAnimal == null && _fistAnimal != null) _secondAnimal = animal;

        Checking();
    }

    public void ResetFist() => _fistAnimal = null;
    public void ResetSecond() => _secondAnimal = null;

    private void Update()
    {
        if (_fistAnimal == null) return;
        if (_secondAnimal == null) return;

        if (_fistAnimal.transform.localScale == new Vector3(0, 0, 0))
        {
            Destroy(_fistAnimal.gameObject);
            Destroy(_secondAnimal.gameObject);

            DestoryChanged?.Invoke();
            AddScoreChanged?.Invoke();
        }
    }

    private void Checking()
    {
        if (_fistAnimal == null) return;
        if (_secondAnimal == null) return;

        if (_fistAnimal.EnumAnimal == _secondAnimal.EnumAnimal)
        {
            StartCoroutine(DestoryAnimals());
        }
    }

    private IEnumerator DestoryAnimals()
    {
        yield return new WaitForSeconds(_destroyForSeconds);

        ShrinkObject(_fistAnimal, _reductionDuration, new Vector3(0, 0, 0));
        ShrinkObject(_secondAnimal, _reductionDuration, new Vector3(0, 0, 0));
    }

    private void ShrinkObject(Animal animal, float duration, Vector3 targetScale)
    {
        animal.transform.DOScale(targetScale, duration);
    }
}