using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinPopUp : MonoBehaviour
{

    public Sprite[] ingredientSprites;

    // Use this for initialization
    void Start()
    {
        SetInfo();
        SetPayment();
    }

    void SetInfo()
    {
        int childNumber = 0;
        foreach (Transform ingredients in transform)
        {
            if (ingredients.name == "Ingredients")
            {
                foreach (Transform ingredientImage in ingredients)
                {
                    if (ingredientImage.name == "Ingredient3" && PanelManager.actualClient.difficulty <= 2)
                    {
                        ingredientImage.GetComponent<Image>().enabled = false;
                        ingredientImage.GetComponentInChildren<Text>().enabled = false;
                    }
                    else {
                        ingredientImage.GetComponent<Image>().sprite = ingredientSprites[PanelManager.actualClient.preferences[0, (childNumber)]];
                        ingredientImage.GetComponentInChildren<Text>().text = "x" + (int) GameController.ingredientConcentration[PanelManager.actualClient.preferences[0, (childNumber)]];
                        Debug.Log("child "+ childNumber);
                        SetTextColor(ingredientImage, GameController.ingredientConcentration[PanelManager.actualClient.preferences[0, (childNumber)]]);
                        childNumber++;
                    }
                }
            }
        }
    }

    void SetTextColor(Transform ingridientText, float concentration)
    {
        Debug.Log("concentracion " + concentration);
            if (concentration > 0f && concentration <= 25f)
            {
                ingridientText.GetComponentInChildren<Text>().color = Color.green;
            }
            else if (concentration > 25f && concentration <= 50f)
            {
                ingridientText.GetComponentInChildren<Text>().color = Color.yellow;
            }
            else if (concentration > 50f && concentration <= 75f)
            {
                Color orange = new Color();
                orange.r = 255f;
                orange.g = 140f / 255f;
                orange.b = 0;
                orange.a = 1f;
                ingridientText.GetComponentInChildren<Text>().color = orange;
            }
            else
            {
                ingridientText.GetComponentInChildren<Text>().color = Color.red;
            }
    }

    void SetPayment() {
        GameObject prizeMoney = GameObject.Find("Prize Money");
        prizeMoney.GetComponent<Text>().text = "$" + GameController.finalPayment;
    }
}