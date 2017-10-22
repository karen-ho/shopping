using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;
using DG.Tweening;
using UnityEngine.VR.WSA.Input;
using System.Collections;

public class VisaCheckout : MonoBehaviour {

    string STORE_ID = "59ec329ef36d28647542d5cd";
	string URL = "https://mighty-castle-94058.herokuapp.com/api/v1/stores/";
	string API = "/pay";

	public GameObject done;

	GestureRecognizer recognizer;

	void Start(){
		recognizer = new GestureRecognizer();

		recognizer.TappedEvent += OnInputClicked;

		recognizer.StartCapturingGestures();
	}

	void OnEnable(){
		//	AddItem (goCurrentSelected);

		recognizer = new GestureRecognizer();

		recognizer.TappedEvent += OnInputClicked;

		recognizer.StartCapturingGestures();
	}

	void OnDisable(){
		if(recognizer!=null)
			recognizer.TappedEvent -= OnInputClicked;
	}

	public void OnInputClicked(InteractionSourceKind source, int tapCount, Ray headRay)
	{
		CallCheckout ();
	}

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

		done.SetActive (true);
		gameObject.SetActive (false);
    }

	public void CallCheckout(){
		StartCoroutine (Checkout ());
	}
	 

	#if UNITY_EDITOR
	void Update(){
		if (Input.GetMouseButtonUp (0))
			CallCheckout ();
	}
	#endif 

}
