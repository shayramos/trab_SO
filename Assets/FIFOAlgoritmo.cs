using System;

namespace AssemblyCSharp
{
	public class FIFOAlgoritmo : AlgoritmoEscalonamento
	{
		public FIFOAlgoritmo ()
		{
			
		}

		public void executar (Escalonador esc)
		{
			Processo executando = esc.obterProximoProcessoPrioridades ();
			executando.executar (executando.TempoExecucao);
			esc.Tempo += executando.TempoExecucao;
		}
	}
}

