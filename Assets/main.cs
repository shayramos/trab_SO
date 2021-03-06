using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

namespace AssemblyCSharp
{
    public class main : MonoBehaviour
    {
 
        public GameObject canvasMemoria, canvasProcesso;
        public Toggle toggleMemoria, toggleProcesso;
        public GameObject createProcesso, usarDeadline, usarPrioridade;
        public ToggleGroup processoGroup, memoriaGroup;
        public InputField texecucao, tchegada, deadline;
        public Dropdown prioridade, idProcesso;
        public Escalonador escalonador;

        // Use this for initialization
        void Start()
        {
            canvasMemoria.SetActive(false);
            canvasProcesso.SetActive(false);
            createProcesso.SetActive(false);
            this.escalonador = new Escalonador(new FIFOAlgoritmo());           
        }


        // Update is called once per frame
        void Update()
        {
            canvasMemoria.SetActive(false);
            canvasProcesso.SetActive(false);
            if (toggleMemoria.isOn)
            {
                canvasMemoria.SetActive(true);
            }
            else if (toggleProcesso.isOn)
            {
                canvasProcesso.SetActive(true);
            }
            setAlgoritmo();
        }

        public Toggle GetActiveToggle(ToggleGroup groupToggle)
        {
            Toggle toggleName = groupToggle.ActiveToggles().FirstOrDefault();
            return toggleName;
        }
        
        public void ActiveCreateProcesso()
        {
            createProcesso.SetActive(true);
			bool canvasAct = canvasProcesso.activeSelf;
			canvasProcesso.SetActive (true); // garantir que canvasProcesso estava ativo antes de verificar o toggle ativo dele (evitar NullReferenceException)
			if (GetActiveToggle (processoGroup).name == "FIFO") {
				usarDeadline.SetActive (false);
				//usarPrioridade.SetActive (true);
			} else if (GetActiveToggle (processoGroup).name == "SJF") {
				usarDeadline.SetActive (false);
				//usarPrioridade.SetActive (true);
			} else if (GetActiveToggle (processoGroup).name == "RoundR") {
				usarDeadline.SetActive (false);
				//usarPrioridade.SetActive (true);
			} else if (GetActiveToggle (processoGroup).name == "EDF") {
				usarDeadline.SetActive (true);
				usarPrioridade.SetActive (false);
			} else {
				
			}
			canvasProcesso.SetActive(canvasAct);
        }

        public void CancelarCriar()
        {
            createProcesso.SetActive(false);
        }

        public void CriarProcesso()
        {
			bool canvasAct = canvasProcesso.activeSelf;
			canvasProcesso.SetActive (true);
            int tempoChegada = int.Parse(tchegada.text);
            tempoChegada = (tempoChegada >= escalonador.Tempo) ? tempoChegada : escalonador.Tempo + 1; // garantir que nenhum processo vai chegar antes do tempo atual. Esse sistema não prevê o futuro.
            if (GetActiveToggle(processoGroup).name == "FIFO")
            {
                this.escalonador.adicionaProcesso(new Processo(tempoChegada, int.Parse(texecucao.text), idProcesso.value));
            }
            else if (GetActiveToggle(processoGroup).name == "SJF")
            {
                this.escalonador.adicionaProcesso(new Processo(tempoChegada, int.Parse(texecucao.text), idProcesso.value));
            }
            else if (GetActiveToggle(processoGroup).name == "RoundR")
            {
				Processo p = new Processo (tempoChegada, int.Parse (texecucao.text), 0, idProcesso.value, prioridade.value);
				p.Modo = new RoundRobin ();
                this.escalonador.adicionaProcesso(p);

            }
            else if (GetActiveToggle(processoGroup).name == "EDF")
            {
                this.escalonador.adicionaProcesso(new Processo(tempoChegada, int.Parse(texecucao.text), int.Parse(deadline.text), idProcesso.value, prioridade.value));
            }
            createProcesso.SetActive(false);
			canvasProcesso.SetActive (canvasAct);
        }

		public void setAlgoritmo() {
			bool canvasAct = canvasProcesso.activeSelf;
			canvasProcesso.SetActive (true);
			if (GetActiveToggle(processoGroup).name == "FIFO")
			{
				this.escalonador.Algoritmo = new FIFOAlgoritmo();
			}
			else if (GetActiveToggle(processoGroup).name == "SJF")
			{
				this.escalonador.Algoritmo = new SJFAlgoritmo();
			}
			else if (GetActiveToggle(processoGroup).name == "RoundR")
			{
				this.escalonador.Algoritmo = new RoundRobinAlgoritmo(1);
			}
			else if (GetActiveToggle(processoGroup).name == "EDF")
			{
				this.escalonador.Algoritmo = new EDFAlgoritmo(1);
			}
			canvasProcesso.SetActive (canvasAct);
		}
    }
}