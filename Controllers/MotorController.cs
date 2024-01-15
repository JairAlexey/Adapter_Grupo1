using FactoryMethod_Grupo1.Data;
using FactoryMethod_Grupo1.FactoryMethod;
using FactoryMethod_Grupo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace FactoryMethod_Grupo1.Controllers
{
    public class MotorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MotorController(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult Index()
        {
            var motores = _context.Motores.ToList();
            return View(motores);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string tipoMotor, string especificaciones)
        {
            // Crear un nuevo objeto Motor
            var motor = new Motor
            {
                Tipo = tipoMotor,
                Especificaciones = especificaciones
            };


            _context.Motores.Add(motor);
            _context.SaveChanges();

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}