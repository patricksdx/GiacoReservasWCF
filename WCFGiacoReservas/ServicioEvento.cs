using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;

// PATRICK Y GIACOMO
namespace WCFGiacoReservas
{
    public class ServicioEvento : IServicioEvento
    {
        public EventoDC ConsultarEvento(Int16 id)
        {
            try
            {
                using (GiacoReservaEntities MisReservas = new GiacoReservaEntities())
                {
                    EventoDC objEventoDC = new EventoDC();

                    var consulta = MisReservas.usp_ConsultarEvento(id).ToList(); // Llama al USP

                    foreach (var resultado in consulta)
                    {
                        objEventoDC.evento_id = Convert.ToInt16(resultado.evento_id);
                        objEventoDC.nombre_evento = resultado.nombre_evento;
                        objEventoDC.sala_id = (short)resultado.sala_id;
                        objEventoDC.tipo_id = (short)resultado.tipo_id;
                        objEventoDC.fecha_evento = resultado.fecha_evento;
                        objEventoDC.hora_inicio = resultado.hora_inicio;
                        objEventoDC.hora_finalizacion = resultado.hora_finalizacion;
                        objEventoDC.estado = (short)resultado.estado;
                        objEventoDC.FechaCreacion = resultado.FechaCreacion;
                        objEventoDC.CreadoPor = resultado.CreadoPor;
                        objEventoDC.FechaActualizacion = resultado.FechaActualizacion;
                        objEventoDC.ActualizadoPor = resultado.ActualizadoPor;
                        objEventoDC.fecha_eliminacion = resultado.fecha_eliminacion;
                    }
                    return objEventoDC;
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<EventoDC> ListarEvento()
        {
            try
            {
                using (GiacoReservaEntities MisReservas = new GiacoReservaEntities())
                {
                    var consulta = MisReservas.usp_ListarEvento().ToList();
                    List<EventoDC> objLista = new List<EventoDC>();

                    foreach (var resultado in consulta)
                    {
                        EventoDC objEventoDC = new EventoDC
                        {
                            evento_id = Convert.ToInt16(resultado.evento_id),
                            nombre_evento = resultado.nombre_evento,
                            fecha_evento = resultado.fecha_evento,
                            hora_inicio = resultado.hora_inicio,
                            hora_finalizacion = resultado.hora_finalizacion,
                            sala_id = Convert.ToInt16(resultado.sala_id),
                            cliente_id = Convert.ToInt16(resultado.cliente_id),
                            tipo_id = Convert.ToInt16(resultado.tipo_id),
                            CreadoPor = resultado.CreadoPor,
                            ActualizadoPor = resultado.ActualizadoPor,
                            FechaCreacion = resultado.FechaCreacion,
                            FechaActualizacion = resultado.FechaActualizacion,
                        };

                        objLista.Add(objEventoDC);
                    }

                    return objLista;
                }
            }
            catch (EntityException ex)
            {
                throw new Exception("Error al listar eventos: " + ex.Message);
            }
        }
        public List<EventoDC> ConsultarEventoEntreFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (GiacoReservaEntities MisReservas = new GiacoReservaEntities())
                {
                    // Ejecutamos el store procedure directamente
                    var consulta = MisReservas.usp_ConsultarEventoEntreFechas(fechaInicio, fechaFin).ToList();

                    List<EventoDC> objLista = new List<EventoDC>();

                    foreach (var resultado in consulta)
                    {
                        EventoDC objEventoDC = new EventoDC
                        {
                            evento_id = Convert.ToInt16(resultado.evento_id),
                            nombre_evento = resultado.nombre_evento,
                            fecha_evento = resultado.fecha_evento,
                            hora_inicio = resultado.hora_inicio,
                            hora_finalizacion = resultado.hora_finalizacion,
                            sala_id = Convert.ToInt16(resultado.sala_id),
                            cliente_id = Convert.ToInt16(resultado.cliente_id),
                            tipo_id = Convert.ToInt16(resultado.tipo_id),
                            CreadoPor = resultado.CreadoPor,
                            ActualizadoPor = resultado.ActualizadoPor,
                            FechaCreacion = resultado.FechaCreacion,
                            FechaActualizacion = resultado.FechaActualizacion,
                        };

                        objLista.Add(objEventoDC);
                    }

                    return objLista;
                }
            }
            catch (EntityException ex)
            {
                throw new Exception("Error al consultar eventos entre fechas: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado: {ex.Message}");
            }
        }
        public bool ActualizarEvento(EventoDC objeventoDC)
        {
            try
            {
                using (GiacoReservaEntities MisReservas = new GiacoReservaEntities())
                {
                    MisReservas.usp_ActualizarEvento(
                        objeventoDC.evento_id,
                        objeventoDC.nombre_evento,
                        objeventoDC.sala_id,
                        objeventoDC.tipo_id,
                        objeventoDC.fecha_evento,
                        objeventoDC.hora_inicio,
                        objeventoDC.hora_finalizacion,
                        objeventoDC.estado,
                        objeventoDC.ActualizadoPor
                        );

                    MisReservas.SaveChanges();
                    return true;
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool EliminarEvento(Int16 id)
        {
            try
            {
                using (GiacoReservaEntities MisReservas = new GiacoReservaEntities())
                {
                    // Aquí se debe llamar al procedimiento para eliminar el evento
                    MisReservas.usp_EliminarEvento(id);
                    MisReservas.SaveChanges();
                    return true;
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool InsertarEvento(EventoDC objeventoDC)
        {
            try
            {
                using (GiacoReservaEntities MisReservas = new GiacoReservaEntities())
                {
                    var mensaje = MisReservas.usp_InsertarEvento(
                        objeventoDC.nombre_evento,
                        objeventoDC.fecha_evento,
                        objeventoDC.hora_inicio,
                        objeventoDC.hora_finalizacion,
                        objeventoDC.sala_id,
                        objeventoDC.tipo_id,
                        objeventoDC.estado,
                        objeventoDC.CreadoPor
                        );
                    MisReservas.SaveChanges();
                    return true;
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}






