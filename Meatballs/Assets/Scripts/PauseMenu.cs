using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public Sprite[] ingredientSprites;

	// Use this for initialization
	void Start () {
        SetInfo();
	}

    public void SetInfo() {
        int childNumber = 0;
        foreach (Transform ingredients in transform) {
            if (ingredients.name == "Ingredients") {
                foreach (Transform ingredientImage in ingredients) {
                    if (ingredientImage.name == "Ingredient3" && PanelManager.actualClient.difficulty <= 2)
                    {
                        ingredientImage.GetComponent<Image>().enabled = false;
                        ingredientImage.GetComponentInChildren<Text>().enabled = false;
                    }
                    else {
                        ingredientImage.GetComponent<Image>().sprite = ingredientSprites[PanelManager.actualClient.preferences[0, (childNumber)]];
                        switch (PanelManager.actualClient.preferences[1, childNumber]) {
                            case 1:
                                ingredientImage.GetComponentInChildren<Text>().text = "x25%";
                                ingredientImage.GetComponentInChildren<Text>().color = Color.green;
                                break;
                            case 2:
                                ingredientImage.GetComponentInChildren<Text>().text = "x50%";
                                ingredientImage.GetComponentInChildren<Text>().color = Color.yellow;
                                break;
                            case 3:
                                ingredientImage.GetComponentInChildren<Text>().text = "x75%";
                                Color orange = new Color();
                                orange.r = 255f;
                                orange.g = 140f / 255f;
                                orange.b = 0;
                                orange.a = 1f;
                                ingredientImage.GetComponentInChildren<Text>().color = orange;
                                break;
                            case 4:
                                ingredientImage.GetComponentInChildren<Text>().text = "x100%";
                                ingredientImage.GetComponentInChildren<Text>().color = Color.red;
                                break;
                        }
                        childNumber++;                
                    }
                }
            }
        }
    }
}
