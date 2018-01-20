using System;
using System.Collections.Generic;
using System.Collections;

namespace AssemblyCSharp
{
	public class Escalonador
	{
		private List<Processo>[] prioridades;
		private int tempoPreempcaoIni, tempo;
		public AlgoritmoEscalonamento algoritmo;
		public Processo executando;
		private bool preempcao;
		private readonly int tempoPreempcao;


        public Escalonador (AlgoritmoEscalonamento algoritmo)
		{
			this.tempo = 0;
			this.tempoPreempcao = (algoritmo.Preemptivo) ? 5 : 0; //se algoritmo for preemptivo, 
			prioridades = new List<Processo>[5]; //Dez prioridades?
			for (int i = 0; i < prioridades.Length; i++) {
				prioridades [i] = new List<Processo> ();
			}
			this.algoritmo = algoritmo;
		}

		public void adicionaProcesso(Processo processo)
		{
			prioridades [processo.Prioridade].Add (processo);
		}

		public void inicializa()
        {
			this.executando = algoritmo.obterProximoProcesso (this);
		}

		public void update()
		{
			tempo++;
			if (algoritmo.executar (this)) {
				this.tempoPreempcaoIni = this.tempo;
				this.preempcao = true;
			}
			if (this.preempcao) {
				if ((this.tempo - this.tempoPreempcaoIni) == this.tempoPreempcao) {
					this.preempcao = false;
					this.executando = algoritmo.obterProximoProcesso (this);
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
			return temp;
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
        
	}
}

