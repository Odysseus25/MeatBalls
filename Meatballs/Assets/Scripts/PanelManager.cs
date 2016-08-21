using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour {

    private ClientController list;

    private Animator ingredientAnim1;
    private Animator ingredientAnim2;
    private Animator ingredientAnim3;

    private Transform text1;
    private Transform text2;
    private Transform text3;

    private RectTransform mask1;
    private RectTransform mask2;
    private RectTransform mask3;

    private int ingredientType1;
    private int ingredientType2;
    private int ingredientType3;

    private int ratio1;
    private int ratio2;
    private int ratio3;

    private float height = 158.94f;

    public static Clients actualClient;
    public Sprite[] ingredients;
    public static float time;

	// Use this for initialization
	void Start () {
        list = FindObjectOfType<ClientController>();
        actualClient = list.clientList[ClientCard.selectedCard];
        SetSprites();
        SetText();

        GetMasks();
        text1 = transform.GetChild(3);
        text2 = transform.GetChild(4);
        text3 = transform.GetChild(5);

        ingredientAnim1 = GameObject.FindGameObjectWithTag("Ingredient Panel").GetComponent<Animator>();
        ingredientAnim2 = GameObject.FindGameObjectWithTag("Ingredient Panel 1").GetComponent<Animator>();
        ingredientAnim3 = GameObject.FindGameObjectWithTag("Ingredient Panel 2").GetComponent<Animator>();

        StartCoroutine(UpdateTime());
	}
    	
//Update is called once per frame
	void FixedUpdate () {
        UpdateText();
        UpdateSprites();
        CheckRatios();
	}

    private void GetMasks() {
        RectTransform m1 = (RectTransform)transform.GetChild(0);
        RectTransform m2 = (RectTransform)transform.GetChild(1);
        RectTransform m3 = (RectTransform)transform.GetChild(2);

        mask1 = (RectTransform)m1.GetChild(0);
        mask2 = (RectTransform)m2.GetChild(0);
        mask3 = (RectTransform)m3.GetChild(0);
    }

    void SetSprites() {
        int spriteNumber = 0;
        foreach (Transform Bmask in transform) {
            if (Bmask.name == "Black Mask" || Bmask.name == "Black Mask1" || Bmask.name == "Black Mask2") {
                if (Bmask.name == "Black Mask2" && actualClient.difficulty <= 2)
                {
                    Bmask.GetComponent<Image>().enabled = false;
                    Transform pMask = Bmask.GetChild(0);
                    Transform ingredientSprite = pMask.GetChild(0);
                    ingredientSprite.GetComponent<Image>().enabled = false;
                    pMask.GetComponent<Mask>().enabled = false;
                    pMask.GetComponent<Image>().enabled = false;
                }
                else
                {
                    Bmask.GetComponent<Image>().sprite = ingredients[actualClient.preferences[0, spriteNumber]];

                    switch (spriteNumber) { //defines which type of ingredient it is
                        case 0:
                            ingredientType1 = actualClient.preferences[0, spriteNumber];
                            ratio1 = SetRatio(actualClient.preferences[1, 0]);
                            break;
                        case 1:
                            ingredientType2 = actualClient.preferences[0, spriteNumber];
                            ratio2 = SetRatio(actualClient.preferences[1, 1]);
                            break;
                        case 2:
                            ingredientType3 = actualClient.preferences[0, spriteNumber];
                            ratio3 = SetRatio(actualClient.preferences[1, 2]);
                            break;
                    }

                    foreach (Transform pMask in Bmask)
                    {
                        Transform ingredient = pMask.GetChild(0);
                        ingredient.GetComponent<Image>().sprite = ingredients[actualClient.preferences[0, spriteNumber]];
                    }
                }
                spriteNumber++;
            }
        }
    }

    private int SetRatio(int order) {
        switch (order)
        {
            case 1:
                return 25;
            case 2:
                return 50;
            case 3:
                return 75;
            case 4:
                return 100;
            default:
                return 100;
        }
    }

    void SetText() {
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
                if (text.name == "Ingridient1" || text.name == "Ingridient2" || text.name == "Ingridient3") {
                    if (text.name == "Ingridient3" && actualClient.difficulty <= 2)
                    {
                        text.GetComponent<Text>().enabled = false;
                    }
                    text.GetComponent<Text>().text = "x0";
                }
            }
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

            transform.GetChild(6).GetComponent<Text>().text = string.Format("{0:0}:{1:00}", minutes, seconds);

            yield return null;
        }
        
    }

    private void UpdateText() {
        ChangeText(text1, ingredientType1);
        ChangeText(text2, ingredientType2);
        ChangeText(text3, ingredientType3);

        SetTextColor(text1, ingredientType1);
        SetTextColor(text2, ingredientType2);
        SetTextColor(text3, ingredientType3);
    }

    private void ChangeText(Transform text, int type) {
        text.GetComponent<Text>().text = "x" + (int)GameController.ingredientConcentration[type];
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

    private void UpdateSprites() {
        mask1.sizeDelta = new Vector2(159f, CalculatePercentaje(ingredientType1, ratio1));
        mask2.sizeDelta = new Vector2(159f, CalculatePercentaje(ingredientType2, ratio2));
        mask3.sizeDelta = new Vector2(159f, CalculatePercentaje(ingredientType3, ratio3));
    }

    private float CalculatePercentaje(int type, int ratio) {
        return ((GameController.ingredientConcentration[type] * height) / ratio);
    }

    private void CheckRatios() {
        if (ratio1 < (int)GameController.ingredientConcentration[ingredientType1])
        {
            ingredientAnim1.SetBool("OverLimit", true);
            Debug.Log("Im ratio 1");
        }
        else {
            if (ingredientAnim1.GetCurrentAnimatorStateInfo(0).IsName("Ingredient_Panel"))
            {
                ingredientAnim1.SetBool("OverLimit", false);
                Debug.Log("Im ratio 1-1");
            }
        }
        if (ratio2 < (int)GameController.ingredientConcentration[ingredientType2])
        {
            ingredientAnim2.SetBool("OverLimit", true);
            Debug.Log("Im ratio 2");
        }
        else
        {
            if (ingredientAnim2.GetCurrentAnimatorStateInfo(0).IsName("Ingredient_Panel"))
            {
                ingredientAnim2.SetBool("OverLimit", false);
                Debug.Log("Im ratio 2-2");
            }
        }
        if (ratio3 < (int)GameController.ingredientConcentration[ingredientType3])
        {
            ingredientAnim3.SetBool("OverLimit", true);
            Debug.Log("Im ratio 3");
        }
        else
        {
            if (ingredientAnim3.GetCurrentAnimatorStateInfo(0).IsName("Ingredient_Panel"))
            {
                ingredientAnim3.SetBool("OverLimit", false);
                Debug.Log("Im ratio 3-3");
            }
        }
    }
}

