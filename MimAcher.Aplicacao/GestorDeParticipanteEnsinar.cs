﻿using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeParticipanteEnsinar
    {
        public RepositorioDeParticipanteEnsinar RepositorioDeParticipanteEnsinar { get; set; }

        public GestorDeParticipanteEnsinar()
        {
            this.RepositorioDeParticipanteEnsinar = new RepositorioDeParticipanteEnsinar();
        }

        public MA_PARTICIPANTE_ENSINAR ObterRelacaoDoQueOParticipanteEnsinaPorId(int id)
        {
            return this.RepositorioDeParticipanteEnsinar.ObterRelacaoDoQueOParticipanteEnsinaPorId(id);
        }

        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsRegistros()
        {
            return this.RepositorioDeParticipanteEnsinar.ObterTodosOsRegistros();
        }

        public void InserirNovoEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            this.RepositorioDeParticipanteEnsinar.InserirNovoEnsinamentoDeParticipante(participanteensinar);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeParticipanteEnsinar.BuscarQuantidadeRegistros();
        }

        public void RemoverEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            this.RepositorioDeParticipanteEnsinar.RemoverEnsinamentoDeParticipante(participanteensinar);
        }

        public void AtualizarEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            this.RepositorioDeParticipanteEnsinar.AtualizarEnsinamentoDeParticipante(participanteensinar);
        }
    }
}
