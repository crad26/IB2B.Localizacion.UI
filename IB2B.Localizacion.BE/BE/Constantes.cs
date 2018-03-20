using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IB2B.Localizacion.BE.BE
{
    public class Constantes
    {
        public static class ResultadoSistema
        {
            public const String Ok = "Ok";
            public const String Error = "Error";
        }

        public static class FlagRegistro
        {
            public const Int32 Insertar = 0;
            public const Int32 Actualizar = 1;
        }

        public static class GrupoLocalizacion
        {
            public const String UsuarioSesionId = "UsuarioId";
            public const String UsuarioConectado = "UsuarioConectado";
            public const String LogoString = "LogoString";
            public const String Menu = "Menu";
        }

        public static class MensajeLocalizacion
        {
            public const String MensajeError = "Ocurrió un error inesperado, coordine con el área de sistemas.";
            public const String MensajeCorrectamente = "Se generó correctamente.";
            public const String UsuarioIncorrecto = "Usuario o Clave incorrecto.";
            public const String UsuarioDuplicado = "El Usuario ya se encuentra registrado.";
        }
    }
}

