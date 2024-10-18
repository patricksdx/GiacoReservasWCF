using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFGiacoReservas
{
    [ServiceContract]
    public interface IServicioPersonal
    {
        [OperationContract]
        PersonalDC ConsultarPersonal(Int16 id);
        
        [OperationContract]
        List<PersonalDC> listarPersonal();

        [OperationContract]
        Boolean InsertarPersonal(PersonalDC objPersonalDC);

        [OperationContract]
        Boolean ActualizarPersonal(PersonalDC objPersonalDC);
        [OperationContract]
        Boolean EliminarPersonal(Int16 id);
        [OperationContract]
        PersonalDC ConsultarPersonalPorDni(string dni);
    }

    [DataContract]
    [Serializable]
    public class PersonalDC
    {
        [DataMember]
        public Int16? personal_id { get; set; }
        [DataMember]
        public String nombre { get; set; }
        [DataMember]
        public String apellido { get; set; }
        [DataMember]
        public Decimal costo_hora { get; set; }
        [DataMember]
        public byte[] Foto { get; set; }
        [DataMember]
        public String dni { get; set; }
        [DataMember]
        public String Telefono { get; set; }
        [DataMember]
        public String Correo { get; set; }
        [DataMember]
        public DateTime? FechaCreacion { get; set; }
        [DataMember]
        public String CreadoPor { get; set; }
        [DataMember]
        public DateTime? FechaActualizacion { get; set; }
        [DataMember]
        public String ActualizadoPor { get; set; }
        [DataMember]
        public Int16 Tipo { get; set; }
        [DataMember]
        public Int16 estado { get; set; }
    }
}