using System;

namespace AssemblyCSharp
{
	public class SJFAlgoritmo : AlgoritmoEscalonamento
	{
		public SJFAlgoritmo ()
		{
		}

		public bool executar (Escalonador esc)
		{
			Processo executando = esc.Executando;
			executando.executar (1);
			return executando.Terminado;
		}

		public Processo obterProximoProcesso (Escalonador esc) {
			return esc.obterProximoProcessoSJF ();
		}

		public bool Preemptivo {
			get {
				return false;
			}
		}
	}

}

