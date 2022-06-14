using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace meta.DTO
{
    public class CaminhaoEditDTO
    {
        public long Id { get; set; }
        [RegularExpressionList("FH|FM", ErrorMessage = "Modelo não aceito.")]
        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
    }

    //Validate string array with regular expression
    public class RegularExpressionListAttribute : RegularExpressionAttribute
    {
        public RegularExpressionListAttribute(string pattern)
            : base(pattern) { }

        public override bool IsValid(object value)
        {
            if (!Regex.IsMatch(value as string, Pattern))
                return false;

            return true;
        }
    }
}
