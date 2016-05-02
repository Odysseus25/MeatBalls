using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    //public string levelName;

    public void changeLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void quit()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

   /* public void LoadNextLevel()
    {
        SceneManager.LoadScene(Application.loadedLevel + 1);
    }*/
}