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
    public GameObject particleSys;

    private ParticleSystem pickupEffect;
    PlayerController player;

    // Use this for initialization
    void Start()
    {
        isWanted = false;
        player = FindObjectOfType<PlayerController>();
        rotationSpeed = Random.Range(100f, 400f);
        switch(PanelManager.actualClient.difficulty){
            case 1:   
                moveSpeed = Random.Range(1, 3);
                break;
            case 2:
                moveSpeed = Random.Range(1, 5);
                break;
            case 3:
                moveSpeed = Random.Range(1, 7);
                break;
            case 4:
                moveSpeed = Random.Range(1, 10);
                break;
            case 5:
                moveSpeed = Random.Range(1, 12);
                break;
        }

        StartCoroutine(MoveIngredients());
        StartCoroutine(RotateIngredients());
    }

    // Update is called once per frame
   /* void Update()
    {
        MoveIngredient();
        RotateIngredient();
    }*/

    public IEnumerator MoveIngredients()
    {
        while (true)
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);

            yield return null;
        }
    }

    public IEnumerator RotateIngredients()
    {
        while (true)
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);

            yield return null;
        }
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
                GameController.DecreaseConcentration();
            }
            else {
                GameController.IncreaseConcentration(type);
            }
            if (particleSys) {
                Instantiate(particleSys, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

}
