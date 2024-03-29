﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Presupuestos.Models;
using Presupuestos.Comun;

namespace Presupuestos.Controllers
{
    public class ProyectosController : Controller
    {
        private dbPresupuestosEntities db = new dbPresupuestosEntities();

        // GET: /Proyectos/
        public ActionResult Index()
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            var tblproyectos = db.TblProyectos.Include(t => t.TblCliente).Include(t => t.TblEstatu);
            return View(tblproyectos.ToList());
        }

        // GET: /Proyectos/Details/5
        public ActionResult Details(int? id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProyecto tblproyecto = db.TblProyectos.Find(id);
            if (tblproyecto == null)
            {
                return HttpNotFound();
            }
            return View(tblproyecto);
        }

        // GET: /Proyectos/Create
        public ActionResult Create()
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            ViewBag.IDCliente = new SelectList(db.TblClientes, "IDCliente", "NombreComercial");
            ViewBag.IDEstatus = new SelectList(db.TblEstatus, "IDEstatus", "Descripcion");
            return View();
        }

        // POST: /Proyectos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProyecto,IDCliente,Nombre,Decripcion,FechaInicio,FechaFin,Activo,IDEstatus,Cobrado")] TblProyecto tblproyecto)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (ModelState.IsValid)
            {
                db.TblProyectos.Add(tblproyecto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCliente = new SelectList(db.TblClientes, "IDCliente", "NombreComercial", tblproyecto.IDCliente);
            ViewBag.IDEstatus = new SelectList(db.TblEstatus, "IDEstatus", "Descripcion", tblproyecto.IDEstatus);
            return View(tblproyecto);
        }

        // GET: /Proyectos/Edit/5
        public ActionResult Edit(int? id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TblProyecto tblproyecto = db.TblProyectos.Find(id);
            if (tblproyecto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCliente = new SelectList(db.TblClientes, "IDCliente", "NombreComercial", tblproyecto.IDCliente);
            ViewBag.IDEstatus = new SelectList(db.TblEstatus, "IDEstatus", "Descripcion", tblproyecto.IDEstatus);
            return View(tblproyecto);
        }

        // POST: /Proyectos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDProyecto,IDCliente,Nombre,Decripcion,FechaInicio,FechaFin,Activo,IDEstatus,Cobrado")] TblProyecto tblproyecto)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (ModelState.IsValid)
            {
                db.Entry(tblproyecto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCliente = new SelectList(db.TblClientes, "IDCliente", "NombreComercial", tblproyecto.IDCliente);
            ViewBag.IDEstatus = new SelectList(db.TblEstatus, "IDEstatus", "Descripcion", tblproyecto.IDEstatus);
            return View(tblproyecto);
        }

        // GET: /Proyectos/Delete/5
        public ActionResult Delete(int? id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblProyecto tblproyecto = db.TblProyectos.Find(id);
            if (tblproyecto == null)
            {
                return HttpNotFound();
            }
            return View(tblproyecto);
        }

        // POST: /Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

            TblProyecto tblproyecto = db.TblProyectos.Find(id);
            db.TblProyectos.Remove(tblproyecto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ActualizaDetalleProyecto(int id) 
        {
            var user = Session["User"] as mUsuario;

            if (user == null)
                return Redirect("~/Default");

            if (user.Tipo.Equals(2))
                return Redirect("~/Presentacion/FrmHomeEmpleados.aspx"); 

             dbPresupuestosEntities db = new dbPresupuestosEntities();

             if (id == null)
                 return HttpNotFound();

             db.spCrearDetallePeriodo(id);

             return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
