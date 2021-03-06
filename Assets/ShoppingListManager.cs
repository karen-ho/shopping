﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingListManager : MonoBehaviour {

    List<string> shoppingList;

	// Use this for initialization
	void Start () {
        Debug.Log(GetItem(0));
	}

    void Init() {
        if (shoppingList != null) {
            return;
        }
        shoppingList = new List<string>();
        shoppingList.Add("coffee");
        shoppingList.Add("bananas");
    }

    public string GetItem(int index) {
        Init();

        return shoppingList[index];
    }

    public List<string> GetItems()
    {
        Init();
        return shoppingList;
    }
}
