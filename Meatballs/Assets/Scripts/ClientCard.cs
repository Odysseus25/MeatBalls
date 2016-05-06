using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ClientCard : MonoBehaviour {

    public Sprite[] difficulty;
    public Sprite[] ingredients;
    public Sprite[] portrait;

    private string clientName;
    private float time;
    private List<Clients> clientList;
    private Clients actualClient;

    public void GetInfo(List<Clients> list, int clientNumber) {
        clientList = list;
        FillCard(clientNumber);
    }

    void Update() {
        Canvas.ForceUpdateCanvases();
    }

    public void FillCard(int clientNumber) {
            actualClient = clientList[clientNumber];
        Debug.Log("client number " + clientList[clientNumber].difficulty);
        foreach (Transform child in transform)
            {
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
            }
    }

    void SetIngridientImage(int pos, Transform ingridientChild) {
        switch (actualClient.preferences[0,pos]) {
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
        //img = child.GetComponent<Image>();
       // Debug.Log("Client diff " + actualClient.difficulty);
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
}
