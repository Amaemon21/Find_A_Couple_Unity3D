using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FageScreen : MonoBehaviour
{
    [SerializeField] private Image _imageFade;
    [SerializeField] private float _fadeSpeed = 1f;

    private readonly string GameScene = "Game";

    public void GameLoader()
    {
        StartCoroutine(FadeStart());
    }

    IEnumerator FadeStart()
    {
        Color color = _imageFade.color;

        while (color.a < 1f)
        {
            color.a += _fadeSpeed * Time.deltaTime;
            _imageFade.color = color;
            yield return null;
        }

        SceneManager.LoadScene(GameScene);
    }
}
