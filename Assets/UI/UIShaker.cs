using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIShaker : MonoBehaviour {
 
	void Start () {
		Shake ();
	}

	void Shake(){
		GetComponent<RectTransform> ().DOShakePosition (Random.Range (1.37f, 3.14f),20f).OnComplete (Shake);
	}
	  
}
