using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFGiacoReservas
{
    [ServiceContract]
    public interface IServicioEvento
    {
        [OperationContract]
        EventoDC ConsultarEvento(Int16 id);

        [OperationContract]
        List<EventoDC> ListarEvento();

        [OperationContract]
        Boolean InsertarEvento(EventoDC objeventoDC);

        [OperationContract]
        Boolean ActualizarEvento(EventoDC objeventoDC);

        [OperationContract]
        Boolean EliminarEvento(Int16 id);
        [OperationContract]
        List<EventoDC> ConsultarEventoEntreFechas(DateTime fechaInicio, DateTime fechaFin);
    }

    [DataContract]
    [Serializable]
    public class EventoDC
    {
        [DataMember]
        public Int16? evento_id { get; set; }

        [DataMember]
        public DateTime fecha_evento { get; set; }

        [DataMember]
        public TimeSpan hora_inicio { get; set; }

        [DataMember]
        public TimeSpan hora_finalizacion { get; set; }

        [DataMember]
        public Int16 sala_id { get; set; }

        [DataMember]
        public Int16 cliente_id { get; set; }

        [DataMember]
        public Int16 tipo_id { get; set; }

        [DataMember]
        public DateTime? fecha_eliminacion { get; set; }

        [DataMember]
        public DateTime? FechaCreacion { get; set; }

        [DataMember]
        public string CreadoPor { get; set; }

        [DataMember]
        public DateTime? FechaActualizacion { get; set; }

        [DataMember]
        public string ActualizadoPor { get; set; }

        [DataMember]
        public Int16 estado { get; set; }

        [DataMember]
        public string nombre_evento { get; set; }
    }
}