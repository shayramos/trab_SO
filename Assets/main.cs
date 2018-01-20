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
        //public List<Processo> ProcessList;
        public Escalonador escalonador;

        // Use this for initialization
        void Start()
        {
            canvasMemoria.SetActive(false);
            canvasProcesso.SetActive(false);
            createProcesso.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            //print(tchegada.text);
            //print(texecucao.text);
            //print(deadline.text);
            //print(prioridade.value);

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
        }

        public Toggle GetActiveToggle(ToggleGroup groupToggle)
        {
            Toggle toggleName = groupToggle.ActiveToggles().FirstOrDefault();
            return toggleName;
        }
        
        public void ActiveCreateProcesso()
        {
            createProcesso.SetActive(true);
            if (GetActiveToggle(processoGroup).name == "FIFO")
            {
                usarDeadline.SetActive(false);
                usarPrioridade.SetActive(true);
            }
            else if (GetActiveToggle(processoGroup).name == "SJF")
            {
                usarDeadline.SetActive(false);
                usarPrioridade.SetActive(true);
            }
            else if (GetActiveToggle(processoGroup).name == "Round Robin")
            {
                usarDeadline.SetActive(false);
                usarPrioridade.SetActive(true);
            }
            else if (GetActiveToggle(processoGroup).name == "EDF")
            {
                usarDeadline.SetActive(true);
                usarPrioridade.SetActive(false);
            }
        }

        public void CancelarCriar()
        {
            createProcesso.SetActive(false);
        }

        public void CriarProcesso()
        {
            if (GetActiveToggle(processoGroup).name == "FIFO")
            {
                this.escalonador = new Escalonador(new FIFOAlgoritmo());
                this.escalonador.adicionaProcesso(new Processo(int.Parse(tchegada.text), int.Parse(texecucao.text), idProcesso.value, prioridade.value));
                //ProcessList.Add(new Processo(int.Parse(tchegada.text), int.Parse(texecucao.text), prioridade.value));
            }
            else if (GetActiveToggle(processoGroup).name == "SJF")
            {
                this.escalonador = new Escalonador(new SJFAlgoritmo());
                this.escalonador.adicionaProcesso(new Processo(int.Parse(tchegada.text), int.Parse(texecucao.text), idProcesso.value, prioridade.value));
            }
            else if (GetActiveToggle(processoGroup).name == "Round Robin")
            {
                this.escalonador = new Escalonador(new RoundRobinAlgoritmo(2));
                this.escalonador.adicionaProcesso(new Processo(int.Parse(tchegada.text), int.Parse(texecucao.text), idProcesso.value, prioridade.value));
            }
            else if (GetActiveToggle(processoGroup).name == "EDF")
            {
                this.escalonador = new Escalonador(new EDFAlgoritmo(2));
                this.escalonador.adicionaProcesso(new Processo(int.Parse(tchegada.text), int.Parse(texecucao.text), int.Parse(deadline.text), idProcesso.value, prioridade.value));
            }
        }
    }
}