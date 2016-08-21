using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReminderBox : MonoBehaviour {

    public Sprite[] ingredientSprites;

    private Clients client;

    // Use this for initialization
    void Start () {
        SetReminder();
	}

    public void SetReminder()
    {
        int childNumber = 0;
        foreach (Transform ingredients in transform)
        {
            if (ingredients.name == "Ingredient3" && PanelManager.actualClient.difficulty <= 2)
            {
                ingredients.GetComponent<Image>().enabled = false;
                Transform concentration = ingredients.GetChild(0);
                concentration.GetComponent<Text>().enabled = false;
            }
            else
            {
                ingredients.GetComponent<Image>().sprite = ingredientSprites[PanelManager.actualClient.preferences[0, (childNumber)]];
                Transform concentration = ingredients.GetChild(0);
                Text concentrationText = concentration.GetComponent<Text>();
                switch (PanelManager.actualClient.preferences[1, childNumber])
                {
                    case 1:
                        concentrationText.text = "x25";
                        concentrationText.color = Color.green;
                        break;
                    case 2:
                        concentrationText.text = "x50";
                        concentrationText.color = Color.yellow;
                        break;
                    case 3:
                        concentrationText.text = "x75";
                        Color orange = new Color();
                        orange.r = 255f;
                        orange.g = 140f / 255f;
                        orange.b = 0;
                        orange.a = 1f;
                        concentrationText.color = orange;
                        break;
                    case 4:
                        concentrationText.text = "x100";
                        concentrationText.color = Color.red;
                        break;
                }
                childNumber++;
            }
        }
    }
}
