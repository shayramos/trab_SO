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
        Processo processo;
        GameObject line;

        // Use this for initialization
        void Start()
        {
        }

        public int TempoChegada() {
            int tempoC = this.processo.tempoChegada;
            return tempoC;
        }

        public int TempoExecucao()
        {
            int tempoE = this.processo.tempoExecucao;
            return tempoE;
        }

        public GameObject SaberLinha()
        {
            if (this.processo.idProcesso == 0)
                line = this.linhap1;
            else if (this.processo.idProcesso == 1)
                line = this.linhap2;
            else if (this.processo.idProcesso == 2)
                line = this.linhap3;
            else if (this.processo.idProcesso == 3)
                line = this.linhap4;
            else if (this.processo.idProcesso == 4)
                line = this.linhap5;
            return line;
        }

        public void AtivaBarra(GameObject linha, int index)
        {
            GameObject tempo = linha.transform.GetChild(index).gameObject;
            tempo.SetActive(true);
        }
        public void GraficoPreemptivo()
        {
            script_main.escalonador.update();

        }
        public int LocalEntradaProcesso()
        {
            int tempo;
            if (TempoChegada() < index)
            {
                tempo = index;
            }
            else
            {
                tempo = TempoChegada();
            }
            return tempo;
        }
        public void GraficoSemPreempcao()
        {
            while (processo.tempoExecutado < TempoExecucao())
            {
                script_main.escalonador.update();
                AtivaBarra(SaberLinha(), LocalEntradaProcesso());
                index++;
            }
        }
       
        public void Comeca()
        {
			if (script_main.escalonador.Executando == null) {
				script_main.escalonador.inicializa ();
            }
            //if (!(script_main.escalonador.algoritmo.executar(script_main.escalonador))) {
            if (script_main.escalonador.algoritmo.Preemptivo)
                {
                    InvokeRepeating("GraficoPreemptivo", 1, 1);
                }
                else
                {
                    //InvokeRepeating("GraficoSemPreempcao", 1, 1);
                    Invoke("GraficoSemPreempcao", 1);
                }
            //}
			
        }


        // Update is called once per frame
        void Update()
        {
            this.processo = script_main.escalonador.executando;
        }
			
    }
}
