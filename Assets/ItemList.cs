using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        for (int i = 0; i < 2; i++) {
            GameObject go = (GameObject)Instantiate(shoppingItemEntryPrefab);
            go.transform.SetParent(this.transform, false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
