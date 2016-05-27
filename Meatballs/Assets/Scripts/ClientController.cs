using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ClientController : MonoBehaviour {

    public static ClientController controller;
    public List<Clients> clientList;
    public static int moneyInBank = 0;
    public static int restaurantCategory = 1;
	
    // Use this for initialization
	void Start () {
       clientList = new List<Clients>();
        if (!File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            CreateClientList();
            Save();
            Debug.Log("Archivo nuevo guardado");
        }
        else {
            Load();
        }
	}

    void CreateClientList() {
        for (int i = 0; i < 5; i++) {
            Clients clients = new Clients();
            clients.SetClient();
            clientList.Add(clients);
        }
    }

    void Awake() {
        if (!controller)
        {
            DontDestroyOnLoad(transform.gameObject);
            controller = this;
        }
        else if(controller != this){
            Destroy(gameObject);
        }   
    }

    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData(clientList, moneyInBank, restaurantCategory);

        bf.Serialize(file, data);
        file.Close();

        Debug.Log("Archivo guardado");
    }

    public void Load() {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            clientList = data.clientList;
            moneyInBank = data.moneyInBank;
            restaurantCategory = data.restaurantCategory;

            Debug.Log("Archivo cargado");
        }
    }
}

[Serializable]
class PlayerData {
    public List<Clients> clientList;
    public int moneyInBank;
    public int restaurantCategory;

    public PlayerData(List<Clients> list, int money, int category) {
        clientList = list;
        moneyInBank = money;
        restaurantCategory = category;
    }
}