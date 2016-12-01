﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDePartipanteHobbie
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDePartipanteHobbie()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_PARTICIPANTE_HOBBIE ObterHobbieDoParticipantePorId(int id)
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Find(id);
        }

        public MA_PARTICIPANTE_HOBBIE ObterParticipanteHobbiePorItemEParticipante(MA_PARTICIPANTE_HOBBIE participantehobbie)
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Where(l => l.cod_participante == participantehobbie.cod_participante && l.cod_item == participantehobbie.cod_item).SingleOrDefault();
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterHobbiesDeParticipantePorIdDeItem(int id_item)
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Where(l => l.cod_item == id_item).ToList();
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterTodosOsHobbiesDeParticipantePorPorItemPaginadosPorVinteRegistros(MA_PARTICIPANTE_HOBBIE participantehobbie)
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Where(l => l.cod_item == participantehobbie.cod_item && l.cod_s_relacao == 1).OrderBy(l => l.cod_participante).Skip(participantehobbie.cod_p_hobbie).Take(20).ToList();
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterTodosOsHobbiesDeParticipantePorPorItemPaginadosPorVinteRegistros(int id_item)
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Where(l => l.cod_item == id_item && l.cod_s_relacao == 1).OrderBy(l => l.cod_participante).Skip(id_item).Take(20).ToList();
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterTodosOsRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.ToList();
        }

        public void InserirNovoParticipanteHobbie(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteHobbie(hobbieparticipante))
            {
                this.Contexto.MA_PARTICIPANTE_HOBBIE.Add(hobbieparticipante);
                this.Contexto.SaveChanges();
            }
            else
            {
                MA_PARTICIPANTE_HOBBIE participantehobbieconferencia = ObterParticipanteHobbiePorItemEParticipante(hobbieparticipante);

                if (participantehobbieconferencia.cod_s_relacao != hobbieparticipante.cod_s_relacao)
                {
                    AtualizarAprendizadoDeHobbieSemConferencia(hobbieparticipante);
                }
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Count();
        }

        public void RemoverHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbiedoparticipante)
        {
            this.Contexto.MA_PARTICIPANTE_HOBBIE.Remove(hobbiedoparticipante);
            this.Contexto.SaveChanges();
        }

        public void AtualizarHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteHobbie(hobbieparticipante))
            {
                AtualizarAprendizadoDeHobbieSemConferencia(hobbieparticipante);
            }
            else
            {
                MA_PARTICIPANTE_HOBBIE participantehobbieconferencia = ObterParticipanteHobbiePorItemEParticipante(hobbieparticipante);

                if (participantehobbieconferencia.cod_s_relacao != hobbieparticipante.cod_s_relacao)
                {
                    AtualizarAprendizadoDeHobbieSemConferencia(hobbieparticipante);
                }
            }
        }

        public Boolean AtualizarHobbieDoParticipanteComRetorno(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteHobbie(hobbieparticipante))
            {
                AtualizarAprendizadoDeHobbieSemConferencia(hobbieparticipante);

                return true;
            }
            else
            {
                MA_PARTICIPANTE_HOBBIE participantehobbieconferencia = ObterParticipanteHobbiePorItemEParticipante(hobbieparticipante);

                if (participantehobbieconferencia.cod_s_relacao != hobbieparticipante.cod_s_relacao)
                {
                    AtualizarAprendizadoDeHobbieSemConferencia(hobbieparticipante);

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void AtualizarAprendizadoDeHobbieSemConferencia(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            MA_PARTICIPANTE_HOBBIE participantehobbie = new MA_PARTICIPANTE_HOBBIE();

            this.Contexto.Entry(hobbieparticipante).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }

        public Boolean VerificarSeExisteRelacaoDeParticipanteHobbie(MA_PARTICIPANTE_HOBBIE participantehobbie)
        {
            if (ObterParticipanteHobbiePorItemEParticipante(participantehobbie) != null)
            {
                return true;
            }
            return false;
        }

        public Boolean VerificarSeExisteHobbieDeParticipantePorIdDeItem(int id_item)
        {
            if(ObterHobbiesDeParticipantePorIdDeItem(id_item).Count() > 0)
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
