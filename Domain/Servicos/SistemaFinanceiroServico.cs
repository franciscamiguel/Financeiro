using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Servicos
{
    public class SistemaFinanceiroServico : ISistemaFinanceiroServico
    {
        private readonly InterfaceSistemaFinanceiro _interfaceSistemaFinanceiro;

        public SistemaFinanceiroServico(InterfaceSistemaFinanceiro interfaceSistemaFinanceiro)
        {
            _interfaceSistemaFinanceiro = interfaceSistemaFinanceiro;
        }

        public void AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidarPropriedadeString(sistemaFinanceiro.Nome, "Nome");

            if (valido)
                _interfaceSistemaFinanceiro.Add(sistemaFinanceiro);
        }

        public void AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            var valido = sistemaFinanceiro.ValidarPropriedadeString(sistemaFinanceiro.Nome, "Nome");

            if (valido)
                _interfaceSistemaFinanceiro.Update(sistemaFinanceiro);
        }
    }
}
