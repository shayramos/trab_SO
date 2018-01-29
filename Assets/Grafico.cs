using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

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
            this.processo = script_main.escalonador.Executando;

            if (!script_main.escalonador.SemProcesso)
            {
                AtivaBarra(SaberLinha(), index);
            }
            else if (script_main.escalonador.ProcessosAEntrar == 0)
            {
                CancelInvoke("GraficoSemPreempcao");
            }
            script_main.escalonador.update();
            index++;
        }
       // int ind = 0;
        public void GraficoPreemptivo()
        {
            this.processo = script_main.escalonador.Executando; //pega o processo que ta executando na classe escalonador
            
            if (!script_main.escalonador.SemProcesso)
            {
                AtivaBarra(SaberLinha(), index);
                index++;
            }
            script_main.escalonador.updatePreemptivo();
            if ((this.processo.tempoExecucao - this.processo.tempoExecutado) >= 1)   //tempo de preempção
            {
                AtivaBarra(SaberLinha(), index);
                index++;
            }
            //script_main.escalonador.update();

			if (script_main.escalonador.ProcessosAEntrar == 0 && script_main.escalonador.listaProcesso.Count > 0)
            //if(script_main.escalonador.prioridades == null)
            {
                CancelInvoke("GraficoPreemptivo");
            }
            //ind++;
        }

        public void PintaBarra(GameObject linha, int index)
        {
            GameObject tempo = linha.transform.GetChild(index).gameObject;
            //tempo.GetComponent<Renderer>().material.color = new Color(255f, 0f, 0f);
            tempo.SetActive(true);
        }

        public void Comeca()
        {
			if (script_main.escalonador.Executando == null) {
                script_main.escalonador.inicializa ();          //escolhe o próximo processo
            }
            if (script_main.escalonador.algoritmo.Preemptivo)
            {
                InvokeRepeating("GraficoPreemptivo", 1, 0.5f);
            }
            else
            {
                InvokeRepeating("GraficoSemPreempcao", 1, 0.5f);
            }
        }

        public void Restart()
        {
            for(int i=0; i<linhap1.transform.childCount; i++)
            {
                linhap1.transform.GetChild(i).gameObject.SetActive(false);
                linhap2.transform.GetChild(i).gameObject.SetActive(false);
                linhap3.transform.GetChild(i).gameObject.SetActive(false);
                linhap4.transform.GetChild(i).gameObject.SetActive(false);
                linhap5.transform.GetChild(i).gameObject.SetActive(false);
            }
            index = 0;
            script_main.escalonador.Reiniciar();
            CancelInvoke("GraficoSemPreempcao");
            CancelInvoke("GraficoPreemptivo");
        }

        // Update is called once per frame
        void Update()
        {
            this.processo = script_main.escalonador.executando;
        }
			
    }
}
