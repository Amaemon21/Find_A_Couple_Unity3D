using UnityEngine;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public int money = 1;      
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        //мои сохранения
        [SerializeField] private int _scoreRecord;
        [SerializeField] private int _lastScore;

        public SavesYG()
        {
            openLevels[1] = true;
            _scoreRecord = 0;
        }

        public int ScoreRecord
        {
            get => _scoreRecord;
            set
            {
                _scoreRecord = value;
                YandexGame.SaveProgress();
            }
        }

        public int LastScore
        {
            get => _lastScore;
            set
            {
                _lastScore = value;
                YandexGame.SaveProgress();
            }
        }
    }
}