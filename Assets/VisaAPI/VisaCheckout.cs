using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisaCheckout : MonoBehaviour {

    string STORE_ID = "59ec329ef36d28647542d5cd";
    string URL = "https://mighty-castle-94058.herokuapp.com/api/stores/";

    // Use this for initialization
    void Start () {
		
	}

    IEnumerable Checkout()
    {
        WWWForm form = new WWWForm();
        form.addField("amount", "12.45");
        form.addField("cardNumber", "4111111111111111");
        form.addField("cardExpirationMonth", "08");
        form.addField("cardExpirationYear", "19");

        Hashtable headers = form.headers;
        byte[] rawData = form.data;

        WWW www = new WWW(URL + STORE_ID, rawData, headers);
        yield return www;

        // process result from pay
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
