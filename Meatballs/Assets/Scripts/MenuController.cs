using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        if (PlayerPrefsManager.GetMenuAnimationState())
        {
            Camera.main.GetComponent<Animator>().enabled = true;
        }
        else {
            Camera.main.GetComponent<Animator>().enabled = false;
        }
	}
}
