using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientMenuManager : MonoBehaviour {

    private ClientController list;
    private Clients actualClient;

    public GameObject clientCard;

	// Use this for initialization
	void Start () {
	    list = FindObjectOfType<ClientController>();
        PopulateList();
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
