using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcConcesionaria.Data;
using MvcConcesionaria.Models;

namespace MvcConcesionaria.Controllers
{
    public class VehiculosController : Controller
    {
        private readonly MvcConcesionariaContext _context;

        public VehiculosController(MvcConcesionariaContext context)
        {
            _context = context;
        }

        // GET: Vehiculos
        public async Task<IActionResult> Index(string marcaVehiculo, string searchString)
        {
            if (_context.Vehiculo == null)
            {
                return Problem("Entity set 'MvcConcesionaria.Vehiculo'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Vehiculo
                                            orderby m.Marca
                                            select m.Marca;
            var vehiculos = from m in _context.Vehiculo
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                vehiculos = vehiculos.Where(s => s.Modelo!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(marcaVehiculo))
            {
                vehiculos = vehiculos.Where(x => x.Marca == marcaVehiculo);
            }

            var marcaVehiculosVM = new MarcaVehiculosVM
            {
                Marcas = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Vehiculos = await vehiculos.ToListAsync()
            };

            return View(marcaVehiculosVM);
        }

        // GET: Vehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehiculo == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,Color,AnioFabricacion,Observaciones,CantPuertas,Precio,Reservado,Vendido")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehiculo == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,Color,AnioFabricacion,Observaciones,CantPuertas,Precio,Reservado,Vendido")] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehiculo == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehiculo == null)
            {
                return Problem("Entity set 'MvcConcesionariaContext.Vehiculo'  is null.");
            }
            var vehiculo = await _context.Vehiculo.FindAsync(id);
            if (vehiculo != null)
            {
                _context.Vehiculo.Remove(vehiculo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var vehiculo = await _context.Vehiculo.FindAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            vehiculo.Reservado = "Si";

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Entregar(int? id)
        {
            if (id == null || _context.Vehiculo == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculo.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        public async Task<IActionResult> Entregar(int id, [Bind("Id,Marca,Modelo,Color,AnioFabricacion,Observaciones,CantPuertas,Precio,Reservado,Vendido")] Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        private bool VehiculoExists(int id)
        {
          return (_context.Vehiculo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
