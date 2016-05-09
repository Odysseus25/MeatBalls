using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour {

    private ClientController list;
    private Clients actualClient;

    public static float time;

	// Use this for initialization
	void Start () {
        list = FindObjectOfType<ClientController>();
        actualClient = list.clientList[ClientCard.selectedCard];
        SetText();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTime();
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

    void UpdateTime() {
        time -= Time.deltaTime;
        float minutes = time / 60;
        if (minutes < 1f) {
            minutes = 0;
        }
        float seconds = time % 60;

        transform.GetChild(3).GetComponent<Text>().text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    void UpdateText() { }
}
