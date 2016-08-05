using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionController : MonoBehaviour {

    public Slider volumeSlider;
    public Toggle animationToggle;

    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        animationToggle.isOn = PlayerPrefsManager.GetMenuAnimationState();
        Debug.Log(volumeSlider.value);
        Debug.Log(animationToggle.isOn);
    }

    public void SaveAndExit() {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetMenuAnimationState(animationToggle.isOn);
        Debug.Log("Settings saved");
        levelManager.changeLevel("01a_Start_Menu");
    }

}
