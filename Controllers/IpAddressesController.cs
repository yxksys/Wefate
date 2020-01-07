using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wefate.Data;
using Wefate.Models;

namespace Wefate.Controllers
{
    public class IpAddressesController : Controller
    {
        private readonly WefateContext _context;

        public IpAddressesController(WefateContext context)
        {
            _context = context;
        }

        // GET: IpAddresses
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.IpAddresses.ToListAsync());
        //}
        public async Task<IActionResult> Index(string address,string ip)
        {
            var addresses = from m in _context.IpAddresses
                         select m;
            

            if (!String.IsNullOrEmpty(address))
            {
                addresses = addresses.Where(a => a.Address.Contains(address));
            }
            if (!String.IsNullOrEmpty(ip))
            {
                addresses = addresses.Where(i => i.Ip.Contains(ip));
            }

            return View(await addresses.ToListAsync());
        }


        // GET: IpAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ipAddress = await _context.IpAddresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ipAddress == null)
            {
                return NotFound();
            }

            return View(ipAddress);
        }

        // GET: IpAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IpAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,floor,Ip")] IpAddress ipAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ipAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ipAddress);
        }

        // GET: IpAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ipAddress = await _context.IpAddresses.FindAsync(id);
            if (ipAddress == null)
            {
                return NotFound();
            }
            return View(ipAddress);
        }

        // POST: IpAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,floor,Ip")] IpAddress ipAddress)
        {
            if (id != ipAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ipAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IpAddressExists(ipAddress.Id))
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
            return View(ipAddress);
        }

        // GET: IpAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ipAddress = await _context.IpAddresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ipAddress == null)
            {
                return NotFound();
            }

            return View(ipAddress);
        }

        // POST: IpAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ipAddress = await _context.IpAddresses.FindAsync(id);
            _context.IpAddresses.Remove(ipAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IpAddressExists(int id)
        {
            return _context.IpAddresses.Any(e => e.Id == id);
        }
    }
}
