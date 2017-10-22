using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour {

    public GameObject shoppingItemEntryPrefab;

    ShoppingListManager shoppingListManager;

	// Use this for initialization
	void Start () {
        shoppingListManager = GameObject.FindObjectOfType<ShoppingListManager>();
        if (shoppingListManager == null) {
            return;
        }

        List<string> shoppingList = shoppingListManager.GetItems();
        for (int i = 0; i < shoppingList.Count; i++) {
            GameObject go = (GameObject)Instantiate(shoppingItemEntryPrefab);
            go.transform.SetParent(this.transform, false);
            string name = shoppingList[i];
            go.transform.Find("Name").GetComponent<Text>().text = name;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
