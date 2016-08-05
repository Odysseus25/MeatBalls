using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour {

    private ClientController list;

    public static Clients actualClient;
    public static float time;

	// Use this for initialization
	void Start () {
        list = FindObjectOfType<ClientController>();
        actualClient = list.clientList[ClientCard.selectedCard];
        SetText();
        StartCoroutine(UpdateTime());
	}
    	
//Update is called once per frame
	void Update () {
        UpdateText();
	}

    void SetText() {
        int childNumber = 0;
        foreach (Transform text in transform) {
            if (text.name == "Time")
            {
                switch ((int)actualClient.time)
                {
                    case 30:
                        text.GetComponent<Text>().text = "0:30";
                        time = 30f;
                        break;
                    case 45:
                        text.GetComponent<Text>().text = "0:45";
                        time = 45f;
                        break;
                    case 60:
                        text.GetComponent<Text>().text = "1:00";
                        time = 60f;
                        break;
                    case 75:
                        text.GetComponent<Text>().text = "1:15";
                        time = 75f;
                        break;
                    case 90:
                        text.GetComponent<Text>().text = "1:30";
                        time = 90f;
                        break;
                }
            }
            else {

                if (childNumber + 1 > actualClient.preferences.GetLength(1)) {
                    childNumber--;
                    text.GetComponent<Text>().enabled = false;
                }

                switch (actualClient.preferences[0,childNumber]) {
                    case 1:
                        text.GetComponent<Text>().text = "Salt";
                        break;
                    case 2:
                        text.GetComponent<Text>().text = "Pepper";
                        break;
                    case 3:
                        text.GetComponent<Text>().text = "Onion";
                        break;
                    case 4:
                        text.GetComponent<Text>().text = "Sweet Pepper";
                        break;
                    case 5:
                        text.GetComponent<Text>().text = "Cilantro";
                        break;
                }              
            }
            childNumber++;
        }
    }

    private IEnumerator UpdateTime() {
        while (true) {
            time -= Time.deltaTime;
            float minutes = time / 60;
            if (minutes < 1f)
            {
                minutes = 0;
            }
            float seconds = time % 60;

            transform.GetChild(3).GetComponent<Text>().text = string.Format("{0:0}:{1:00}", minutes, seconds);

            yield return null;
        }
        
    }

    private void UpdateText() {
            foreach (Transform ingridientText in transform)
            {
                if (ingridientText.GetComponent<Text>().text == "Salt")
                {
                    SetTextColor(ingridientText, 1);
                }
                else if (ingridientText.GetComponent<Text>().text == "Pepper")
                {
                    SetTextColor(ingridientText, 2);
                }
                else if (ingridientText.GetComponent<Text>().text == "Onion")
                {
                    SetTextColor(ingridientText, 3);
                }
                else if (ingridientText.GetComponent<Text>().text == "Sweet Pepper")
                {
                    SetTextColor(ingridientText, 4);
                }
                else if (ingridientText.GetComponent<Text>().text == "Cilantro")
                {
                    SetTextColor(ingridientText, 5);
                }
            }
    }

    void SetTextColor(Transform ingridientText, int index) {
        if (GameController.ingredientConcentration[index] == 0f)
        {

        }
        else {
            if (GameController.ingredientConcentration[index] > 0f && GameController.ingredientConcentration[index] <= 25f)
            {
                ingridientText.GetComponent<Text>().color = Color.green;
            }
            else if (GameController.ingredientConcentration[index] > 25f && GameController.ingredientConcentration[index] <= 50f)
            {
                ingridientText.GetComponent<Text>().color = Color.yellow;
            }
            else if (GameController.ingredientConcentration[index] > 50f && GameController.ingredientConcentration[index] <= 75f)
            {
                Color orange = new Color();
                orange.r = 255f;
                orange.g = 140f / 255f;
                orange.b = 0;
                orange.a = 1f;
                ingridientText.GetComponent<Text>().color = orange;
            }
            else
            {
                ingridientText.GetComponent<Text>().color = Color.red;
            }
        }
    }
}

