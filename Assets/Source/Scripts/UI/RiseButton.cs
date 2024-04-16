using UnityEngine;
using UnityEngine.UI;
using YG;

public class RiseButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        Time.timeScale = 1;
        YandexGame.RewardVideoEvent += Rewarded;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }

    public void Rewarded(int id)
    {
        _spawner.Restart();
        YandexGame.RewVideoShow(1);
    }
}