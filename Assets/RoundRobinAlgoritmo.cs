using System;

namespace AssemblyCSharp
{
	public class RoundRobinAlgoritmo : AlgoritmoEscalonamento
	{
		private Processo executando;
		private int quantum;
		private int inicio;

		public RoundRobinAlgoritmo (int quantum)
		{
			this.quantum = quantum;
		}

		public bool executar(Escalonador esc)
		{
			if (this.executando != esc.Executando) {
				this.executando = esc.Executando;
				inicio = esc.Tempo;
				this.executando.executar (1);
			} else {
			}
			return (esc.Tempo - this.inicio) == this.quantum;
        }

        public Processo obterProximoProcesso (Escalonador esc) {
			return esc.obterProximoProcessoRoundR();
		}

		public int Quantum 
		{
			get {
				return quantum;
			}
			set {
				quantum = value;
			}
		}

		public bool Preemptivo {
			get {
				return true;
			}
		}
	}
}

