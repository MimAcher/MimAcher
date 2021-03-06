﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;

namespace MimAcher.WebService.Controllers
{
    public class UsuarioParticipanteController : Controller
    {
        public GestorDeParticipante GestorDeParticipante { get; set; }
        public GestorDeUsuario GestorDeUsuario { get; set; }
        public GestorDeAplicacao GestorDeAplicacao { get; set; }

        public UsuarioParticipanteController()
        {
            this.GestorDeParticipante = new GestorDeParticipante();
            this.GestorDeUsuario = new GestorDeUsuario();
            this.GestorDeAplicacao = new GestorDeAplicacao();
        }

        // GET: UsuarioParticipante
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(List<UsuarioParticipante> listausuarioparticipante)
        {            
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listausuarioparticipante == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                MA_USUARIO usuario = new MA_USUARIO();

                usuario.e_mail = listausuarioparticipante[0].EMail;
                usuario.senha = listausuarioparticipante[0].Senha;
                //Torna o usuário com acesso mobile no sistema
                usuario.cod_acesso = 1;
                //Torna o usuário ativo no sistema
                usuario.cod_status = 1;

                Boolean resultado = this.GestorDeUsuario.InserirUsuarioComRetorno(usuario);

                if (resultado)
                {
                    MA_PARTICIPANTE participante = new MA_PARTICIPANTE();
                                        
                    participante.cod_usuario = usuario.cod_usuario;
                    participante.cod_campus = listausuarioparticipante[0].CodCampus;
                    participante.nome = listausuarioparticipante[0].Nome;
                    participante.telefone = listausuarioparticipante[0].Telefone;
                    participante.dt_nascimento = (DateTime)listausuarioparticipante[0].DtNascimento;
                    participante.geolocalizacao = DbGeography.FromText("POINT(" + GestorDeAplicacao.RetornaDadoSemVigurla(listausuarioparticipante[0].Latitude.ToString()) + "  " + GestorDeAplicacao.RetornaDadoSemVigurla(listausuarioparticipante[0].Longitude.ToString()) + ")");

                    try
                    {
                        if (this.GestorDeParticipante.InserirParticipanteComRetorno(participante))
                        {
                            jsonResult = Json(new
                            {
                                codigo = participante.cod_participante
                            }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            GestorDeUsuario.RemoverUsuario(usuario);

                            jsonResult = Json(new
                            {
                                codigo = -1
                            }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    catch(Exception e)
                    {
                        GestorDeUsuario.RemoverUsuario(usuario);

                        jsonResult = Json(new
                        {
                            codigo = -1,
                            erro = e.InnerException.ToString()
                        }, JsonRequestBehavior.AllowGet);                        
                    }
                    
                }
                else
                {
                    jsonResult = Json(new
                    {
                        codigo = -1
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Update(List<UsuarioParticipante> listausuarioparticipante)
        {            
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listausuarioparticipante == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                MA_USUARIO usuario = new MA_USUARIO();

                usuario.e_mail = listausuarioparticipante[0].EMail;
                usuario.senha = listausuarioparticipante[0].Senha;
                //O código de acesso é 1 para determinar que é só ACesso Mobile
                usuario.cod_acesso = 1;
                //Torna o usuário ativo no sistema
                usuario.cod_status = 1;

                Boolean resultado = this.GestorDeUsuario.VerificarExistenciaDeUsuarioPorEmailESenha(usuario.e_mail, usuario.senha);

                if (resultado)
                {
                    MA_PARTICIPANTE participante = new MA_PARTICIPANTE();
                    
                    participante.cod_usuario = usuario.cod_usuario;
                    participante.cod_campus = listausuarioparticipante[0].CodParticipante;
                    participante.nome = listausuarioparticipante[0].Nome;
                    participante.telefone = listausuarioparticipante[0].Telefone;
                    participante.dt_nascimento = (DateTime)listausuarioparticipante[0].DtNascimento;
                    participante.geolocalizacao = DbGeography.FromText("POINT(" + GestorDeAplicacao.RetornaDadoSemVigurla(listausuarioparticipante[0].Latitude.ToString()) + "  " + GestorDeAplicacao.RetornaDadoSemVigurla(listausuarioparticipante[0].Longitude.ToString()) + ")");

                    try
                    {
                        this.GestorDeParticipante.AtualizarParticipante(participante);

                        jsonResult = Json(new
                        {
                            codigo = participante.cod_participante
                        }, JsonRequestBehavior.AllowGet);
                    }
                    catch(Exception e)
                    {
                        jsonResult = Json(new
                        {
                            codigo = -1,
                            erro = e.InnerException.ToString()
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    jsonResult = Json(new
                    {
                        codigo = -1
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}