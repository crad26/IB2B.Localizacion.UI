using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.BE
{
    public class UsuarioBE : ComunBE
    {
        [StringLength(20, ErrorMessage = "El máximo de longitud es 20.", MinimumLength = 1)]
        [Required(ErrorMessage = "Debe ingresar su Id. Usuario.")]
        public String UsuarioId { get; set; }
        [StringLength(150, ErrorMessage = "El máximo de longitud es 150.", MinimumLength = 1)]
        [Required(ErrorMessage = "Debe ingresar su Usuario.")]
        public String Usuario_Usu { get; set; }
        [Required(ErrorMessage = "Debe ingresar su contraseña.")]
        [StringLength(200, ErrorMessage = "El máximo de longitud es 200.", MinimumLength = 1)]
        public String Contrasenia_Usu { get; set; }
        [Required(ErrorMessage = "Debe ingresar su contraseña.")]
        [StringLength(200, ErrorMessage = "El máximo de longitud es 200.", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [CompareAttribute("Contrasenia_Usu", ErrorMessage = "No coinciden la contraseña.")]
        public String RepetirContrasenia { get; set; }
        public Boolean Activo_Usu { get; set; }
        public String Url_Detalle { get; set; }
    }
}
