﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeAreaDeAtuacao
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeAreaDeAtuacao()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_AREA_ATUACAO ObterAreaDeAtuacaoPorId(int id)
        {
            return this.Contexto.MA_AREA_ATUACAO.Find(id);
        }

        public MA_AREA_ATUACAO ObterAreaDeAtuacaoPorNome(MA_AREA_ATUACAO areaatuacao)
        {
            return this.Contexto.MA_AREA_ATUACAO.Where(l => l.nome.ToLowerInvariant().Equals(areaatuacao.nome.ToLowerInvariant())).SingleOrDefault();
        }

        public List<MA_AREA_ATUACAO> ObterTodasAsAreasDeAtuacao()
        {
            return this.Contexto.MA_AREA_ATUACAO.ToList();
        }

        public List<MA_AREA_ATUACAO> ObterTodasAsAreasDeAtuacaosPorNome(String nome)
        {
            return this.Contexto.MA_AREA_ATUACAO.Where(l => l.nome.Equals(nome)).ToList();
        }

        public void InserirAreaDeAtuacao(MA_AREA_ATUACAO areaDeAtuacao)
        {
            if (!VerificarSeDescricaoDeAreaDeAtuacaoJaExiste(areaDeAtuacao))
            {
                this.Contexto.MA_AREA_ATUACAO.Add(areaDeAtuacao);
                this.Contexto.SaveChanges();
            }
        }

        public Boolean InserirAreaDeAtuacaoComRetorno(MA_AREA_ATUACAO areaDeAtuacao)
        {
            if (!VerificarSeDescricaoDeAreaDeAtuacaoJaExiste(areaDeAtuacao))
            {
                try
                {
                    this.Contexto.MA_AREA_ATUACAO.Add(areaDeAtuacao);
                    this.Contexto.SaveChanges();

                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_AREA_ATUACAO.Count();
        }

        public void RemoverAreaDeAtuacao(MA_AREA_ATUACAO areaDeAtuacao)
        {
            this.Contexto.MA_AREA_ATUACAO.Remove(areaDeAtuacao);
            this.Contexto.SaveChanges();
        }

        public void AtualizarAreaDeAtuacao(MA_AREA_ATUACAO areaDeAtuacao)
        {
            if (!VerificarSeDescricaoDeAreaDeAtuacaoJaExiste(areaDeAtuacao))
            {
                this.Contexto.Entry(areaDeAtuacao).State = EntityState.Modified;
                this.Contexto.SaveChanges();
            }
        }

        public Boolean AtualizarAreaDeAtuacaoComRetorno(MA_AREA_ATUACAO areaDeAtuacao)
        {
            if (!VerificarSeDescricaoDeAreaDeAtuacaoJaExiste(areaDeAtuacao))
            {
                try
                {
                    this.Contexto.Entry(areaDeAtuacao).State = EntityState.Modified;
                    this.Contexto.SaveChanges();

                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Boolean VerificarSeDescricaoDeAreaDeAtuacaoJaExiste(MA_AREA_ATUACAO areaatuacao)
        {
            if (ObterAreaDeAtuacaoPorNome(areaatuacao) != null)
            {
                return true;
            }
            return false;
        }
    }
}
