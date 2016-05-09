using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClientCard : MonoBehaviour {

    public static int selectedCard;

    public Sprite[] difficulty;
    public Sprite[] ingredients;
    public Sprite[] malePortrait;
    public Sprite[] femalePortrait;
    public int cardIndex = 0;

    private float time;
    private List<Clients> clientList;
    private Clients actualClient;

    public void GetInfo(List<Clients> list, int clientNumber) {
        clientList = list;
        FillCard(clientNumber);
    }

    public void LoadClientLevel(string name)
    {
        selectedCard = cardIndex;
        SceneManager.LoadScene(name);
    }

    public void FillCard(int clientNumber) {
        actualClient = clientList[clientNumber];
        cardIndex = clientNumber;
        Debug.Log("client number " + clientList[clientNumber].difficulty);
        foreach (Transform child in transform) {
                // Debug.Log("Child " + child.name);
                if (child.name == "Difficulty")
                {
                    ChangeDifficulty(child);
                }
                if (child.name == "Ingridients")
                {
                    int i = 0;
                    foreach (Transform ingridient in child.transform)
                    {
                        ChangeIngridientSprite(ingridient, i);
                        i++;
                    }
                }
                if (child.name == "Portrait") {
                    ChangePortrait(child);
                }
                if (child.name == "Clock")
                {
                    ChangeTime(child);
                }
        }
    }

    void ChangeIngridientSprite(Transform ingridientChild, int spritePos) {
         if (spritePos+1 > actualClient.preferences.GetLength(1)) {
             spritePos--;
             ingridientChild.GetComponent<Image>().enabled = false;
        }

        switch (actualClient.preferences[0, spritePos])
        {
            case 1:
                ingridientChild.GetComponent<Image>().sprite = ingredients[0];
                break;
            case 2:
                ingridientChild.GetComponent<Image>().sprite = ingredients[1];
                break;
            case 3:
                ingridientChild.GetComponent<Image>().sprite = ingredients[2];
                break;
            case 4:
                ingridientChild.GetComponent<Image>().sprite = ingredients[3];
                break;
            case 5:
                ingridientChild.GetComponent<Image>().sprite = ingredients[4];
                break;
        }
    }

    void ChangeDifficulty(Transform child) {
            switch (actualClient.difficulty)
            {
                case 1:
                    child.GetComponent<Image>().sprite = difficulty[0];
                    break;
                case 2:
                    child.GetComponent<Image>().sprite = difficulty[1];
                    break;
                case 3:
                    child.GetComponent<Image>().sprite = difficulty[2];
                    break;
                case 4:
                    child.GetComponent<Image>().sprite = difficulty[3];
                    break;
                case 5:
                    child.GetComponent<Image>().sprite = difficulty[4];
                    break;
            }
    }

    void ChangePortrait(Transform child) {
        if (actualClient.gender == 'm')
        {
            //choose a random male portrait from the array and set it as the image
            child.GetComponent<Image>().sprite = malePortrait[0];
        }
        else {
            //choose a random female protrait from the array and set it as the image
            child.GetComponent<Image>().sprite = malePortrait[0];
        }
        ChangeName(child);
    }    

    void ChangeName(Transform parent) {
        foreach (Transform name in parent) {
            name.GetComponent<Text>().text = actualClient.clientName;
        }
    }

    void ChangeTime(Transform parent) {
        foreach (Transform child in parent) {
            switch ((int)actualClient.time) {
                case 30:
                    child.GetComponent<Text>().text = "0:30";
                    break;
                case 45:
                    child.GetComponent<Text>().text = "0:45";
                    break;
                case 60:
                    child.GetComponent<Text>().text = "1:00";
                    break;
                case 75:
                    child.GetComponent<Text>().text = "1:15";
                    break;
                case 90:
                    child.GetComponent<Text>().text = "1:30";
                    break;
            }
        }
    }
}
