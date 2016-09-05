using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

    private Animator flyAnim;

    // Use this for initialization
    void Start() {
        flyAnim = GetComponent<Animator>();

        switch (Random.Range(1, 6)) {
            case 1:
                flyAnim.SetBool("Fly", true);
                break;
            case 2:
                flyAnim.SetBool("Fly2", true);
                break;
            case 3:
                flyAnim.SetBool("Fly3", true);
                break;
            case 4:
                flyAnim.SetBool("Fly4", true);
                break;
            case 5:
                flyAnim.SetBool("Fly5", true);
                break;
            default:
                flyAnim.SetBool("Fly", true);
                break;
        }
    }
}
