using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    void OnTriggerEnter(Collider col) {
        Ingredients ingredient = col.GetComponent<Ingredients>();
        if (ingredient) {
            Destroy(ingredient.gameObject);
        }
    }

}
