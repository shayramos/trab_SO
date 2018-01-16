using System;

namespace AssemblyCSharp
{
	public interface AlgoritmoEscalonamento
	{
		bool Preemptivo {
			get;
		}
		bool executar (Escalonador esc); // retornará true se for necessário trocar processo
		Processo obterProximoProcesso (Escalonador esc);
	}
}

