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
    public static int clientQueueSize = 5;
    public DateTime time;
	
    // Use this for initialization
	void Start () {
       clientList = new List<Clients>();
        if (!File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            CreateClientList(5);
            time = DateTime.Now;
            Debug.Log("Archivo nuevo guardado");
        }
        else {
            Load();
        }
	}

    public void CreateClientList(int quantity) {
        for (int i = 0; i < quantity; i++) {
            Clients clients = new Clients();
            clients.SetClient();
            clientList.Add(clients);
        }
        Save();
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

        PlayerData data = new PlayerData(clientList, moneyInBank, restaurantCategory, clientQueueSize, time);

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
            clientQueueSize = data.clientQueueSize;
            time = data.time;

            Debug.Log("Archivo cargado");
        }
    }
}

[Serializable]
class PlayerData {
    public List<Clients> clientList;
    public int moneyInBank;
    public int restaurantCategory;
    public int clientQueueSize;
    public DateTime time;

    public PlayerData(List<Clients> list, int money, int category, int queueSize, DateTime timeStamp) {
        clientList = list;
        moneyInBank = money;
        clientQueueSize = queueSize;
        restaurantCategory = category;
        time = timeStamp;
    }
}