using UnityEngine;
using System.Collections;

public class NonIngredients : MonoBehaviour {

    public GameObject particleSys;
    public int damage = 10;
    public float timeToSpawn = 5;
    public bool isWanted = false;
    public float moveSpeed = 0;

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Triggered");
        PlayerController player = col.GetComponent<PlayerController>();
        if (player)
        {
            GameController.healthiness -= damage;
            if (GameController.healthiness < 0) {
                GameController.healthiness = 0;
            }
            /*if (particleSys)
            {
                Instantiate(particleSys, transform.position, Quaternion.identity);
            }*/
            Destroy(gameObject);
        }
    }
}
