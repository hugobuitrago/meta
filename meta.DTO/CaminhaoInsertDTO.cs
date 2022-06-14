using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta.DTO
{
    public class CaminhaoInsertDTO
    {
        [RegularExpressionList("FH|FM", ErrorMessage = "Modelo não aceito.")]
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
    }    
}
