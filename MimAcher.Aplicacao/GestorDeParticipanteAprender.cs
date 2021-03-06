﻿using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;
using System;

namespace MimAcher.Aplicacao
{
    public class GestorDeParticipanteAprender
    {
        public RepositorioDeAprendizadoDeParticipante RepositorioDeAprendizadoDeParticipante { get; set; }

        public GestorDeParticipanteAprender()
        {
            this.RepositorioDeAprendizadoDeParticipante = new RepositorioDeAprendizadoDeParticipante();
        }

        public MA_PARTICIPANTE_APRENDER ObterAprendizadoDoParticipantePorId(int id)
        {
            return this.RepositorioDeAprendizadoDeParticipante.ObterAprendizadoDoParticipantePorId(id);
        }

        public List<MA_PARTICIPANTE_APRENDER> ObterTodosOsRegistros()
        {
            return this.RepositorioDeAprendizadoDeParticipante.ObterTodosOsRegistros();
        }

        public List<MA_PARTICIPANTE_APRENDER> ObterTodosOsRegistrosAtivos()
        {
            return this.RepositorioDeAprendizadoDeParticipante.ObterTodosOsRegistrosAtivos();
        }

        public List<MA_PARTICIPANTE_APRENDER> ObterTodosOsAprendizadoDeParticipantePorPorItemPaginadosPorVinteRegistros(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            return this.RepositorioDeAprendizadoDeParticipante.ObterTodosOsAprendizadoDeParticipantePorPorItemPaginadosPorVinteRegistros(participanteaprender);
        }

        public List<MA_PARTICIPANTE_APRENDER> ObterTodosOsAprendizadoDeParticipantePorPorItemPaginadosPorVinteRegistros(int idItem)
        {
            return this.RepositorioDeAprendizadoDeParticipante.ObterTodosOsAprendizadoDeParticipantePorPorItemPaginadosPorVinteRegistros(idItem);
        }
                
        public MA_PARTICIPANTE_APRENDER ObterAprendizadoDeParticipantePorItemEParticipante(int idItem, int idParticipante)
        {
            return this.RepositorioDeAprendizadoDeParticipante.ObterAprendizadoDeParticipantePorItemEParticipante(idItem, idParticipante);
        }

        public void InserirNovoAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            this.RepositorioDeAprendizadoDeParticipante.InserirNovoAprendizadoDeParticipante(participanteaprender);
        }

        public Boolean InserirNovoAprendizadoDeParticipanteComRetorno(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            return this.RepositorioDeAprendizadoDeParticipante.InserirNovoAprendizadoDeParticipanteComRetorno(participanteaprender);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeAprendizadoDeParticipante.BuscarQuantidadeRegistros();
        }

        public void RemoverAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            this.RepositorioDeAprendizadoDeParticipante.RemoverAprendizadoDeParticipante(participanteaprender);
        }

        public void AtualizarAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            this.RepositorioDeAprendizadoDeParticipante.AtualizarAprendizadoDeParticipante(participanteaprender);
        }

        public Boolean AtualizarAprendizadoDeParticipanteComRetorno(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            return this.RepositorioDeAprendizadoDeParticipante.AtualizarAprendizadoDeParticipanteComRetorno(participanteaprender);
        }

        public Boolean VerificarSeExisteRelacaoUsuarioAprenderPorIdDaRelacao(int idUsuarioaprender)
        {
            if(ObterAprendizadoDoParticipantePorId(idUsuarioaprender) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean VerificarSeExisteRelacaoUsuarioPorItemEParticipante(int idItem, int idParticipante)
        {
            if(ObterAprendizadoDeParticipantePorItemEParticipante(idItem, idParticipante) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean VerificarSeExisteAprendizadoDeParticipantePorIdDeItem(int idItem)
        {
            return this.RepositorioDeAprendizadoDeParticipante.VerificarSeExisteAprendizadoDeParticipantePorIdDeItem(idItem);
        }
    }

}
