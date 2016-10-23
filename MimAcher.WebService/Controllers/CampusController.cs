﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MimAcher.Infra;
using MimAcher.Aplicacao;
using MimAcher.WebService.Models;

namespace MimAcher.WebService.Controllers
{
    public class CampusController : Controller
    {
        public GestorDeCampus GestorDeCampus { get; set; }

        public CampusController()
        {
            this.GestorDeCampus = new GestorDeCampus();
        }

        // GET: Campus
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<MA_CAMPUS> listacampusoriginal = GestorDeCampus.ObterTodosOsCampus();
            List<Campus> listacampus = new List<Campus>();

            foreach (MA_CAMPUS nc in listacampusoriginal)
            {
                Campus campus = new Campus();

                campus.cod_campus = nc.cod_campus;
                campus.local = nc.local;

                listacampus.Add(campus);
            }

            JsonResult jsonResult = Json(new
            {
                data = listacampus
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult Add(List<Campus> listacampus)
        {
            JsonResult jsonResult;

            //Verifica se o registro é inválido e se sim, retorna com erro.
            if (listacampus == null)
            {
                jsonResult = Json(new
                {
                    success = false
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                foreach (Campus cp in listacampus)
                {
                    MA_CAMPUS campus = new MA_CAMPUS();
                    campus.local = cp.local;

                    GestorDeCampus.InserirCampus(campus);
                }

                jsonResult = Json(new
                {
                    success = true
                }, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
        }
    }
}