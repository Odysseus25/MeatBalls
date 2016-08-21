using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogBoxController : MonoBehaviour
{

    public Sprite[] malePortrait;
    public Sprite[] femalePortrait;
    public Sprite[] ingredientSprites;

    private Clients actualClient;

    // Use this for initialization
    void Start()
    {
        actualClient = PanelManager.actualClient;
        SetBox();
        SetBanner();
    }

    public void SetBanner()
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
                        Transform concentration = ingredientImage.GetChild(0);
                        concentration.GetComponent<Text>().enabled = false;
                    }
                    else
                    {
                        Debug.Log("childnumber: " + childNumber);
                        ingredientImage.GetComponent<Image>().sprite = ingredientSprites[PanelManager.actualClient.preferences[0, (childNumber)]];
                        Transform concentration = ingredientImage.GetChild(0);
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
    }

    private void SetBox()
    {
        Transform portrait = transform.GetChild(0);
        Transform description = transform.GetChild(1);
        Transform ingredients = transform.GetChild(2);

        if (PanelManager.actualClient.gender == 'm')
        {
            string hisName = actualClient.clientName;
            if (hisName.Equals("Verde"))
            {
                portrait.GetComponent<Image>().sprite = malePortrait[0];
                description.GetComponent<Text>().text = "Meatballs are love, meatballs are life. I'll have three.";
            }
            else if (hisName.Equals("Tulio"))
            {
                portrait.GetComponent<Image>().sprite = malePortrait[1];
                description.GetComponent<Text>().text = "You already know how I like my meatballs, son. Get on it.";
            }
            else if (hisName.Equals("Macho"))
            {
                portrait.GetComponent<Image>().sprite = malePortrait[2];
                description.GetComponent<Text>().text = "Hey! What's cooking? No, really, I'm hungry. Get working on my food already!";
            }
            else if (hisName.Equals("Boga"))
            {
                portrait.GetComponent<Image>().sprite = malePortrait[3];
                description.GetComponent<Text>().text = "This place always cheers me up. I'll have today's special, please";
            }
        }
        else
        {
            string herName = actualClient.clientName;
            if (herName.Equals("Mary"))
            {
                portrait.GetComponent<Image>().sprite = femalePortrait[0];
                description.GetComponent<Text>().text = "Soooo... What's the secret ingredient in this one? C'mon, tell me!";
            }
            else if (herName.Equals("Pao"))
            {
                portrait.GetComponent<Image>().sprite = femalePortrait[1];
                description.GetComponent<Text>().text = "What's up? I'd like to try something different today!";
            }
            else if (herName.Equals("Nana"))
            {
                portrait.GetComponent<Image>().sprite = femalePortrait[2];
                description.GetComponent<Text>().text = "Hi! I would like to make an order, please";
            }
        }
    }

}
