using UnityEngine;
using System.Collections;

public class SpawerController : MonoBehaviour {

    public GameObject[] ingredientsPrefab;

    private GameObject ingredientContainer;
    private ClientController list;
    private Clients actualClient;

    // Use this for initialization
    void Start()
    {
        list = FindObjectOfType<ClientController>();
        actualClient = list.clientList[ClientCard.selectedCard];
        SetIngridients();

        ingredientContainer = GameObject.Find("Ingredients");
        if (!ingredientContainer)
        {
            ingredientContainer = new GameObject("Ingredients");
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject thisIngredient in ingredientsPrefab)
        {
            if (thisIngredient.GetComponent<Ingredients>().isWanted) {
                if (isTimeToSpawn(thisIngredient))
                {
                    Spawn(thisIngredient);
                }
            }
        }
    }

    void SetIngridients() {
        foreach (GameObject obj in ingredientsPrefab) {  
            Debug.Log(obj.name + obj.GetComponent<Ingredients>().isWanted);
        }
        for (int i = 0; i < actualClient.preferences.GetLength(1); i++) {
            Debug.Log("la i es " + i);
            ingredientsPrefab[actualClient.preferences[0,i]].GetComponent<Ingredients>().isWanted = true;
            Debug.Log("el ingrediente es " + actualClient.preferences[0, i]);
        }
    }

    void Spawn(GameObject ingredientsPrefab)
    {
        GameObject ingredient;
        if (ingredientsPrefab.GetComponent<Ingredients>().type == 0)
        {
            ingredient = Instantiate(ingredientsPrefab, transform.position, transform.rotation * Quaternion.Euler(-90, 0, 0)) as GameObject;
        }
        else {
            ingredient = Instantiate(ingredientsPrefab, transform.position, transform.rotation * Quaternion.Euler(145, 0, 0)) as GameObject;
        }
        ingredient.transform.parent = ingredientContainer.transform;
    }

    bool isTimeToSpawn(GameObject ingredient)
    {
        float spawnDelay = ingredient.GetComponent<Ingredients>().timeToSpawn;
        float spawnsPerSecond = 1 / spawnDelay;

        if (Time.deltaTime > spawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float treshold = Time.deltaTime * spawnsPerSecond / 3; // time since frame * spawns per second value divided amongst all 3 lanes 

        if (Random.value < treshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
