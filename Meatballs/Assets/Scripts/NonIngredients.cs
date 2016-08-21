using UnityEngine;
using System.Collections;

public class NonIngredients : MonoBehaviour {

    public GameObject particleSys;

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Triggered");
        PlayerController player = col.GetComponent<PlayerController>();
        if (player)
        {
            //GameController.AdjustHealthinessConcentration();
            /*if (particleSys)
            {
                Instantiate(particleSys, transform.position, Quaternion.identity);
            }*/
            Destroy(gameObject);
        }
    }
}
