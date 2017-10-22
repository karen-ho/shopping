using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;
using DG.Tweening;
using UnityEngine.VR.WSA.Input;

public class TapToConditional : MonoBehaviour {

	public GameObject goMain;
	public GameObject goList;

	public GameObject goScan;

	public int iteration=0;

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
		LoadNextItem ();
	}

	#if UNITY_EDITOR
	void Update(){
		if (Input.GetMouseButtonUp (0))
			LoadNextItem ();
	}
	#endif 

	void LoadNextItem(){
		iteration++;
		if (iteration == 1) {
			goList.SetActive (false);
			goMain.SetActive (true);
			goScan.SetActive (false);
		} else {
			goList.SetActive (true);
			goMain.SetActive (false);
			goScan.SetActive (false);
		}
	}

}
