using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;
using DG.Tweening;
using UnityEngine.VR.WSA.Input;

public class TapToAdd : MonoBehaviour {

	public GameObject goCurrentSelected;

	public RectTransform rectBouncingCart;

	public GameObject goDisplayAdded; 

	public Image goUI_Scan;

	GestureRecognizer recognizer;

	public void AddItem(GameObject g){
		//TODO customize g
		rectBouncingCart.GetComponent<UIShaker> ().StopShake ();
		rectBouncingCart.DOLocalRotate (new Vector3 (0, 0, 180), 3.14f).OnComplete(Added);
	}

	public void Added(){
		rectBouncingCart.gameObject.SetActive (false);
		goDisplayAdded.SetActive (true);
		goUI_Scan.color = new Color (1, 1, 1, 0);
		goUI_Scan.transform.parent.gameObject.SetActive (true);
	
		goUI_Scan.DOFade (0.6f, 5f);
	}

	void OnEnable(){
	//	AddItem (goCurrentSelected);

		recognizer = new GestureRecognizer();

		recognizer.TappedEvent += OnInputClicked;

		recognizer.StartCapturingGestures();
	}

	public void OnInputClicked(InteractionSourceKind source, int tapCount, Ray headRay)
	{
		AddItem (goCurrentSelected);
	}

	#if UNITY_EDITOR
	void Update(){
		if (Input.GetMouseButton (0))
			AddItem (goCurrentSelected);
	}
	#endif 

}
