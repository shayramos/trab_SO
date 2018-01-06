using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class main : MonoBehaviour {

	public GameObject canvasMemoria, canvasProcesso;
	public Toggle toggleMemoria, toggleProcesso;//, togglePFIFO, togglePSJF, togglePRound, togglePEDF;
	public GameObject createProcesso, usarDeadline, usarPrioridade;
	public ToggleGroup processoGroup, memoriaGroup;
	//static Toggle toggleName;

	// Use this for initialization
	void Start () {
		canvasMemoria.SetActive (false);
		canvasProcesso.SetActive (false);
		createProcesso.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		canvasMemoria.SetActive (false);
		canvasProcesso.SetActive (false);
		if (toggleMemoria.isOn) {
			canvasMemoria.SetActive (true);
		}
		else if (toggleProcesso.isOn) {
			canvasProcesso.SetActive (true);
		}
	}

	public Toggle GetActiveToggle(ToggleGroup groupToggle){
		Toggle toggleName = groupToggle.ActiveToggles().FirstOrDefault();
		return toggleName;
	}

	public void ActiveCreateProcesso() {
		createProcesso.SetActive (true);
		if (GetActiveToggle (processoGroup).name == "FIFO") {
			usarDeadline.SetActive (false);
			usarPrioridade.SetActive (true);
		} else if (GetActiveToggle (processoGroup).name == "SJF") {
			usarDeadline.SetActive (false);
			usarPrioridade.SetActive (true);
		} else if (GetActiveToggle (processoGroup).name == "Round Robin") {
			usarDeadline.SetActive (false);
			usarPrioridade.SetActive (true);
		} else if (GetActiveToggle (processoGroup).name == "EDF") {
			usarDeadline.SetActive (true);
			usarPrioridade.SetActive (false);
		}
	}

	public void CancelarCriar(){
		createProcesso.SetActive (false);
	}

	public void Criar(){
		
	}

}
