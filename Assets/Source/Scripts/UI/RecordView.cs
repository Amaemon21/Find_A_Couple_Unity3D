using TMPro;
using UnityEngine;
using YG;

public class RecordView : MonoBehaviour
{
    [SerializeField] private CheckingAnimalFallen _checkingAnimalFallen;
    [SerializeField] private Score _score;

    [SerializeField] private TMP_Text _recordText;
    [SerializeField] private TMP_Text _currentScoreText;

    [SerializeField] private GameObject _newRecord;

    private int _record;

    private void OnEnable() => _checkingAnimalFallen.GameOverChanged += OnGameOverChanged;

    private void OnDisable() => _checkingAnimalFallen.GameOverChanged -= OnGameOverChanged;

    private void OnGameOverChanged()
    {
        if (YandexGame.SDKEnabled)
        {
            _record = YandexGame.savesData.ScoreRecord;
            _currentScoreText.text = _score.ScoreCount.ToString();
            _recordText.text = _record.ToString();

            if (_score.ScoreCount > YandexGame.savesData.ScoreRecord)
            {
                _newRecord.SetActive(true);
                YandexGame.savesData.ScoreRecord = _score.ScoreCount;
            }
        }
    }   
}