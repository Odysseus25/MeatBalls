using UnityEngine;
using System.Collections;

public class SpawerController : MonoBehaviour {

    public GameObject[] ingredientsPrefab;
    private GameObject ingredientContainer;

    // Use this for initialization
    void Start()
    {
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
            if (isTimeToSpawn(thisIngredient))
            {
                Spawn(thisIngredient);
            }
        }
    }

    void Spawn(GameObject ingredientsPrefab)
    {
        GameObject ingredient = Instantiate(ingredientsPrefab, transform.position, Quaternion.identity) as GameObject;
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
