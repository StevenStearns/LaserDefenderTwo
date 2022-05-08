using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float fltSceneLoadDelay = 2f;

  public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", fltSceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.OpenURL("about:blank");
    }

    IEnumerator WaitAndLoad(string sceneName, float fltDelay)
    {
        yield return new WaitForSeconds(fltDelay);
        SceneManager.LoadScene(sceneName);
    }
}
