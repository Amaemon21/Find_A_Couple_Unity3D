using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class RestartButton : Button_
{
    protected override void OnClickButton()
    {
        Time.timeScale = 1;
        YandexGame.savesData.LastScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}