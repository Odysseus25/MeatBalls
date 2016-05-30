using UnityEngine;
using System.Collections;

public class ScrollingController : MonoBehaviour {

    public float scrollSpeed = 0;
    private Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material.mainTextureOffset = new Vector2(0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        ScrollTexture();
	}

    void ScrollTexture() {
        float offset = scrollSpeed * Time.timeSinceLevelLoad;
        rend.material.mainTextureOffset = new Vector2(0, -offset);
    }
}
