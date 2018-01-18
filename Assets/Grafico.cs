using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grafico : MonoBehaviour {

	public GameObject linhap1, linhap2, linhap3, linhap4, linhap5;
    static int index = 0;
    // Use this for initialization
    void Start()
    {
     //   Invoke("executando", 2);
        InvokeRepeating("executando", 1, 1);
    }

    public void executando()
    {
        if (index < 13)
        {
            GameObject tempo1 = linhap1.transform.GetChild(index++).gameObject;
            tempo1.SetActive(true);
        }
    }
	
    // Update is called once per frame
	void Update () {
		
	}
}
