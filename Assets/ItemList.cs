using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour {

    public GameObject itemEntryPrefab;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 2; i++) {
            GameObject go = (GameObject)Instantiate(itemEntryPrefab);
            go.transform.SetParent(this.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
