using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace WSAutoParabrisasNic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceAutoParabrisasNic" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceAutoParabrisasNic.svc or ServiceAutoParabrisasNic.svc.cs at the Solution Explorer and start debugging.
    public class ServiceAutoParabrisasNic : IServiceAutoParabrisasNic
    {
        public string AgregarProducto(ProductoContract producto)
        {
            try
            {
                AutoParabrisasNicDB db = new AutoParabrisasNicDB();
                    db.Productos.Add(new Producto()
                    {
                        idMarca = producto.idMarca,
                        idPrecio = producto.idPrecio,
                        descripcion = producto.descripcion,
                        codigoBarra = producto.codigoBarra,
                        numeroLote = producto.numeroLote,
                        estado = true,
                        fechaRegistro = DateTime.Now
                    });
                    db.SaveChanges();
                    return "Ok";
            }
            catch (DbEntityValidationException e )
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return e.Message ;
            }
           
            
            //throw new NotImplementedException();
        }

        public List<Producto> ObtenerListaProductos()
        {
            try
            {
                AutoParabrisasNicDB db = new AutoParabrisasNicDB();
                return db.Productos.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public Producto ObtenerProducto(int idProducto)
        {
            AutoParabrisasNicDB db = new AutoParabrisasNicDB();
            return db.Productos.Find(idProducto);
        }
    }
}
