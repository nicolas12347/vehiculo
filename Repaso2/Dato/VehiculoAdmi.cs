using Repaso2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repaso2.Dato
{
    public class VehiculoAdmi
    {
        /// <summary>
        /// Consulta de los vehiculos
        /// </summary>
        /// <returns>datos de los vehiculos</returns>
        public IEnumerable<Vehiculo> Consultar() {
            using (Repaso2Entities contexto = new Repaso2Entities())
                return contexto.Vehiculo.AsNoTracking().ToList(); 
        }

        /// <summary>
        /// Guarda un vehiculo en la base de datos
        /// </summary>
        /// <param name="modelo"></param>
        public void Guardar(Vehiculo modelo)
        {
            using (Repaso2Entities contexto = new Repaso2Entities())
            {
                contexto.Vehiculo.Add(modelo);
                contexto.SaveChanges();
            }
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Vehiculo consultar (int id) {
            using(Repaso2Entities contexto = new Repaso2Entities()) {
                return contexto.Vehiculo.FirstOrDefault(v => v.Id == id);
            }
        }
        /// <summary>
        /// Modifica los datos del vehiculo
        /// </summary>
        /// <param name="modelo">datos del vehiculo</param>
        public void Modificar(Vehiculo modelo) {
            using(Repaso2Entities contexto = new Repaso2Entities()) {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();


            }
        }
        /// <summary>
        /// Eliminar un vehiculo
        /// </summary>
        /// <param name="modelo">vehiculo a eliminar</param>
        public void Eliminar(Vehiculo modelo) {
            using(Repaso2Entities contexto = new Repaso2Entities()) {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}