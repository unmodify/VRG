using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class HostSliderManager : MonoBehaviour {

	public NetworkManager manager;
	Slider thisSlider;
	float num = 0.01f;
	bool activating = false;

	bool hostFlag = false;


	// Use this for initialization
	void Start () {
		manager = GameObject.Find("Network Manager").GetComponent<NetworkManager> ();
		thisSlider = gameObject.GetComponent<Slider> ();
	}

	// Update is called once per frame
	void Update () {
		if (activating) {
			thisSlider.value += num;
		} else {
			thisSlider.value -= num;
		}

		thisSlider.value = Mathf.Max (0f, thisSlider.value);
		thisSlider.value = Mathf.Min (1f, thisSlider.value);

		if (thisSlider.value == 1 && !hostFlag) {
			manager.StartHost ();
			hostFlag = true;
		}


	}

	public void activate(GameObject theObj, PointerEventData theData){
		if (theObj.name == "Host Slider") {
			activating = true;
		}
	}

	public void deactivate(GameObject theObj, PointerEventData theData){
		if (theObj.name == "Host Slider") {
			activating = false;
		}
	}
}
