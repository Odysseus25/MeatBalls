using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    bool hasTimeExpired = false;
    Animator anim;
    GameObject[] pauseMenu;
    GameObject[] winPopUp;
    ClientController controller;

    public static float[] ingredientConcentration;
    public static float[] concentrationMultiplier;
    public static int finalPayment = 0;

    // Use this for initialization
    void Start()
    {
        controller = FindObjectOfType<ClientController>();
        ingredientConcentration = new float[6];
        concentrationMultiplier = new float[] {0, 5f, 6f, 7f, 8f, 10f };
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
            CalculatePayment();
            ClientController.moneyInBank += finalPayment;
            DeleteClient(ClientCard.selectedCard);
            ShowWinPopUp();
            hasTimeExpired = true;
        }
    }

    void DeleteClient(int index) {
        controller.clientList.RemoveAt(index);
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
        ingredientConcentration[ingridientType] += concentrationMultiplier[PanelManager.actualClient.difficulty];
        if (ingredientConcentration[ingridientType] > 100f) {
            ingredientConcentration[ingridientType] = 100f;
        }
    }

    public static void DecreaseConcentration()
    {
        for (int i = 0; i < 6; i++) {
            ingredientConcentration[i] -= ingredientConcentration[i] * 0.25f;
            if (ingredientConcentration[i] < 0f)
            {
                ingredientConcentration[i] = 0;
            }
        }
    }

    public void CalculatePayment(){
        float ingredientValue1 = 0;
        float ingredientValue2 = 0;
        float ingredientValue3 = 0;
        int cases = 0;
        if (PanelManager.actualClient.difficulty <= 2)
        {
            cases = 1;
        }
        else {
            cases = 2;
        }
        switch (cases) {
            case 1:
                ingredientValue1 = PanelManager.actualClient.maxPayment / 2;
                ingredientValue2 = PanelManager.actualClient.maxPayment / 2;
                finalPayment = (int)(CalculateIngredientPayment(ingredientValue1, ingredientConcentration[PanelManager.actualClient.preferences[0,0]], 0) + CalculateIngredientPayment(ingredientValue2, ingredientConcentration[PanelManager.actualClient.preferences[0, 1]], 1));
                Debug.Log("Final Payment" + finalPayment);
                break;
            case 2:
                ingredientValue1 = PanelManager.actualClient.maxPayment / 3;
                ingredientValue2 = PanelManager.actualClient.maxPayment / 3;
                ingredientValue3 = PanelManager.actualClient.maxPayment / 3;
                finalPayment = (int)(CalculateIngredientPayment(ingredientValue1, ingredientConcentration[PanelManager.actualClient.preferences[0, 0]], 0) + CalculateIngredientPayment(ingredientValue2, ingredientConcentration[PanelManager.actualClient.preferences[0, 1]], 1) + CalculateIngredientPayment(ingredientValue3, ingredientConcentration[PanelManager.actualClient.preferences[0, 2]], 2));
                Debug.Log("Final Payment" + finalPayment);
                break;
        }
    }

    float CalculateIngredientPayment(float ingredientValue, float myConcentration, int pos) {
        float payment = 0;
        int tasteValue = 0;
        switch (PanelManager.actualClient.preferences[1, pos]) {
            case 1:
                tasteValue = 25;
                break;
            case 2:
                tasteValue = 50;
                break;
            case 3:
                tasteValue = 75;
                break;
            case 4:
                tasteValue = 100;
                break;
        }
        float dif = tasteValue - myConcentration;
        if (dif < 0) {
            dif *= -1;
        }
        Debug.Log("dif " + dif);
        if (dif < 25f)
        {
            payment = ingredientValue;
        }
        else if (dif < 50f)
        {
            float percent = ingredientValue * 0.33f;
            payment = ingredientValue - percent;
        }
        else if (dif < 75)
        {
            float percent = ingredientValue * 0.66f;
            payment = ingredientValue - percent;
        }
        else {
            payment = 0;
        }
        Debug.Log("Payment " + payment);
        return payment;
    }
}
