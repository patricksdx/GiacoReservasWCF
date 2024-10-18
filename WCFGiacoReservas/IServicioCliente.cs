using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFGiacoReservas
{
    [ServiceContract]
    public interface IServicioCliente
    {
        [OperationContract]
        ClienteDC ConsultarCliente(Int16 id);

        [OperationContract]
        List<ClienteDC> ListarClientes();

        [OperationContract]
        Boolean InsertarCliente(ClienteDC objclienteDC);

        [OperationContract]
        Boolean ActualizarCliente(ClienteDC objclienteDC);

        [OperationContract]
        Boolean EliminarCliente(Int16 id);

        [OperationContract]
        List<ClienteDC> ListarClienteEmpresas();
    }

    [DataContract]
    [Serializable]
    public class ClienteDC
    {
        [DataMember]
        public Int16? cliente_id { get; set; }
        [DataMember]
        public string Id_Ubigeo { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string apellido { get; set; }
        [DataMember]
        public string correo_electronico { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public string RUC { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember]
        public string creadoPor { get; set; }
        [DataMember]
        public string telefono { get; set; }
        [DataMember]
        public Int32? estado { get; set; }
        [DataMember]
        public String Estado { get; set; }
        [DataMember]
        public Int16 esEmpresa { get; set; }
    }
}
