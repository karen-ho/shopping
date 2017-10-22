using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisaCheckout : MonoBehaviour {

    string STORE_ID = "59ec329ef36d28647542d5cd";
	string URL = "https://mighty-castle-94058.herokuapp.com/api/v1/stores/";
	string API = "/pay";

   

    IEnumerator Checkout()
    {
        WWWForm form = new WWWForm();
        form.AddField("amount", "12.45");
        form.AddField("cardNumber", "4111111111111111");
        form.AddField("cardExpirationMonth", "08");
        form.AddField("cardExpirationYear", "19");

//        Hashtable headers = form.headers;
    //    byte[] rawData = form.data;

		WWW www = new WWW (URL + STORE_ID  + API, form);// rawData, headers);
        yield return www;

        // process result from pay
		if (www.error == null) {
			print (www.text);
		} else
			print (www.error);
    }

	public void CallCheckout(){
		StartCoroutine (Checkout ());
	}
	
	void Start(){
	//	CallCheckout ();
	}

}
