﻿using System;
using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeParticipante
    {
        public RepositorioDeParticipante RepositorioDeParticipante { get; set; }

        public GestorDeParticipante()
        {
            this.RepositorioDeParticipante = new RepositorioDeParticipante();
        }

        public int ObterIdDeUltimoParticipante()
        {
            return this.RepositorioDeParticipante.ObterIdDeUltimoParticipante();
        }

        public MA_PARTICIPANTE ObterParticipantePorId(int id)
        {
            return this.RepositorioDeParticipante.ObterParticipantePorId(id);
        }

        public MA_PARTICIPANTE ObterUsuarioAtivoDeParticipantePorId(int id)
        {
            return this.RepositorioDeParticipante.ObterUsuarioAtivoDeParticipantePorId(id);
        }

        public MA_PARTICIPANTE ObterParticipantePorIdDeUsuario(int idUsuario)
        {
            return this.RepositorioDeParticipante.ObterParticipantePorIdDeUsuario(idUsuario);
        }

        public List<MA_PARTICIPANTE> ObterTodosOsParticipantes()
        {
            return this.RepositorioDeParticipante.ObterTodosOsParticipantes();
        }

        public List<MA_PARTICIPANTE> ObterTodosOsParticipantesDeUsuariosAtivos()
        {
            return this.RepositorioDeParticipante.ObterTodosOsParticipantesDeUsuariosAtivos();
        }

        public List<MA_PARTICIPANTE> ObterTodosOsParticipantesPorNome(String nome)
        {
            return this.RepositorioDeParticipante.ObterTodosOsParticipantesPorNome(nome);
        }

        public MA_PARTICIPANTE ObterParticipantePorEmail(String email)
        {
            return this.RepositorioDeParticipante.ObterParticipantePorEmail(email);
        }

        public void InserirParticipante(MA_PARTICIPANTE participante)
        {
            this.RepositorioDeParticipante.InserirParticipante(participante);
        }
        
        public Boolean InserirParticipanteComRetorno(MA_PARTICIPANTE participante)
        {
            return this.RepositorioDeParticipante.InserirParticipanteComRetorno(participante);            
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeParticipante.BuscarQuantidadeRegistros();
        }

        public void RemoverParticipante(MA_PARTICIPANTE participante)
        {
            this.RepositorioDeParticipante.RemoverParticipante(participante);
        }

        public void AtualizarParticipante(MA_PARTICIPANTE participante)
        {
            this.RepositorioDeParticipante.AtualizarParticipante(participante);
        }

        public Boolean AtualizarParticipanteComRetorno(MA_PARTICIPANTE participante)
        {
            return this.RepositorioDeParticipante.AtualizarParticipanteComRetorno(participante);
        }

        public Boolean VerificarSeUsuarioJaTemVinculoComAlgumParticipante(MA_PARTICIPANTE participante)
        {
            return this.RepositorioDeParticipante.VerificarSeUsuarioJaTemVinculoComAlgumParticipante(participante);
        }

        public Boolean VerificarSeParticipanteExiste(int codParticipante)
        {
            return this.RepositorioDeParticipante.VerificarSeParticipanteExiste(codParticipante);
        }

        public Boolean VerificarSeUsuarioJaTemVinculoComAlgumParticipante(int idUsuario)
        {
            List<MA_PARTICIPANTE> listaparticipante = ObterTodosOsParticipantes();

            foreach (MA_PARTICIPANTE participante in listaparticipante)
            {
                if (participante.cod_usuario == idUsuario)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean VerificarSeExisteParticipantePorId(int idParticipante)
        {
            if (ObterParticipantePorId(idParticipante) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}