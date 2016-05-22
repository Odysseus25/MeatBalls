using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    bool hasTimeExpired = false;
    Animator anim;
    GameObject[] pauseMenu;
    GameObject[] winPopUp;

    public static float[] ingredientConcentration;
    public static float[] concentrationMultipliers;
    public static int finalPayment = 0;

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
        winPopUp = GameObject.FindGameObjectsWithTag("Win PopUp");
        HidePauseMenu();
        HideWinPopUp();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasTimeExpired)
        {
            TimeHasExpired();
        }
    }

    void TimeHasExpired()
    {
        if (PanelManager.time <= 0f)
        {
            Debug.Log("Time is up");
            ShowWinPopUp();
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

    void HideWinPopUp() {
        foreach (GameObject g in winPopUp) {
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

    void ShowWinPopUp() {
        Time.timeScale = 0;
        foreach (GameObject g in winPopUp)
        {
            g.SetActive(true);
        }
    }

    public static void IncreaseConcentration(int ingridientType)
    {
        ingredientConcentration[ingridientType] += 1f * concentrationMultipliers[PanelManager.actualClient.difficulty];
        if (ingredientConcentration[ingridientType] > 100f) {
            ingredientConcentration[ingridientType] = 100f;
        }
    }

    public void CalculatePayment(){
        float ingredient1 = 0;
        float ingredient2 = 0;
        float ingredient3 = 0;
        int cases = 0;
        if (PanelManager.actualClient.difficulty < 2)
        {
            cases = 2;
        }
        else {
            cases = 1;
        }
        switch (cases) {
            case 1:
                ingredient1 = PanelManager.actualClient.maxPayment / 2;
                ingredient2 = PanelManager.actualClient.maxPayment / 2;

                break;
            case 2:
                ingredient1 = PanelManager.actualClient.maxPayment / 3;
                ingredient2 = PanelManager.actualClient.maxPayment / 3;
                ingredient3 = PanelManager.actualClient.maxPayment / 3;
                break;
        }
    }
}
