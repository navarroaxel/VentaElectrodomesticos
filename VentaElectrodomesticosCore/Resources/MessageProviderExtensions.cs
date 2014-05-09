using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentaElectrodomesticos.Core.Resources
{
    /// <summary>
    /// Extensiones al archivo de recursos de la aplicacion.
    /// </summary>
    public static class MessageProviderExtensions
    {
        public static string RequiredField(string field)
        {
            return String.Format("El campo {0} no puede estar vacio", field);
        }

        public static string RequiredFields(string fields)
        {
            return String.Format("Los siguientes campos son obligatorios:\n{0}", fields);
        }

        public static string InvalidValue(string field)
        {
            return String.Format("El valor del campo {0} es incorrecto", field);
        }

        public static string EntityRequired(string entity)
        {
            return String.Format("Debe seleccionar un {0}", entity);
        }

        public static string DisableEmpleado(string nombre, string apellido, int dni)
        {
            return String.Format("¿Desea inhabilitar al empleado '{0} {1}' con DNI {2}?", nombre, apellido, dni);
        }

        public static string EnableEmpleado(string nombre, string apellido, int dni)
        {
            return String.Format("¿Desea volver a habilitar al empleado '{0} {1}' con DNI {2}?", nombre, apellido, dni);
        }

        public static string CannotModifyEmpleado(string nombre, string apellido, int dni)
        {
            return String.Format("No se puede modificar al empleado '{0} {1}' con DNI {2} porque esta inhabilitado.", nombre, apellido, dni);
        }

        public static string ConfirmDisableEntity(string entity)
        {
            return String.Format("¿Desea inhabilitar al {0} seleccionado?", entity);
        }

        public static string ConfirmEnableEntity(string entity)
        {
            return String.Format("¿Desea volver a habilitar al {0} seleccionado?", entity);
        }

        public static string CrudEntity(string entity)
        {
            return String.Format("ABM de {0}", entity);
        }

        public static string CreateEntity(string entity)
        {
            return String.Format("Alta de {0}", entity);
        }

        public static string UpdateEntity(string entity)
        {
            return String.Format("Modificación de {0}", entity);
        }

        public static string RegisteredFacturaNumber(int nro)
        {
            return String.Format("Factura registrada con el número {0}", nro);
        }

        public static string DisableExitoso(string entity)
        {
            return String.Format("Se realizó la baja lógica del {0} de manera exitosa.",entity);
        }

        public static string EnableExitoso(string entity)
        {
            return String.Format("Se realizó la rehabilitación del {0} de manera exitosa.", entity);
        } 
    }
}
