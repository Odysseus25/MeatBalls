using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    bool hasTimeExpired = false;

    public static float[] ingredientConcentration;
    public static float[] concentrationMultipliers;

    // Use this for initialization
    void Start()
    {
        ingredientConcentration = new float[6];
        concentrationMultipliers = new float[6];
        for (int i = 0; i < 6; i++) {
            concentrationMultipliers[i] = 10f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasTimeExpired)
        {
            HasTimeExpired();
        }
    }

    void HasTimeExpired()
    {
        if (PanelManager.time <= 0f)
        {
            Debug.Log("Time is up");
            hasTimeExpired = true;
        }
    }

    public static void IncreaseConcentration(int ingridientType)
    {
        ingredientConcentration[ingridientType] += 1f * concentrationMultipliers[PanelManager.actualClient.difficulty];
    }
}
