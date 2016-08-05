using UnityEngine;
using System.Collections;

public class ScrollingController : MonoBehaviour {

    public float scrollSpeed = 0;
    private Renderer rend;
    float offset = 0;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material.mainTextureOffset = new Vector2(0, 0);
    }

   public IEnumerator ScrollTexture() {
        while (PanelManager.time > 0f) {
            float offset = scrollSpeed * Time.deltaTime;
            offset = offset % 1.0f;
            rend.material.mainTextureOffset = new Vector2(0, -offset);

            yield return null;
        }
    }

    void Update() {
        offset += scrollSpeed * Time.deltaTime;
        offset = offset % 1.0f;
        rend.material.mainTextureOffset = new Vector2(0, -offset);
    }
}
