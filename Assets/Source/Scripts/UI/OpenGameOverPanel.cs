using UnityEngine;

public class OpenGameOverPanel : MonoBehaviour
{
    [SerializeField] private CheckingAnimalFallen _checkingAnimalFallen;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _scorePanel;

    private void OnEnable()
    {
        _checkingAnimalFallen.GameOverChanged += OnGameOverChanged;
    }

    private void OnDisable()
    {
        _checkingAnimalFallen.GameOverChanged -= OnGameOverChanged;
    }

    private void OnGameOverChanged()
    {
        _scorePanel.gameObject.SetActive(false);
        _gameOverPanel.SetActive(true);
    }
}