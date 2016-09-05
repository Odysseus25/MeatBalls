using UnityEngine;
using System.Collections;

public class SpawnerNonIngredients : MonoBehaviour {

    public GameObject[] ingredientsPrefab;

    private ClientController list;
    private Clients actualClient;

    // Use this for initialization
    void Start()
    {
        list = FindObjectOfType<ClientController>();
        actualClient = list.clientList[ClientCard.selectedCard];
        SetIngridients();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject thisIngredient in ingredientsPrefab)
        {
            if (thisIngredient.GetComponent<NonIngredients>().isWanted)
            {
                if (isTimeToSpawn(thisIngredient))
                {
                    Debug.Log("SPAWNING!!!!");
                    Spawn(thisIngredient);
                }
            }
        }
    }

    void SetIngridients()
    {
        switch (actualClient.difficulty) {
            case 3:
                ingredientsPrefab[0].GetComponent<NonIngredients>().isWanted = true;
                break;
            case 4:
                ingredientsPrefab[0].GetComponent<NonIngredients>().isWanted = true;
                ingredientsPrefab[1].GetComponent<NonIngredients>().isWanted = true;
                break;
            case 5:
                ingredientsPrefab[0].GetComponent<NonIngredients>().isWanted = true;
                ingredientsPrefab[1].GetComponent<NonIngredients>().isWanted = true;
                ingredientsPrefab[2].GetComponent<NonIngredients>().isWanted = true;
                break;
            default:
                break;
        }
    }

    void Spawn(GameObject ingredientsPrefab)
    {    
        GameObject ingredient;
        ingredient = Instantiate(ingredientsPrefab, transform.position, Quaternion.identity) as GameObject;
    }

    bool isTimeToSpawn(GameObject ingredient)
    {
        float spawnDelay = ingredient.GetComponent<NonIngredients>().timeToSpawn;
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
