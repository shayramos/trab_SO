using System;

namespace AssemblyCSharp
{
	public class Processo
	{
		private int tempoChegada, tempoExecucao, deadline, prioridade, tempoExecutado;
		private ModoOperacao modo;
		private bool terminado = false;

		public Processo (int tempoChegada,int tempoExecucao, int deadline)
		{
			this.tempoChegada = tempoChegada;
			this.tempoExecucao = tempoExecucao;
			this.deadline = deadline;
			this.tempoExecutado = 0;
			this.modo = new ComDeadline ();
		}
			
		public Processo (int tempoChegada,int tempoExecucao)
		{
			this.tempoChegada = tempoChegada;
			this.tempoExecucao = tempoExecucao;
			this.deadline = null;
			this.tempoExecutado = 0;
			this.modo = new RoundRobin ();
		}

		public void executar(int quantum)
		{
			if (this.terminado)
				return;
			this.tempoExecutado += (quantum < (this.tempoExecucao - this.tempoExecutado) ) ? quantum : this.tempoExecucao - this.tempoExecutado;
			this.deadline += this.modo.atualizarDeadline(quantum);
			if (this.tempoExecutado == this.tempoExecucao)
			{
				this.terminado = true;
			}
		}
		public int TempoExecutado {
			get {
				return this.tempoExecutado;
			}

		}

		public bool Terminado {
			get {
				return this.terminado;
			}

		}
		public int TempoExecucao
		{
			get {return this.tempoExecucao;}
		}

		public int Prioridade {
			get {
				return this.prioridade;
			}
			set {
				prioridade = value;
			}
		}
	}

		
}

