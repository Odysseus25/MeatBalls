using UnityEngine;
using System.Collections;

public class Ingredients : MonoBehaviour
{

    public int moveSpeed = 0;
    public float rotationSpeed = 0;
    public float timeToSpawn = 0;
    public bool isWanted;
    public int value = 1;
    public int type = 0;

    PlayerController player;

    // Use this for initialization
    void Start()
    {
        isWanted = false;
        player = FindObjectOfType<PlayerController>();
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
        PlayerController player = col.GetComponent<PlayerController>();
        if (player){
            if (type == 0) {
                player.IncreaseSize();
            }
            else {
                GameController.IncreaseConcentration(type);
            }
            Destroy(gameObject);
        }
    }

}
