using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientController : MonoBehaviour {

    public List<Clients> clientList; 
	
    // Use this for initialization
	void Start () {
       clientList = new List<Clients>();
       CreateClientList();
	}

    void CreateClientList() {
        for (int i = 0; i < 5; i++) {
            Clients clients = new Clients();
            clients.SetClient();
            clientList.Add(clients);
        }
    }

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}
