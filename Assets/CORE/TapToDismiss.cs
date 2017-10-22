using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;
using DG.Tweening;
using UnityEngine.VR.WSA.Input;

public class TapToDismiss : MonoBehaviour {
 
	public GameObject goNextItem; 
 
	public bool firsttime=true;
	GestureRecognizer recognizer;

	public GameObject goNextItemNotFirstTime;

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
		LoadNextItem ();
	}

	#if UNITY_EDITOR
	void Update(){
		if (Input.GetMouseButtonUp (0))
			LoadNextItem ();
	}
	#endif 

	void LoadNextItem(){
		if (firsttime) {
			goNextItem.SetActive (true);
			gameObject.SetActive (false);
			firsttime = false;
		} else {
			goNextItemNotFirstTime.SetActive (true);
			gameObject.SetActive (false);
		}
	}

}
