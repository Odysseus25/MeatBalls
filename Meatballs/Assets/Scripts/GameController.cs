using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    bool hasTimeExpired = false;
    Animator anim;
    GameObject[] pauseMenu;

    public static float[] ingredientConcentration;
    public static float[] concentrationMultipliers;

    // Use this for initialization
    void Start()
    {
        ingredientConcentration = new float[6];
        concentrationMultipliers = new float[6];
        for (int i = 0; i < 6; i++) {
            concentrationMultipliers[i] = 10f;
        }

        anim = GameObject.FindGameObjectWithTag("Dialog Box").GetComponent<Animator>();
        pauseMenu = GameObject.FindGameObjectsWithTag("Pause Menu");
        HidePauseMenu();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasTimeExpired)
        {
            HasTimeExpired();
        }
    }

    void HasTimeExpired()
    {
        if (PanelManager.time <= 0f)
        {
            Debug.Log("Time is up");
            hasTimeExpired = true;
        }
    }

    public void ResumeGame() {
        HidePauseMenu();
        Time.timeScale = 1;
    }

    public void StartGame() {
        anim.SetBool("ButtonPressed", true);
        Time.timeScale = 1;
    }

    public void HidePauseMenu() {
        foreach (GameObject g in pauseMenu)
        {
            g.SetActive(false);
        }
    }

    public void ShowPauseMenu()
    {
        Time.timeScale = 0;
        foreach (GameObject g in pauseMenu) {
            g.SetActive(true);
        }
    }


    public static void IncreaseConcentration(int ingridientType)
    {
        ingredientConcentration[ingridientType] += 1f * concentrationMultipliers[PanelManager.actualClient.difficulty];
    }


}
