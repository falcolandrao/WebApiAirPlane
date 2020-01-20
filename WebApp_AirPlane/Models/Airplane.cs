using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApp_AirPlane.Controllers
{
    public class Airplane
    {
        [Key]
        public int IdAviao { get; set; }
        public string Modelo { get; set; }
        public int QtdTurbinas { get; set; }
        public int CapacPassageiros { get; set; }
        public double CapacCarga { get; set; }
    }
}
