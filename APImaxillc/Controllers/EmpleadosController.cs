//using APImaxillc.Data;
//using APImaxillc.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace APImaxillc.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class EmpleadosController : ControllerBase
//    {
//        private readonly ILogger<EmpleadosController> _logger;

//        public EmpleadosController(ILogger<EmpleadosController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet(Name = "GetEmpleados")]
//        public IEnumerable<Empleado> Get()
//        {
//            using (var context = new APIcontext())
//            {
//                var result = context.Empleado.Include("Persona").ToList();
//                //work with context here

//                // IList<Empleado> empl = context.Empleado.ToList();
//                IEnumerable<Empleado> empleado = context.Empleado.Select(x => x);
//                return empleado.ToArray();
//            }
//        }

//        [HttpPost(Name = "PostEmpleado")]
//        public int Post(string nombre, string apellidos, DateTime fechaNacimiento, string curp, string ssn, string telefono, string nacionalidad, string numeroEmpleado)
//        {
//            using (var context = new APIcontext())
//            {
//                return context.Database.ExecuteSqlRaw(
//                    "EXEC InsertEmpleado @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7", 
//                    parameters: new[] { nombre, apellidos, fechaNacimiento.ToShortDateString(), curp, ssn, telefono, nacionalidad, numeroEmpleado });
//            }
//        }

//        [HttpDelete(Name = "DeleteEmpleado")]
//        public int Delete(int empleadoId)
//        {
//            using (var context = new APIcontext())
//            {
//                return context.Database.ExecuteSqlRaw("EXEC DeleteEmpleado @p0", parameters: empleadoId);
//            }
//        }
//    }
//}