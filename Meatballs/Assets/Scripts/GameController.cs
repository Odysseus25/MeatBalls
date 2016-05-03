using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    private Clients clients;

    public List<Clients> clientList; 
	
    // Use this for initialization
	void Start () {
       clients = FindObjectOfType<Clients>();
       clientList = new List<Clients>();
       CreateClientList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CreateClientList() {
        clients.GetComponent<Clients>();
        for (int i = 0; i < 5; i++) {
            clients.SetClient();
            Debug.Log(clients.difficulty);
            clientList.Add(clients);
        }
    }

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}
