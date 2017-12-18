using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class main : MonoBehaviour {

	public GameObject canvasMemoria, canvasProcesso;
	public GameObject toggleMemoria, toggleProcesso;

	// Use this for initialization
	void Start () {
		canvasMemoria.SetActive (false);
		canvasProcesso.SetActive (false);
		toggleMemoria.GetComponent<Toggle> ().isOn = false;
		toggleProcesso.GetComponent<Toggle> ().isOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		canvasMemoria.SetActive (false);
		canvasProcesso.SetActive (false);
		if (toggleMemoria.GetComponent<Toggle> ().isOn) {
			canvasMemoria.SetActive (true);
		}
		else if (toggleProcesso.GetComponent<Toggle> ().isOn) {
			canvasProcesso.SetActive (true);
		}
	}

}
