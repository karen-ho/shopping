using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollGestureUIFaker : MonoBehaviour {

	public RectTransform rtContainer;
	public Slider slider;

	public void OnSliderChanged(){
		if (slider.value == 0)
			LoadReviews ();
		else if (slider.value == 2)
			LoadCoupon ();
		else if (slider.value == 1)
			LoadPrompt ();
	}

	public void LoadReviews(){
		SetRT (0);
	}

	public void LoadPrompt(){
		SetRT (-1280);
	}

	public void LoadCoupon(){
		SetRT (-2560);
	}

	void SetRT(int x){
		Vector2 lp = rtContainer.anchoredPosition;
		rtContainer.anchoredPosition = new Vector3 (x, lp.y);//, lp.z);
	}


}
