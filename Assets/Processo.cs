using System;

namespace AssemblyCSharp
{
	public class Processo
    {
		public int tempoChegada, tempoExecucao, deadline, prioridade, tempoExecutado, idProcesso;
		private ModoOperacao modo;
		private bool terminado = false;
        
		public Processo (int tempoChegada, int tempoExecucao, int deadline, int idProcesso, int prioridade = 0)
		{
			this.tempoChegada = tempoChegada;
			this.tempoExecucao = tempoExecucao;
			this.deadline = deadline;
            this.idProcesso = idProcesso;
            this.tempoExecutado = 0;
			this.modo = new ComDeadline ();
			this.prioridade = prioridade;
		}
			
		public Processo (int tempoChegada, int tempoExecucao, int idProcesso, int prioridade = 0)
		{
			this.tempoChegada = tempoChegada;
			this.tempoExecucao = tempoExecucao;
			this.tempoExecutado = 0;
            this.idProcesso = idProcesso;
            this.modo = new RoundRobin ();
			this.prioridade = prioridade;
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

		public int TempoExecutado 
		{
			get {
				return this.tempoExecutado;
			}

		}

		public bool Terminado 
		{
			get {
				return this.terminado;
			}
		}

		public int TempoExecucao
		{
			get {
				return this.tempoExecucao;
			}
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

