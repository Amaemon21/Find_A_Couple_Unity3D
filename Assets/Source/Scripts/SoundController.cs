using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private TransportationController _transportationController;

    [Space(5)]
    [SerializeField] private AudioClip _setClip;

    [Space(10)]
    [Header("AudioSource")]
    [SerializeField] private AudioSource _auioSourceBackground;

    [Space(5)]
    [SerializeField] private AudioSource _auioSourceSet;

    private void OnEnable() => _transportationController.SoundChanged += OnSoundSetChanged;
    private void OnDisable() => _transportationController.SoundChanged -= OnSoundSetChanged;

    private void OnSoundSetChanged()
    {
        _auioSourceSet.PlayOneShot(_setClip);
    }
}