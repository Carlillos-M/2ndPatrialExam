using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecondPartialExam.Entities;
using SecondPartialExam.Models;

namespace SecondPartialExam.Controllers
{
    public class JugueteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JugueteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult JugueteList()
        {
            List<JugueteModel> list = _context.Juguetes.Select(j => new JugueteModel()
            {
                Id = j.Id,
                Codigo = j.Codigo,
                Nombre = j.Nombre,
                Precio = j.Precio,
                Vigencia = DateTime.MinValue,
                Activo = j.Activo
            }).ToList();

            return View(list);
        }

        [HttpGet]
        public IActionResult JugueteAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult JugueteAdd(JugueteModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Juguete j = new Juguete();
            j.Id = model.Id;
            j.Codigo = model.Codigo;
            j.Nombre = model.Nombre;
            j.Precio = model.Precio;
            j.Vigencia = model.Vigencia;
            j.Activo = model.Activo;

            _context.Juguetes.Add(j);
            _context.SaveChanges();

            return RedirectToAction("JugueteList");
        }

        [HttpGet]
        public IActionResult JugueteEdit(Guid Id)
        {
            Juguete? juguete = this._context.Juguetes.FirstOrDefault(j => j.Id == Id);

            if (juguete == null)
            {
                return RedirectToAction("JugueteList");
            }

            JugueteModel model = new JugueteModel();
            model.Id = juguete.Id;
            model.Codigo = juguete.Codigo;
            model.Nombre = juguete.Nombre;
            model.Precio = juguete.Precio;
            model.Vigencia = DateTime.MinValue;
            model.Activo = juguete.Activo;

            return View(model);
        }

        [HttpPost]
        public IActionResult JugueteEdit(JugueteModel model)
        {
            Juguete? jugueteActualiza = this._context.Juguetes.FirstOrDefault(j => j.Id == model.Id);

            if (jugueteActualiza == null)
            {
                return RedirectToAction("JugueteList");
            }

            jugueteActualiza.Codigo = model.Codigo;
            jugueteActualiza.Nombre = model.Nombre;
            jugueteActualiza.Precio = model.Precio;
            jugueteActualiza.Vigencia = model.Vigencia;
            jugueteActualiza.Activo = model.Activo;

            _context.Juguetes.Update(jugueteActualiza);
            _context.SaveChanges();

            return RedirectToAction("JugueteList");
        }

        [HttpGet]
        public IActionResult JugueteDelete(Guid Id)
        {
            Juguete? jugueteBorrado = this._context.Juguetes.FirstOrDefault(j => j.Id == Id);

            if (jugueteBorrado == null)
            {
                return RedirectToAction("JugueteList");
            }

            JugueteModel model = new JugueteModel();
            model.Id = jugueteBorrado.Id;
            model.Codigo = jugueteBorrado.Codigo;
            model.Nombre = jugueteBorrado.Nombre;
            model.Precio = jugueteBorrado.Precio;
            model.Vigencia = DateTime.MinValue;
            model.Activo = jugueteBorrado.Activo;

            return View(model);
        }

        [HttpPost]
        public IActionResult JugueteDelete(JugueteModel model)
        {
            Juguete? jugueteBorrado = this._context.Juguetes.FirstOrDefault(j => j.Id == model.Id);

            if (jugueteBorrado == null)
            {
                return RedirectToAction("JugueteList");
            }

            _context.Juguetes.Remove(jugueteBorrado);
            _context.SaveChanges();

            return RedirectToAction("JugueteList");
        }
    }
}