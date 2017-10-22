using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeAway : MonoBehaviour {
 
	void Start () {
		GetComponent<Image>().DOFade (0, 3.14f).OnComplete(DeactivateMe);
	}

	void DeactivateMe(){
		gameObject.SetActive (false);
	}
	
	 
}
