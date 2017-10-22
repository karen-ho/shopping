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

	public void AddItem(GameObject g){
		//TODO customize g
		rectBouncingCart.GetComponent<UIShaker> ().StopShake ();
		rectBouncingCart.DOLocalRotate (new Vector3 (0, 0, 180), 3.14f).OnComplete(Added);
	}

	public void Added(){
		rectBouncingCart.gameObject.SetActive (false);
		goDisplayAdded.SetActive (true);
	}

	void Start(){
	//	AddItem (goCurrentSelected);
	}

	public virtual void OnInputClicked(InputClickedEventData eventData)
	{
		AddItem (goCurrentSelected);
	}

}
