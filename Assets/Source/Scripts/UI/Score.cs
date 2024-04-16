using TMPro;
using UnityEngine;
using YG;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    [Space(10)]
    [SerializeField] private PlatformController _platformController;

    public int ScoreCount { get; private set; }

    public void RestartRewardGame()
    {
        ScoreCount = YandexGame.savesData.LastScore;
        _scoreText.text = ScoreCount.ToString();
    }

    private void Awake()
    {
        _scoreText.text = ScoreCount.ToString();
    }

    private void OnEnable()
    {
        _platformController.AddScoreChanged += OnChangedValue;
    }

    private void OnDisable()
    {
        _platformController.AddScoreChanged -= OnChangedValue;
    }

    private void OnChangedValue()
    {
        ScoreCount++;
        YandexGame.savesData.LastScore = ScoreCount;
        _scoreText.text = " " + ScoreCount.ToString();
    }
}