using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenLoader : MonoBehaviour
{
    private readonly string GameScene = "Game";

    public void GameLoader()
    {
        SceneManager.LoadScene(GameScene);
    }
}