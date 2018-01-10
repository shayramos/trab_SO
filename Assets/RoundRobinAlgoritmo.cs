using System;

namespace AssemblyCSharp
{
	public class RoundRobinAlgoritmo : AlgoritmoEscalonamento
	{

		private int quantum;

		public RoundRobinAlgoritmo (int quantum)
		{
			this.quantum = quantum;
		}

		public void executar(Escalonador esc)
		{
			Processo executando = esc.obterProximoProcessoPrioridades ();
			executando.executar (quantum);
			if (!executando.Terminado) {
				esc.adicionaProcesso (executando);
			}
		}
	}
}

