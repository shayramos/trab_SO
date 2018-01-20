using System;

namespace AssemblyCSharp
{
	public class FIFOAlgoritmo : AlgoritmoEscalonamento
	{
		public FIFOAlgoritmo ()
		{
			
		}

		public bool executar (Escalonador esc)
		{
			Processo executando = esc.Executando;
			executando.executar (1);
			return executando.Terminado;
		}

		public Processo obterProximoProcesso (Escalonador esc)
        {
			return esc.obterProximoProcessoPrioridades ();
		}

        public bool Preemptivo {
			get {
				return false;
			}
		}
	}
}

