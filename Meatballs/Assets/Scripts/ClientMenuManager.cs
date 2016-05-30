using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ClientMenuManager : MonoBehaviour {

    private AdManager ads;
    private ClientController list;
    private Clients actualClient;
    private DateTime now;

    public GameObject clientCard;

	// Use this for initialization
	void Start () {
	    list = FindObjectOfType<ClientController>();
        ads = FindObjectOfType<AdManager>();
        CheckNewClients();
        PopulateList();
        if (list.clientList.Count == 0) {
            ads.ShowAd();
        }
    }

    void CheckNewClients() {
        if (list.clientList.Count < ClientController.clientQueueSize)
        {
            now = DateTime.Now;
            Debug.Log("now " + now);
            TimeSpan difference = now.Subtract(list.time);
            Debug.Log("difference " + difference);
            if (difference.Days >= 1)
            {
                Debug.Log("days " + difference.Days);
                list.time = DateTime.Now;
                list.CreateClientList((ClientController.clientQueueSize - list.clientList.Count));
            }
            else
            {
                int minutes = (difference.Hours * 60) + difference.Minutes + ClientController.nextClientProgress;
                Debug.Log("minutes " + minutes);
                if ((minutes / 5) >= 1 && (minutes / 5) > ClientController.clientQueueSize)
                {
                    Debug.Log("1 ");
                    list.time = DateTime.Now;
                    ClientController.nextClientProgress = minutes % 5;
                    Debug.Log("size " + (list.clientList.Count - ClientController.clientQueueSize));
                    list.CreateClientList((ClientController.clientQueueSize - list.clientList.Count));
                }
                else if ((minutes / 5) >= 1)
                {
                    Debug.Log("2 ");
                    list.time = DateTime.Now;
                    ClientController.nextClientProgress = minutes % 5;
                    list.CreateClientList(minutes / 5);
                }
            }
        }
    }

    void PopulateList() {
        Debug.Log("largo de la lista " + list.clientList.Count);

        float increment = 0;
        for(int i = 0; i < list.clientList.Count; ++i) {
           GameObject card = Instantiate(clientCard) as GameObject;
           card.transform.SetParent(transform);
           card.transform.localScale = card.transform.lossyScale;
           card.transform.localPosition = new Vector3(468f, -225f - increment, 0);

           actualClient = list.clientList[i];
           card.GetComponent<ClientCard>().GetInfo(list.clientList, i);
           increment += 425f;
       }
    }

}
