using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WSAutoParabrisasNic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceAutoParabrisasNic" in both code and config file together.
    [ServiceContract]
    public interface IServiceAutoParabrisasNic
    {
        [OperationContract]
        string AgregarProducto(ProductoContract producto);
        [OperationContract]
        List<Producto> ObtenerListaProductos();

        [OperationContract]
        Producto ObtenerProducto(int idProducto);
    }

    [DataContract]
    public class ProductoContract
    {
        [DataMember]
        public int idMarca { get; set; }
        [DataMember]
        public int idPrecio { get; set; }
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public string codigoBarra { get; set; }

        [DataMember]
        public string numeroLote { get; set; }
    }

   
}
