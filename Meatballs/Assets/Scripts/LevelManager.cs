using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void changeLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void quit()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void Reload()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }

    public void changeLevelAndSave(string name)
    {
        ClientController.controller.Save();
        SceneManager.LoadScene(name);
    }

    /* public void LoadNextLevel()
     {
         SceneManager.LoadScene(Application.loadedLevel + 1);
     }*/
}