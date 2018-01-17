using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grafico : MonoBehaviour {

	//public GameObject enemy;
	public GameObject p1, p2, p3, p4, p5;
	int positionX, positionY;

	// Use this for initialization
	void Start () {
		GameObject quad = GameObject.CreatePrimitive (PrimitiveType.Quad);
		GameObject barra = new GameObject ();
		quad.transform.parent = barra.transform;
		barra.name = "Barra";
		barra.transform.parent = GameObject.Find ("Grafico").transform;
		barra.transform.localPosition = new Vector3 (-100, 80);
		barra.transform.localScale = new Vector3 (50, 30);

	//p1.transform.SetAsLastSibling ();
	//	for (int i = 0; i < 5; i++) {
	//		Instantiate(enemy);
	//	}
	}

	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
