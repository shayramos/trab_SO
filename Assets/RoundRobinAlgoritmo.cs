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
            Processo executando = esc.Executando;
            executando.executar(1);
            return executando.Terminado;

            /*if (!this.executando.Equals (esc.Executando)) {
				this.executando = esc.Executando;
				inicio = esc.Tempo;
			}
			return (esc.Tempo - this.inicio) == this.quantum;
	    */
        }

        public Processo obterProximoProcesso (Escalonador esc) {
			return esc.obterProximoProcessoRoundR();
		}

		public int Quantum 
		{
			get {
				return quantum;
			}
		}

		public bool Preemptivo {
			get {
				return true;
			}
		}
	}
}

