using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    void OnTriggerEnter(Collider col) {
        Destroy(col.gameObject);
    }

}
