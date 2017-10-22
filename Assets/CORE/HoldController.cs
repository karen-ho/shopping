using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;
using DG.Tweening;
using UnityEngine.VR.WSA.Input;
using HoloToolkit.Unity;

public class HoldController : MonoBehaviour {

	GestureRecognizer recognizer;

	HandsTrackingManager htm;

	public GameObject goReviews;
	public GameObject goCenter;
	public GameObject goCoupons;
	public int scrollval;

	int handDetected = -1; Vector3 lastp;

	void Awake(){
		htm = GetComponent<HandsTrackingManager> ();
	}

	void OnEnable(){
		//	AddItem (goCurrentSelected);

		recognizer = new GestureRecognizer();

		recognizer.HoldStartedEvent += HoldStarted;
		recognizer.HoldCompletedEvent += HoldCompleted;

		recognizer.StartCapturingGestures();


	}

	public void HoldStarted(InteractionSourceKind source, Ray headRay)
	{
		if (source == InteractionSourceKind.Hand)
		{
			lastp = htm.trackingObject [htm.lastdetected].transform.position;
		}
	}

	public void HoldCompleted(InteractionSourceKind source, Ray headRay)
	{
		if (source == InteractionSourceKind.Hand)
		{
			Vector3 p = htm.trackingObject [htm.lastdetected].transform.position;
			if (lastp.x < p.x) {
				scrollval--;
				if (scrollval < 0)
					scrollval = 0;
			}else if (lastp.x > p.x) {
				scrollval++;
				if (scrollval > 2)
					scrollval = 2;
			}

			if (scrollval == 0) {
				goReviews.SetActive (true);
				goCenter.SetActive (false);
				goCoupons.SetActive (false);
			} else if (scrollval == 1) {
				goReviews.SetActive (false);
				goCenter.SetActive (true);
				goCoupons.SetActive (false);
			} else if (scrollval == 2) {
				goReviews.SetActive (false);
				goCenter.SetActive (false);
				goCoupons.SetActive (true);
			}
		}
	}


}
