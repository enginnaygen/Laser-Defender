using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //[SerializeField] Health playerHealth;
    [SerializeField] float delay;


    
    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<ScoreKeeper>().ResetScore();

    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOverMenu()
    {
        StartCoroutine(LoadSceneDelay("EndScene", delay));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator LoadSceneDelay(string sceneName,float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);

    }

}
