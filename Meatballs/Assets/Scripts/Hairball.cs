using UnityEngine;
using System.Collections;

public class Hairball : MonoBehaviour {

    private float rotationSpeed = 150;
    private float moveSpeed = 3;

	// Use this for initialization
	void Start () {
        rotationSpeed = Random.Range(100f, 400f);
        /*switch (PanelManager.actualClient.difficulty)
        {
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
        }*/
        StartCoroutine(Move());
        StartCoroutine(Rotate());
	}

    public IEnumerator Move()
    {
        while (true)
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);

            yield return null;
        }
    }

    public IEnumerator Rotate()
    {
        while (true)
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);

            yield return null;
        }
    }
}
