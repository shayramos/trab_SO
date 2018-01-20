using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AssemblyCSharp
{
    public class Grafico : MonoBehaviour
    {

        public GameObject linhap1, linhap2, linhap3, linhap4, linhap5;
        static int index = 0;
        public main script_main;
        Escalonador escalonador;

        // Use this for initialization
        void Start()
        {
            InvokeRepeating("ExecutarGrafico", 1, 1); //tempo
        }

        public void ExecutarGrafico()
        {
            if (script_main.GetActiveToggle(script_main.processoGroup).name == "FIFO")
            {
                escalonador = new Escalonador(new FIFOAlgoritmo());
            } else if(script_main.GetActiveToggle(script_main.processoGroup).name == "SJF")
            {
                escalonador = new Escalonador(new SJFAlgoritmo());
            } else if (script_main.GetActiveToggle(script_main.processoGroup).name == "Round Robin")
            {
                escalonador = new Escalonador(new RoundRobinAlgoritmo(2));
            } else if(script_main.GetActiveToggle(script_main.processoGroup).name == "EDF")
            {
                escalonador = new Escalonador(new EDFAlgoritmo());
            }

                if (index < 13)
            {
                GameObject tempo1 = linhap1.transform.GetChild(index++).gameObject;
                tempo1.SetActive(true);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}
