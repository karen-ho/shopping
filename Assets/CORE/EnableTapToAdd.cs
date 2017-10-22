using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;
using DG.Tweening;
using UnityEngine.VR.WSA.Input;

public class EnableTapToAdd : MonoBehaviour {

	public GameObject goCurrentSelected;

 

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
		goCurrentSelected.SetActive (true);
		goCurrentSelected.GetComponent<TapToAdd> ().enabled = false;
		gameObject.SetActive (false);
	}

	#if UNITY_EDITOR
	void Update(){
		if (Input.GetMouseButtonUp (0)) {
			goCurrentSelected.SetActive (true);
			goCurrentSelected.GetComponent<TapToAdd> ().enabled = false;
			gameObject.SetActive (false);
		}
	}
	#endif 

}
