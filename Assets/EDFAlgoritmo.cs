using System;

namespace AssemblyCSharp
{
    public class EDFAlgoritmo : AlgoritmoEscalonamento
    {
        private int quantum;
		private Processo executando;
		private int inicio;

        public EDFAlgoritmo(int quantum)
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

        public Processo obterProximoProcesso(Escalonador esc)
        {
            return esc.obterProximoProcessoEDF();
        }

        public bool Preemptivo
        {
            get
            {
                return true;
            }
        }
    }
}