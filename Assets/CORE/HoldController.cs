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

	public ScrollGestureUIFaker sguf;

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
				sguf.LoadReviews ();
			}else if (lastp.x > p.x) {
				sguf.LoadCoupon ();
			}
		}
	}


}
