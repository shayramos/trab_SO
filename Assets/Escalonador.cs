using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Escalonador
	{
		public List<Processo> listaProcesso;
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
			listaProcesso = new List<Processo>(); 
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
                    listaProcesso.Add(processo);
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
						Processo temp;
						temp = this.executando;
						this.executando = algoritmo.obterProximoProcesso (this);
						this.preempcao = false;
						if (!temp.Terminado) {
							this.listaProcesso.Add (temp);
						}
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
				if (listaProcesso.Count > 0) {
				Processo temp = listaProcesso.Find(x => x != null); //encontre o primeiro não nulo => encontre o primeiro elemento
					listaProcesso.RemoveAt (0);
					return temp;
				}
			throw new InvalidOperationException ("Não existem processos na fila de espera!");
		}
        
        public Processo obterProximoProcessoSJF()
		{
            
                IEnumerator<Processo> procEnum = listaProcesso.GetEnumerator();
                procEnum.MoveNext();
                Processo temp = procEnum.Current;
                if (listaProcesso.Count == 0) { }
                else
                {
                    if (listaProcesso.Count == 1)
                    {
                        temp = listaProcesso[0];
                        listaProcesso.Remove(temp);//remover
                        return temp;
                    }
                    else if(listaProcesso.Count > 1)
                    {
                        while (procEnum.MoveNext())
                        {
                            if (temp.TempoExecucao >= procEnum.Current.TempoExecucao)
                            {
                                temp = procEnum.Current;
                            }
                        }
                        listaProcesso.Remove(temp);//remover
                    }
                }
                if (temp != null) return temp;
                throw new InvalidOperationException("Não existem processos na fila de espera!");
            
        }

        bool entrou = true;
        public Processo obterProximoProcessoRoundR()
        {           
			if (listaProcesso.Count > 0) {
				Processo temp = listaProcesso.Find(x => x != null); //encontre o primeiro não nulo => encontre o primeiro elemento
				listaProcesso.Remove (temp);
				if (temp != null)
					return temp; 
			}         
            throw new InvalidOperationException("Nova rodada!");
        }

    

        public Processo obterProximoProcessoEDF() {
            Processo temp = new Processo(1,1,1,1,1);  //Coloquei só pra não dar erro
            return temp;
        }

        public void Reiniciar()
        {
            this.tempo = 0;
            this.toBeLoaded.Clear();
            semProcesso = true;
            this.listaProcesso.Clear();
            
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

