﻿using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;
using System;

namespace MimAcher.WebService.Controllers
{
    public class UsuarioController : Controller
    {
        public GestorDeUsuario GestorDeUsuario { get; set; }

        public UsuarioController()
        {
            this.GestorDeUsuario = new GestorDeUsuario();
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_USUARIO> listausuariooriginal = this.GestorDeUsuario.ObterTodosOsUsuarios();
            List<Usuario> listausuario = new List<Usuario>();

            foreach (MA_USUARIO u in listausuariooriginal)
            {
                Usuario usuario = new Usuario();

                usuario.CodUsuario = u.cod_usuario;
                usuario.EMail = u.e_mail;
                usuario.Senha = u.senha;
                
                listausuario.Add(usuario);
            }

            JsonResult jsonResult = Json(new
            {
                data = listausuario
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult Add(List<Usuario> listausuario)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listausuario == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                MA_USUARIO usuario = new MA_USUARIO();

                usuario.e_mail = listausuario[0].EMail;
                usuario.senha = listausuario[0].Senha;

                //Parametriza o usuário com nivel de acesso web e código de status 1
                usuario.cod_acesso = 1;
                usuario.cod_status = 1;

                try
                {
                    if (GestorDeUsuario.VerificarExistenciaDeUsuarioPorEmail(usuario.e_mail))
                    {
                        jsonResult = Json(new
                        {
                            codigo = -1
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        Boolean resultado = this.GestorDeUsuario.InserirUsuarioComRetorno(usuario);

                        if (resultado)
                        {
                            jsonResult = Json(new
                            {
                                codigo = usuario.cod_usuario
                            }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            jsonResult = Json(new
                            {
                                codigo = -1
                            }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                catch(Exception e)
                {
                    jsonResult = Json(new
                    {
                        erro = e.InnerException.ToString(),
                        codigo = -1
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult Update(List<Usuario> listausuario)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listausuario == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                MA_USUARIO usuario = new MA_USUARIO();

                usuario.cod_usuario = listausuario[0].CodUsuario;
                usuario.e_mail = listausuario[0].EMail;
                usuario.senha = listausuario[0].Senha;
                usuario.cod_acesso = 1;
                usuario.cod_status = 1;

                try
                {
                    Boolean resultado = this.GestorDeUsuario.AtualizarUsuarioComRetorno(usuario);

                    if (resultado)
                    {
                        jsonResult = Json(new
                        {
                            codigo = usuario.cod_usuario
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        jsonResult = Json(new
                        {
                            codigo = -1
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch(Exception e)
                {
                    jsonResult = Json(new
                    {
                        erro = e.InnerException.ToString(),
                        codigo = -1
                    }, JsonRequestBehavior.AllowGet);
                }

                
            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult Delete(List<Usuario> listausuario)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listausuario == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                try
                {
                    if (GestorDeUsuario.VerificarSeExisteUsuarioPorId(listausuario[0].CodUsuario))
                    {
                        MA_USUARIO usuario = GestorDeUsuario.ObterUsuarioPorId(listausuario[0].CodUsuario);

                        MA_USUARIO usuariomodificado = new MA_USUARIO();

                        usuariomodificado.cod_usuario = usuario.cod_usuario;
                        usuariomodificado.e_mail = usuario.e_mail;
                        usuariomodificado.senha = usuario.senha;

                        //Código acesso padrão para mobile
                        usuariomodificado.cod_acesso = 1;

                        //Inativa o usuário
                        usuariomodificado.cod_status = 2;

                        if (this.GestorDeUsuario.AtualizarUsuarioComRetorno(usuariomodificado))
                        {
                            jsonResult = Json(new
                            {
                                codigo = usuariomodificado.cod_usuario
                            }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            jsonResult = Json(new
                            {
                                codigo = -1
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
                catch (Exception e)
                {
                    jsonResult = Json(new
                    {
                        erro = e.InnerException.ToString(),
                        codigo = -1
                    }, JsonRequestBehavior.AllowGet);
                }


            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}