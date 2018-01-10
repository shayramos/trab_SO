using System;

namespace AssemblyCSharp
{
	public class SJFAlgoritmo : AlgoritmoEscalonamento
	{
		public SJFAlgoritmo ()
		{
		}

		public void executar (Escalonador esc)
		{
			Processo exe;
			exe = esc.obterProximoProcessoSJF ();
			exe.executar (exe.TempoExecucao);
			esc.Tempo += exe.TempoExecucao;
		}
	}
}

