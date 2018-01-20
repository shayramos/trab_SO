﻿using System.Collections;
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
        Processo processo;

        // Use this for initialization
        void Start()
        {
        }

        public int tempoChegada() {
            int tempoC = this.processo.tempoChegada;
            return tempoC;
        }


        public void ExecutarGrafico()
        {
			script_main.escalonador.update ();
            if (this.processo.idProcesso == 0)
            {
                if (script_main.escalonador.algoritmo.Preemptivo)
                {

                }
                else
                {
                    if (tempoChegada() < index)
                    {
                        for (int i = 0; i < this.processo.tempoExecucao; i++)
                        {
                            GameObject tempo1 = linhap1.transform.GetChild(index).gameObject;
                            tempo1.SetActive(true);
                            index++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < this.processo.tempoExecucao; i++)
                        {
                            GameObject tempo1 = linhap1.transform.GetChild(tempoChegada()).gameObject;
                            tempo1.SetActive(true);
                            index++;
                        }
                    }
                }
            }
            else if (this.processo.idProcesso == 1)
            {
                if (script_main.escalonador.algoritmo.Preemptivo)
                {

                }
                else
                {
                    if (tempoChegada() < index)
                    {
                        for (int i = 0; i < this.processo.tempoExecucao; i++)
                        {
                            GameObject tempo1 = linhap2.transform.GetChild(index).gameObject;
                            tempo1.SetActive(true);
                            index++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < this.processo.tempoExecucao; i++)
                        {
                            GameObject tempo1 = linhap2.transform.GetChild(tempoChegada()).gameObject;
                            tempo1.SetActive(true);
                            index++;
                        }
                    }
                }
            }
            else if (this.processo.idProcesso == 2)
            {
                if (script_main.escalonador.algoritmo.Preemptivo)
                {

                }
                {
                    if (tempoChegada() < index)
                    {
                        for (int i = 0; i < this.processo.tempoExecucao; i++)
                        {
                            GameObject tempo1 = linhap3.transform.GetChild(index).gameObject;
                            tempo1.SetActive(true);
                            index++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < this.processo.tempoExecucao; i++)
                        {
                            GameObject tempo1 = linhap3.transform.GetChild(tempoChegada()).gameObject;
                            tempo1.SetActive(true);
                            index++;
                        }
                    }
                }
            }
            else if (this.processo.idProcesso == 3)
            {
                if (script_main.escalonador.algoritmo.Preemptivo)
                {

                }
                {
                    if (tempoChegada() < index)
                    {
                        for (int i = 0; i < this.processo.tempoExecucao; i++)
                        {
                            GameObject tempo1 = linhap4.transform.GetChild(index).gameObject;
                            tempo1.SetActive(true);
                            index++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < this.processo.tempoExecucao; i++)
                        {
                            GameObject tempo1 = linhap4.transform.GetChild(tempoChegada()).gameObject;
                            tempo1.SetActive(true);
                            index++;
                        }
                    }
                }
            }
            else if (this.processo.idProcesso == 4)
            {
                if (script_main.escalonador.algoritmo.Preemptivo)
                {

                }
                {
                    if (tempoChegada() < index)
                    {
                        for (int i = 0; i < this.processo.tempoExecucao; i++)
                        {
                            GameObject tempo1 = linhap5.transform.GetChild(index).gameObject;
                            tempo1.SetActive(true);
                            index++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < this.processo.tempoExecucao; i++)
                        {
                            GameObject tempo1 = linhap5.transform.GetChild(tempoChegada()).gameObject;
                            tempo1.SetActive(true);
                            index++;
                        }
                    }
                }
            }
        }
        public void Comeca()
        {
			if (script_main.escalonador.Executando == null) {
				script_main.escalonador.inicializa ();
			}

			InvokeRepeating ("ExecutarGrafico", 1, 1);

        }


        // Update is called once per frame
        void Update()
        {

        }
			
    }
}
