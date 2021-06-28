using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_ZiekenhuisOpnames.Database;
using MVC_ZiekenhuisOpnames.Models;
using StoreAccountingApp.CustomMethods;

namespace MVC_ZiekenhuisOpnames.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment hostEnvironment;

        public PatientsController(ApplicationContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this.hostEnvironment = hostEnvironment;
        }
        [HttpGet("Patienten"), HttpGet("opnames"), HttpGet("")]
        // GET: Patients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(ObjMethods.CopyProperties<Patient, PatientViewModel>(patient));
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View(new PatientViewModel());
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Voornaam,Achternaam,Leeftijd,Straat,HuisNr,Bus,Postcode,Stad,Geslacht,pathImgIdCardVoorkant,pathImgIdCardAchterkant, ID_Voorkant, ID_Achterkant")] PatientViewModel patientVM)
        {
            if (ModelState.IsValid)
            {
                Patient patient = new Patient();
                ViewModelToPatient(patientVM, patient);
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientVM);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(PatientToViewModel(patient));
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Voornaam,Achternaam,Leeftijd,Straat,HuisNr,Bus,Postcode,Stad,Geslacht,pathImgIdCardVoorkant,pathImgIdCardAchterkant, ID_Voorkant, ID_Achterkant")] PatientViewModel patient)
        {
            if (id != patient.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var dbPatient = _context.Find<Patient>(id);
                    if (dbPatient != null)
                    {
                        ViewModelToPatient(patient,dbPatient);
                        if (patient.ID_Voorkant != null)
                        {
                            if (!String.IsNullOrEmpty(dbPatient.pathImgIdCardVoorkant))
                                DeleteFoto(dbPatient.pathImgIdCardVoorkant);
                            dbPatient.pathImgIdCardVoorkant = Path.Combine("/Fotos", UploadFoto(patient.ID_Voorkant));
                        }
                        if (patient.ID_Achterkant != null)
                        {
                            if (!String.IsNullOrEmpty(dbPatient.pathImgIdCardAchterkant))
                                DeleteFoto(dbPatient.pathImgIdCardAchterkant);
                            dbPatient.pathImgIdCardAchterkant = Path.Combine("/Fotos", UploadFoto(patient.ID_Achterkant));
                        }
                        _context.Update(dbPatient);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(patient.id))
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
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient.pathImgIdCardAchterkant != null)
                DeleteFoto(patient.pathImgIdCardAchterkant);
            if (patient.pathImgIdCardVoorkant != null)
                DeleteFoto(patient.pathImgIdCardVoorkant);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private PatientViewModel PatientToViewModel(Patient patient)
        {
            return ObjMethods.CopyProperties<Patient, PatientViewModel>(patient);
        }
        private void ViewModelToPatient(PatientViewModel patientVM, Patient patient)
        {
            ObjMethods.EditProperties(patientVM, patient);
            if (patientVM.ID_Achterkant != null)
                patient.pathImgIdCardAchterkant = "/" + Path.Combine("Fotos", UploadFoto(patientVM.ID_Achterkant));
            if (patientVM.ID_Voorkant != null)
                patient.pathImgIdCardVoorkant = "/" + Path.Combine("Fotos", UploadFoto(patientVM.ID_Voorkant));
        }
        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.id == id);
        }
        private string UploadFoto(IFormFile foto)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(foto.FileName);
            string pathName = Path.Combine(hostEnvironment.WebRootPath, "Fotos");
            string fileNameWithPath = Path.Combine(pathName, uniqueFileName);
            foto.CopyTo(new FileStream(fileNameWithPath, FileMode.Create));
            return uniqueFileName;
        }
        private void DeleteFoto(string filename)
        {
            string path = Path.Combine(hostEnvironment.WebRootPath, filename.Substring(1));
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }
    }
}
