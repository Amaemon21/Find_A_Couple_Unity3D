using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class RestartButton : Button_
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _popup;
    
    public void On—ompletion()
    {
        _popup.SetActive(false);
        YandexGame.savesData.LastScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    protected override void OnClickButton()
    {
        _animator.SetTrigger("Hide");
    }
}