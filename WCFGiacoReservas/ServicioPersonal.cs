using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.ServiceModel;

namespace WCFGiacoReservas
{
    public class ServicioPersonal : IServicioPersonal
    {
        public PersonalDC ConsultarPersonal(Int16 id)
        {
            try
            {
                GiacoReservaEntities MisReservas = new GiacoReservaEntities();
                PersonalDC personalDc = new PersonalDC();

                var consulta = MisReservas.Usp_ConsultarDatosPersonal(id);

                foreach (var resultado in consulta)
                {
                    personalDc.personal_id = Convert.ToInt16(resultado.personal_id);
                    personalDc.nombre = resultado.nombre;
                    personalDc.apellido = resultado.apellido;
                    personalDc.dni = resultado.dni;
                    personalDc.Correo = resultado.Correo;
                    personalDc.Telefono = resultado.Telefono;
                    personalDc.estado = Convert.ToInt16(resultado.estado);
                    personalDc.FechaCreacion = resultado.FechaCreacion;
                    personalDc.CreadoPor = resultado.CreadoPor;
                    personalDc.FechaActualizacion = resultado.FechaActualizacion;
                    personalDc.ActualizadoPor = resultado.ActualizadoPor;
                    personalDc.Tipo = Convert.ToInt16(resultado.Tipo);
                }
                return personalDc;
            }
            catch (EntityException ex)
            {
                throw new EntityException("Error en la capa de datos: " + ex.Message, ex);
            }
        }
        public List<PersonalDC> listarPersonal()
        {
            try
            {
                GiacoReservaEntities MisReservas = new GiacoReservaEntities();

                List<PersonalDC> objLista = new List<PersonalDC>();

                var consulta = (from misPersonal in MisReservas.Tb_Personal
                                orderby misPersonal.nombre
                                select misPersonal).ToList();

                foreach (var resultado in consulta)
                {
                    PersonalDC objPersonalDC = new PersonalDC();

                    objPersonalDC.personal_id = Convert.ToInt16(resultado.personal_id);
                    objPersonalDC.nombre = resultado.nombre;
                    objPersonalDC.apellido = resultado.apellido;
                    objPersonalDC.costo_hora = resultado.costo_hora;
                    objPersonalDC.dni = resultado.dni;
                    objPersonalDC.Telefono = resultado.Telefono;
                    objPersonalDC.Correo = resultado.Correo;
                    objPersonalDC.FechaCreacion = resultado.FechaCreacion;
                    objPersonalDC.CreadoPor = resultado.CreadoPor;
                    objPersonalDC.FechaActualizacion = resultado.FechaActualizacion;
                    objPersonalDC.ActualizadoPor = resultado.ActualizadoPor;
                    objPersonalDC.estado = Convert.ToInt16(resultado.estado);
                    objPersonalDC.Tipo = Convert.ToInt16(resultado.Tipo);

                    objLista.Add(objPersonalDC);
                }
                return objLista;
            }
            catch (EntityException ex)
            {
                throw new FaultException($"Error al listar el personal: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new FaultException($"Error interno: {ex.Message}");
            }
        }
        public PersonalDC ConsultarPersonalPorDni(string dni)
        {
            try
            {
                using (GiacoReservaEntities MisReservas = new GiacoReservaEntities())
                {
                    var consulta = MisReservas.usp_ConsultarPersonalDni(dni).ToList();

                    PersonalDC personalDc = new PersonalDC();

                    var resultado = consulta.FirstOrDefault();
                    if (resultado != null)
                    {
                        personalDc.personal_id = Convert.ToInt16(resultado.personal_id);
                        personalDc.nombre = resultado.nombre;
                        personalDc.apellido = resultado.apellido;
                        personalDc.dni = resultado.dni;
                        personalDc.Correo = resultado.Correo;
                        personalDc.Telefono = resultado.Telefono;
                        personalDc.estado = Convert.ToInt16(resultado.estado);
                        personalDc.FechaCreacion = resultado.FechaCreacion;
                        personalDc.CreadoPor = resultado.CreadoPor;
                        personalDc.FechaActualizacion = resultado.FechaActualizacion;
                        personalDc.ActualizadoPor = resultado.ActualizadoPor;
                        personalDc.Tipo = Convert.ToInt16(resultado.Tipo);

                    }
                    else
                    {
                        return null;
                    }
                    return personalDc;
                }
            }
            catch (EntityException ex)
            {
                throw new EntityException("Error en la capa de datos: " + ex.Message, ex);
            }
        }
        public bool InsertarPersonal(PersonalDC objPersonalDC)
        {
            try
            {
                GiacoReservaEntities MisReservas = new GiacoReservaEntities();

                MisReservas.usp_InsertarPersonal(
                 objPersonalDC.nombre, objPersonalDC.apellido, objPersonalDC.dni, objPersonalDC.costo_hora,
                 objPersonalDC.Foto, objPersonalDC.Telefono, objPersonalDC.Correo, objPersonalDC.Tipo,objPersonalDC.ActualizadoPor, objPersonalDC.CreadoPor, objPersonalDC.estado);

                MisReservas.SaveChanges();

                return true;
            }
            catch (EntityException ex)
            {
                throw new EntityException("Error en la capa de datos: " + ex.Message, ex);
            }
        }
        public bool ActualizarPersonal(PersonalDC objPersonalDC)
        {
            try
            {
                GiacoReservaEntities MisReservas = new GiacoReservaEntities();

                MisReservas.usp_ActualizarPersonal(objPersonalDC.personal_id,
                 objPersonalDC.nombre, objPersonalDC.apellido, objPersonalDC.dni, objPersonalDC.costo_hora,
                 objPersonalDC.Foto, objPersonalDC.Telefono, objPersonalDC.Correo, objPersonalDC.Tipo, objPersonalDC.CreadoPor, objPersonalDC.estado);

                MisReservas.SaveChanges();

                return true;
            }
            catch (EntityException ex)
            {
                throw new EntityException("Error en la capa de datos: " + ex.Message, ex);
            }
        }
        public bool EliminarPersonal(Int16 id)
        {
            try
            {
                GiacoReservaEntities MisVentas = new GiacoReservaEntities();
                MisVentas.usp_EliminarPersonal( id );
                MisVentas.SaveChanges();

                return true;
            }
            catch (EntityException ex)
            {
                throw new EntityException("Error en la capa de datos: " + ex.Message, ex);
            }
        }
    }
}
