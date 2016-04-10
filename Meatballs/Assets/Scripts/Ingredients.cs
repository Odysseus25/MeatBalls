using UnityEngine;
using System.Collections;

public class Ingredients : MonoBehaviour
{

    public int moveSpeed = 0;
    public float rotationSpeed = 0;
    public float timeToSpawn = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveIngredient();
        RotateIngredient();
    }

    void MoveIngredient()
    {
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
    }

    void RotateIngredient()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col){
        Debug.Log("Triggered by " + col);
        PlayerController player = col.GetComponent<PlayerController>();
        if (player){
            Destroy(gameObject);
        }
    }

}
