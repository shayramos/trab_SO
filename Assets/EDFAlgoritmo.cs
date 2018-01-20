﻿using System;

namespace AssemblyCSharp
{
    public class EDFAlgoritmo : AlgoritmoEscalonamento
    {
        public EDFAlgoritmo()
        {
        }

        public bool executar(Escalonador esc)
        {
            Processo executando = esc.Executando;
            executando.executar(1);
            return executando.Terminado;
        }

        public Processo obterProximoProcesso(Escalonador esc)
        {
            return esc.obterProximoProcessoEDF();
        }

        public bool Preemptivo
        {
            get
            {
                return false;
            }
        }
    }
}