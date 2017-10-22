using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheController : MonoBehaviour {

	public GameObject goUI_AfterScan;
	public GameObject goUI_BloomInfo;
	public GameObject goUI_Preview;
	public GameObject goUI_Scan;
	public GameObject goUI_BloomCoupon;
	public GameObject goUI_ShoppingList;

	void EnableUI(GameObject g){
		g.SetActive (true);
	}

	void DisableUI(GameObject g){
		g.SetActive (false);
	}

	void Update(){
		if(Input.GetKeyUp(KeyCode.Z))
			EnableUI(goUI_AfterScan);
		if(Input.GetKeyUp(KeyCode.X))
			EnableUI(goUI_BloomInfo);
		if(Input.GetKeyUp(KeyCode.P))
			EnableUI(goUI_Preview);
		if(Input.GetKeyUp(KeyCode.C))
			EnableUI(goUI_BloomCoupon);
		if(Input.GetKeyUp(KeyCode.S))
			EnableUI(goUI_Scan);
		if(Input.GetKeyUp(KeyCode.L))
			EnableUI(goUI_ShoppingList);
	}

}
