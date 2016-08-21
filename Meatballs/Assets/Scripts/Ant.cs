using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour {

    private float moveSpeed = 0.2f;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        //StartCoroutine(Move());
        StartCoroutine(EdjustTarget(player));
    }

    public IEnumerator AdjustTarget(GameObject target) {
        while (true) {
            float targetPos = target.transform.position.x;
            float myPos = transform.position.x;
            if (targetPos > myPos)
            {
                transform.position += new Vector3(myPos + 1, 0f, 0f);
            }
            else {
                transform.position += new Vector3(myPos - 1, 0f, 0f);
            }

            yield return null;
        }
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

    public IEnumerator Move()
    {
        while (true)
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);

            yield return null;
        }
    }
}
