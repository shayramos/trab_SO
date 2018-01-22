using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Escalonador
	{
		public List<Processo>[] prioridades;
		private int tempoPreempcaoIni, tempo;
		public AlgoritmoEscalonamento algoritmo;
		public Processo executando;
		private bool preempcao;
		private readonly int tempoPreempcao;
		private bool semProcesso;
        private List<Processo> toBeLoaded;

        public Escalonador (AlgoritmoEscalonamento algoritmo)
		{
			this.tempo = 0;
            toBeLoaded = new List<Processo>();
			this.tempoPreempcao = (algoritmo.Preemptivo) ? 1 : 0; //se algoritmo for preemptivo, 
			prioridades = new List<Processo>[4]; //Dez prioridades?
			for (int i = 0; i < prioridades.Length; i++) {
				prioridades [i] = new List<Processo> ();
			}
			this.algoritmo = algoritmo;
			semProcesso = true;
		}

		public void adicionaProcesso(Processo processo)
		{
			toBeLoaded.Add (processo);
		}

        public void carregaProcesso(int tempo)
        {
            foreach (Processo processo in toBeLoaded)
            {
                if (processo.tempoChegada == tempo)
                {
                    prioridades[processo.prioridade].Add(processo);
                    semProcesso = false;
                }
            }
            toBeLoaded.RemoveAll(x => x.tempoChegada == tempo); //remove todos cujos tempos de chegada sejam iguais ao tempo atual
        }

		public void inicializa()
        {
            carregaProcesso(0);
			this.executando = algoritmo.obterProximoProcesso (this);
		}

		public void update()
		{
			tempo++;
            carregaProcesso(tempo);
			try {
				if (algoritmo.executar (this)) {
					this.tempoPreempcaoIni = this.tempo;
					this.preempcao = true;
				}
				if (this.preempcao) {
					if ((this.tempo - this.tempoPreempcaoIni) == this.tempoPreempcao) {
						this.preempcao = false;
						if (!this.executando.Terminado) {
							this.prioridades [executando.prioridade].Add (this.executando);
						}
						this.executando = algoritmo.obterProximoProcesso (this);
					}
				}
			}
			catch (InvalidOperationException)
            {
                if (this.executando.Terminado)
                {
                    semProcesso = true;
                }
                
			}
		}

		public Processo obterProximoProcessoPrioridades()
		{
			for (int i = prioridades.Length - 1; i >= 0; i--) {
				if (prioridades [i].Count > 0) {
                    Processo temp = prioridades [i] [0]; //encontre o primeiro não nulo => encontre o primeiro elemento
					prioridades [i].RemoveAt (0);
					return temp;
				}
			}
			throw new InvalidOperationException ("Não existem processos na fila de espera!");
		}

		public Processo obterProximoProcessoSJF()
		{
			IEnumerator<Processo> procEnum = prioridades[0].GetEnumerator();
			Processo temp = procEnum.Current;
			while (procEnum.MoveNext ()) {
				if (temp.TempoExecucao > procEnum.Current.TempoExecucao) {
					temp = procEnum.Current;
				}
			}
			if (temp != null) {
				return temp;
			} else {
				throw new InvalidOperationException ("");
			}
		}

        public Processo obterProximoProcessoEDF() {
            Processo temp = new Processo(1,1,1,1,1);  //Coloquei só pra não dar erro
            return temp;
        }

        public int Tempo {
			get {
				return this.tempo;
			}
			set {
				tempo = value;
			}
		}
		public Processo Executando {
			get {
				return this.executando;
			}
		}

		public AlgoritmoEscalonamento Algoritmo {
			get {
				return this.algoritmo;
			}
			set {
				this.algoritmo = value;
			}
		}

		public bool SemProcesso {
			get {
				return this.semProcesso;
			}
		}
        
        public int ProcessosAEntrar
        {
            get
            {
                return toBeLoaded.Count;
            }
        }
	}
}

