using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int moveSpeed = 0;
    public int verticalSpeed = 0;
    public float rotationSpeed = 0;

    public float padding = 0.5f;
    private float xMin, xMax, yMin;

	// Use this for initialization
	void Start () {
        float distance = this.transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));   //getting borders of the screen to restrict play space
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
        Vector3 downmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        xMin = leftmost.x + padding;
        xMax = rightmost.x - padding;
        yMin = downmost.y + padding;
    }
	
	// Update is called once per frame
	void Update () {
        MoveBall();
        RotateBall();
        RestricSpace();
        MoveWithTilt();
        MoveVertical();
	}

    void MoveVertical() {
        if (Input.GetMouseButton(0))
        {
            transform.position += new Vector3(0, -verticalSpeed * Time.deltaTime, 0);
        }
        else {
            if (transform.position.y < 5f) {
                transform.position += new Vector3(0, verticalSpeed * Time.deltaTime, 0);
            }
        }
    }

    void RestricSpace()
    {
        float xSpace = Mathf.Clamp(this.transform.position.x, xMin, xMax);
        float ySpace = Mathf.Clamp(this.transform.position.y, yMin, 5f);
        this.transform.position = new Vector3(xSpace, ySpace, transform.position.z);
    }

    void MoveBall() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            Debug.Log("Left arrow pressed");
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            Debug.Log("Right arrow pressed");
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    void MoveWithTilt() {
        float tiltX = Input.acceleration.x * moveSpeed;
        transform.position += new Vector3(tiltX * Time.deltaTime, 0, 0);
    }

    void RotateBall() {
        transform.Rotate(new Vector3(-rotationSpeed, 0, 0) * Time.deltaTime);
    }

    void AdjustPadding() {
        float oldPadding = padding;
        padding = (float) (transform.localScale.x * 0.5);
        xMin += padding - oldPadding;
        xMax -= padding - oldPadding;
        yMin += padding - oldPadding;
    }

    public void IncreaseSize() {
        transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
        AdjustPadding();
    }

}
