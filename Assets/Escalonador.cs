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

        int it;
        public int Iterador
        {
            set
            {
               it = prioridades.Length-1;
            }
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
            for (int i = prioridades.Length - 1; i >= 0; i--){
                IEnumerator<Processo> procEnum = prioridades[i].GetEnumerator();
                procEnum.MoveNext();
                Processo temp = procEnum.Current;
                if (prioridades[i].Count == 0) { }
                else
                {
                    if (prioridades[i].Count == 1)
                    {
                        temp = prioridades[i][0];
                        prioridades[i].Remove(temp);//remover
                        return temp;
                    }
                    else if(prioridades[i].Count > 1)
                    {
                        while (procEnum.MoveNext())
                        {
                            if (temp.TempoExecucao >= procEnum.Current.TempoExecucao)
                            {
                                temp = procEnum.Current;
                            }
                        }
                        prioridades[i].Remove(temp);//remover
                    }
                }
                if (temp != null) return temp;
            }
                throw new InvalidOperationException("Não existem processos na fila de espera!");
            
        }

        bool entrou = true;
        public Processo obterProximoProcessoRoundR()
        {
            //while (prioridades != null) {
            //for (int i = prioridades.Length - 1; i >= 0; i--)
            
            while (it >= 0)
            {
                    if (prioridades[it].Count > 0)
                    {
                        //if(entrou)
                        IEnumerator<Processo> procEnum = prioridades[it].GetEnumerator();
                        procEnum.MoveNext();
                        Processo temp = procEnum.Current;
                        //prioridades[it][0]; //encontre o primeiro não nulo => encontre o primeiro elemento

                        if ((temp.tempoExecucao - temp.tempoExecutado) == 0)
                            prioridades[it].Remove(temp);

                    //if (procEnum.MoveNext()) {    //Se tiver mais de um com a mesma prioridade.
                    //Processo last = temp;
                    //procEnum.MoveNext();
                    //temp = procEnum.Current;
                    //}
                     it--;
                    if(temp!=null)
                        return temp; 
                    }
            }
            it = prioridades.Length-1;
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

            for (int i = 0; i < this.prioridades.Length; i++)
            {
                this.prioridades[i].Clear();
            }
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

