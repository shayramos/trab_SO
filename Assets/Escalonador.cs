using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class Escalonador
	{
		List<Processo> processos;
		List<Processo>[] prioridades;

		public Escalonador ()
		{
			processos = new List<Processo> ();

		}
	}
}

