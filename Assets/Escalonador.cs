using System;
using System.Collections.Generic;
using System.Collections;

namespace AssemblyCSharp
{
	public class Escalonador
	{
		private List<Processo>[] prioridades;
		private int tempo;
		private AlgoritmoEscalonamento algoritmo;



		public Escalonador (AlgoritmoEscalonamento algoritmo)
		{
			this.tempo = 0;
			prioridades = new List<Processo>[10]; //Dez prioridades?
			for (int i = 0; i < prioridades.Length; i++) {
				prioridades [i] = new List<Processo> ();
			}
			this.algoritmo = algoritmo;
		}

		public void adicionaProcesso(Processo processo)
		{
			prioridades [processo.Prioridade].Add (processo);
		}

		public Processo obterProximoProcessoPrioridades()
		{
			for (int i = prioridades.Length - 1; i >= 0; i--) {
				if (prioridades [i].Count > 0) {
					Processo temp = prioridades [i].Find (x => x != null); //encontre o primeiro não nulo => encontre o primeiro elemento
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

		public void executar() 
		{
			algoritmo.executar (this);
		}

		public int Tempo {
			get {
				return this.tempo;
			}
			set {
				tempo = value;
			}
		}


	}
}

