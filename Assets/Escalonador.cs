using System;
using System.Collections.Generic;
using System.Collections;

namespace AssemblyCSharp
{
	public class Escalonador
	{
		Queue<Processo>[] prioridades;


		public Escalonador ()
		{
			prioridades = new Queue<Processo>[10]; //Dez prioridades?
			for (int i = 0; i < prioridades.Length; i++) {
				prioridades [i] = new Queue<Processo> ();
			}

		}

		public void adicionaProcesso(Processo processo)
		{
			prioridades [processo.Prioridade].Enqueue (processo);
		}

		public Processo obterProximoProcesso()
		{
			for (int i = prioridades.Length - 1; i >= 0; i--) {
				if (prioridades [i].Count > 0) {
					return prioridades [i].Dequeue ();
				}
			}
			throw new InvalidOperationException ("Não existem processos na fila de espera!"); 
		}

		public void executar() 
		{
			Processo executando = obterProximoProcesso();

			adicionaProcesso (executando);
		}

	}
}

