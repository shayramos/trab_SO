using System;

namespace AssemblyCSharp
{
	public class Processo
	{
		private int tempoChegada, tempoExecucao, deadline, prioridade, tempoExecutado;
		private ModoOperacao modo;

		public Processo (int tempoChegada,int tempoExecucao, int deadline, int prioridade, ModoOperacao modo)
		{
			this.tempoChegada = tempoChegada;
			this.tempoExecucao = tempoExecucao;
			this.deadline = deadline;
			this.prioridade = prioridade;
			this.tempoExecutado = 0;
		}
			
		public void executar(int quantum) {
			this.tempoExecutado += this.modo.executar(quantum);
			this.deadline -= this.modo.executar(quantum);
		}
	}
}

