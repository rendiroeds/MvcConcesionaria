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
    
    public class ClientesController : Controller
    {
        AuxiliarVehiculos? aux = new AuxiliarVehiculos();

        private readonly MvcConcesionariaContext _context;

        public ClientesController(MvcConcesionariaContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index(string? nombre)
        {
            if (_context.Cliente == null)
            {
                return Problem("Entity set 'MvcConcesionaria.Vehiculo'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Cliente
                                            orderby m.Nombre
                                            select m.Nombre;
            var clientes = from m in _context.Cliente
                            select m;

            if (!string.IsNullOrEmpty(nombre))
            {
                clientes = clientes.Where(s => s.Nombre!.Contains(nombre));
            }


            var filtroClientes = new FiltroClientes
            {
                Todos = new SelectList(await genreQuery.Distinct().ToListAsync()),
                ListaClientes = await clientes.ToListAsync()
            };

            return View(filtroClientes);
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Dni,Email,Direccion,Telefono,Debe,IdVehiculoComprado")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        public IActionResult SeleccionCliente(int? id, decimal valorVehiculo)
        {
            ListaClientes("");
            return View();
        }

        public IActionResult Venta(int? idVehiculo)
        {
            
            return View();
        }

        //public async Task<IActionResult> Venta()
        //{
        //  return View();
        //}

        public IActionResult ListaClientes(string filtroNombre)
        {
            var clientes = _context.Cliente.ToList(); // Recuperar todos los clientes de la base de datos

            // Aplicar filtro por nombre si se ha especificado
            if (!string.IsNullOrEmpty(filtroNombre))
            {
                clientes = clientes.Where(c => c.Nombre!.Contains(filtroNombre)).ToList();
            }

            ViewBag.FiltroNombre = filtroNombre; // Pasar el valor del filtro a la vista

            return View(clientes); // Pasar los clientes a la vista como modelo de datos
        }


        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }


        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Dni,Email,Direccion,Telefono,Debe,Entrega,Deuda,IdVehiculoComprado")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cliente == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cliente == null)
            {
                return Problem("Entity set 'MvcConcesionariaContext.Cliente'  is null.");
            }
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return (_context.Cliente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
