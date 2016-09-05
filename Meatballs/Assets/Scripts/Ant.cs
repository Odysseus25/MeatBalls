using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour {

    private float moveSpeed;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        moveSpeed = GetComponent<NonIngredients>().moveSpeed;
        StartCoroutine(EdjustTarget(player));
    }

    public IEnumerator EdjustTarget(GameObject target)
    {
        while (true)
        {
            Vector3 targetPos = new Vector3(target.transform.position.x, 18f, 0f);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

            //yield return new WaitForSeconds(0.01f);
            yield return null;
        }
    }
}
