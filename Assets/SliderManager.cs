using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderManager : MonoBehaviour {

	Slider thisSlider;
	float num = 0.01f;
	bool activating = false;


	// Use this for initialization
	void Start () {
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
			
	}

	public void activate(GameObject theObj, PointerEventData theData){
		if (theObj.name == "TestCube") {
			activating = true;
		}
	}

	public void deactivate(GameObject theObj, PointerEventData theData){
		if (theObj.name == "TestCube") {
			activating = false;
		}
	}

}
