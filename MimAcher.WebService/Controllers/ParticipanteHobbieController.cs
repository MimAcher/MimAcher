﻿using System.Collections.Generic;
using System.Web.Mvc;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using MimAcher.WebService.Models;
using System;

namespace MimAcher.WebService.Controllers
{
    public class ParticipanteHobbieController : Controller
    {
        public GestorDeHobbieDeParticipante GestorDeHobbieDeParticipante { get; set; }

        public ParticipanteHobbieController()
        {
            GestorDeHobbieDeParticipante = new GestorDeHobbieDeParticipante();
        }

        // GET: ParticipanteHobbie
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_PARTICIPANTE_HOBBIE> listaparticipantehobbieoriginal = GestorDeHobbieDeParticipante.ObterTodosOsRegistrosAtivos();
            List<ParticipanteHobbie> listaparticipantehobbie = new List<ParticipanteHobbie>();

            foreach (MA_PARTICIPANTE_HOBBIE pe in listaparticipantehobbieoriginal)
            {
                ParticipanteHobbie participantehobbie = new ParticipanteHobbie();

                participantehobbie.CodPHobbie = pe.cod_p_hobbie;
                participantehobbie.CodParticipante = pe.cod_participante;
                participantehobbie.CodItem = pe.cod_item;

                listaparticipantehobbie.Add(participantehobbie);
            }

            JsonResult jsonResult = Json(new
            {
                data = listaparticipantehobbie
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<ParticipanteHobbie> listaparticipantehobbie)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipantehobbie == null)
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
                MA_PARTICIPANTE_HOBBIE participantehobbie = new MA_PARTICIPANTE_HOBBIE();

                participantehobbie.cod_participante = listaparticipantehobbie[0].CodParticipante;
                participantehobbie.cod_item = listaparticipantehobbie[0].CodItem;

                //Informa que a relação estará ativa
                participantehobbie.cod_status = 1;

                try
                {
                    Boolean resultado = GestorDeHobbieDeParticipante.InserirNovoParticipanteHobbieComRetorno(participantehobbie);

                    if (resultado)
                    {
                        jsonResult = Json(new
                        {
                            codigo = participantehobbie.cod_p_hobbie
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
        
        [HttpPost]
        public ActionResult Delete(List<ParticipanteHobbie> listaparticipantehobbie)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipantehobbie == null)
            {
                jsonResult = Json(new
                {
                    codigo = -1
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (this.GestorDeHobbieDeParticipante.VerificarSeExisteHobbieDeParticipantePorItemEParticipante(listaparticipantehobbie[0].CodItem, listaparticipantehobbie[0].CodParticipante))
                {
                    try
                    {
                        MA_PARTICIPANTE_HOBBIE participantehobbie = this.GestorDeHobbieDeParticipante.ObterParticipanteHobbiePorItemEParticipante(listaparticipantehobbie[0].CodItem, listaparticipantehobbie[0].CodParticipante);

                        if (participantehobbie.cod_status == 1)
                        {
                            MA_PARTICIPANTE_HOBBIE participantehobbiemodificado = new MA_PARTICIPANTE_HOBBIE();

                            participantehobbiemodificado.cod_p_hobbie = participantehobbie.cod_p_hobbie;
                            participantehobbiemodificado.cod_participante = participantehobbie.cod_participante;
                            participantehobbiemodificado.cod_item = participantehobbie.cod_item;

                            //Marca a relação como inativa
                            participantehobbiemodificado.cod_status = 2;

                            try
                            {
                                Boolean resultado = this.GestorDeHobbieDeParticipante.AtualizarHobbieDoParticipanteComRetorno(participantehobbiemodificado);

                                if (resultado)
                                {
                                    jsonResult = Json(new
                                    {
                                        codigo = participantehobbiemodificado.cod_p_hobbie
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
                            catch (Exception e)
                            {
                                jsonResult = Json(new
                                {
                                    erro = e.InnerException.ToString(),
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
                    catch(Exception e)
                    {
                        jsonResult = Json(new
                        {
                            erro = e.InnerException.ToString(),
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

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Match(List<ParticipanteHobbie> listaparticipantehobbie)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listaparticipantehobbie == null)
            {
                jsonResult = Json(new
                {
                    listaparticipantehobbie = ""
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (this.GestorDeHobbieDeParticipante.VerificarSeExisteHobbieDeParticipantePorIdDeItem(listaparticipantehobbie[0].CodItem))
                {
                    try
                    {
                        List<MA_PARTICIPANTE_HOBBIE> listaphobbie = this.GestorDeHobbieDeParticipante.ObterTodosOsHobbiesDeParticipantePorPorItemPaginadosPorVinteRegistros(listaparticipantehobbie[0].CodItem);

                        //Reinicia lista de aprendizado de participante
                        listaparticipantehobbie = new List<ParticipanteHobbie>();

                        foreach (MA_PARTICIPANTE_HOBBIE mapa in listaphobbie)
                        {
                            ParticipanteHobbie pa = new ParticipanteHobbie();

                            pa.CodPHobbie = mapa.cod_p_hobbie;
                            pa.CodItem = mapa.cod_item;
                            pa.CodParticipante = mapa.cod_participante;

                            listaparticipantehobbie.Add(pa);
                        }

                        jsonResult = Json(new
                        {
                            listaparticipantehobbie = listaparticipantehobbie
                        }, JsonRequestBehavior.AllowGet);
                    }
                    catch(Exception e)
                    {
                        jsonResult = Json(new
                        {
                            erro = e.InnerException.ToString(),
                            listaparticipantehobbie = ""
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    jsonResult = Json(new
                    {
                        listaparticipantehobbie = ""
                    }, JsonRequestBehavior.AllowGet);
                }

            }

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}