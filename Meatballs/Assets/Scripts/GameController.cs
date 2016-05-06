using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    //private Clients clients;

    int j = 0;
    public List<Clients> clientList; 
	
    // Use this for initialization
	void Start () {
       clientList = new List<Clients>();
       CreateClientList();
       //Print();
	}

    void CreateClientList() {
        for (int i = 0; i < 5; i++) {
            Clients clients = new Clients();
            clients.SetClient();
            clientList.Add(clients);
           // Debug.Log(clientList[i].clientName);
            //Debug.Log("Ingrediente 1: " + clients.preferences[0, 0] + " " + clients.preferences[1, 0]);
           // Debug.Log("Ingrediente 2: " + clients.preferences[0, 1] + " " + clients.preferences[1, 1]);
            //Debug.Log("Ingrediente 3 " + preferences[0, 2] + " " + preferences[1, 2]);
        }
        j++;
    }

    void Print() {
        for (int j = 0; j < 5; j++)
        {
            Debug.Log("Print " + clientList[j].clientName);
        }
    }

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
}
