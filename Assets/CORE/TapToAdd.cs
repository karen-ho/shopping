using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;
using DG.Tweening;

public class TapToAdd : MonoBehaviour,IInputClickHandler {

	public GameObject goCurrentSelected;

	public RectTransform rectBouncingCart;

	public GameObject goDisplayAdded; 

	public Image goUI_Scan;

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

	void Start(){
	//	AddItem (goCurrentSelected);
	}

	public void OnInputClicked(InputClickedEventData eventData)
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
