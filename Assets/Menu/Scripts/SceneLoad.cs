using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoad : MonoBehaviour
{
    public void LoadSceneGame()
    {
        SceneManager.LoadScene("SceneGame");
        Time.timeScale = 1f;
    }

    public void LoadSceneStartMenu()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;
    }
}
