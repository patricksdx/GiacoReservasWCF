using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;

namespace WCFGiacoReservas
{
    public class ServicioCliente : IServicioCliente
    {
        public ClienteDC ConsultarCliente(Int16 id)
        {
            try
            {
                GiacoReservaEntities MisReservas = new GiacoReservaEntities();

                ClienteDC objClienteDC = new ClienteDC();

                var consulta = MisReservas.usp_ConsultarCliente(id);

                foreach (var resultado in consulta)
                {

                    objClienteDC.cliente_id = Convert.ToInt16(resultado.cliente_id);
                    objClienteDC.nombre = resultado.nombre;
                    objClienteDC.apellido = resultado.apellido;
                    objClienteDC.Dni = resultado.Dni;
                    objClienteDC.RUC = resultado.RUC;
                    objClienteDC.RazonSocial = resultado.RazonSocial;
                    objClienteDC.correo_electronico = resultado.correo_electronico;
                    objClienteDC.estado = resultado.estado;
                    objClienteDC.telefono = resultado.telefono;
                    objClienteDC.direccion = resultado.direccion;

                    if (objClienteDC.RUC == null)
                    {
                        objClienteDC.RUC = "Sin RUC";
                        objClienteDC.RazonSocial = "Sin Razon Social";
                    }

                    if (objClienteDC.estado == 1)
                    {
                        objClienteDC.Estado = "Activo";
                    }
                    else
                    {
                        objClienteDC.Estado = "Inactivo";

                    }

                }
                return objClienteDC;
            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<ClienteDC> ListarClientes()
        {
            try
            {
                GiacoReservaEntities MisReservas = new GiacoReservaEntities();

                List<ClienteDC> objLista = new List<ClienteDC>();

                var consulta = (from misClientes in MisReservas.Tb_Cliente
                                orderby misClientes.nombre
                                select misClientes).ToList();

                foreach (var resultado in consulta)
                {
                    ClienteDC objclienteDC = new ClienteDC();
                    objclienteDC.cliente_id = Convert.ToInt16(resultado.cliente_id);
                    objclienteDC.nombre = resultado.nombre;
                    objclienteDC.apellido = resultado.apellido;
                    objclienteDC.Dni = resultado.Dni;
                    objclienteDC.RUC = resultado.RUC;
                    objclienteDC.RazonSocial = resultado.RazonSocial;
                    objclienteDC.correo_electronico = resultado.correo_electronico;
                    objclienteDC.estado = resultado.estado;
                    objclienteDC.telefono = resultado.telefono;
                    objclienteDC.direccion = resultado.direccion;

                    if (objclienteDC.RUC == null)
                    {
                        objclienteDC.RUC = "Sin RUC";
                        objclienteDC.RazonSocial = "Sin Razon Social";
                    }

                    if (objclienteDC.estado == 1)
                    {
                        objclienteDC.Estado = "Activo";
                    }
                    else
                    {
                        objclienteDC.Estado = "Inactivo";
                    }
                    objLista.Add(objclienteDC);

                }
                return objLista;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ClienteDC> ListarClienteEmpresas()
        {
            try
            {
                GiacoReservaEntities MisReservas = new GiacoReservaEntities();

                List<ClienteDC> objLista = new List<ClienteDC>();

                // Ejecutamos el procedimiento almacenado para obtener clientes que son empresas
                var consulta = MisReservas.usp_ConsultarClienteEmpresa().ToList();

                foreach (var resultado in consulta)
                {
                    ClienteDC objclienteDC = new ClienteDC();
                    objclienteDC.cliente_id = Convert.ToInt16(resultado.cliente_id);
                    objclienteDC.nombre = resultado.nombre;
                    objclienteDC.apellido = resultado.apellido;
                    objclienteDC.Dni = resultado.Dni;
                    objclienteDC.RUC = resultado.RUC;
                    objclienteDC.RazonSocial = resultado.RazonSocial;
                    objclienteDC.correo_electronico = resultado.correo_electronico;
                    objclienteDC.telefono = resultado.telefono;
                    objclienteDC.direccion = resultado.direccion;
                    objclienteDC.Id_Ubigeo = resultado.Id_Ubigeo;
                    objclienteDC.creadoPor = resultado.CreadoPor;
                    objclienteDC.estado = resultado.estado; // Mapeamos la columna 'estado'

                    // Si el RUC o la RazonSocial son nulos, asignamos valores por defecto
                    if (string.IsNullOrEmpty(objclienteDC.RUC))
                    {
                        objclienteDC.RUC = "Sin RUC";
                        objclienteDC.RazonSocial = "Sin Razon Social";
                    }

                    // Asignamos el valor de 'Estado' dependiendo del valor de 'estado'
                    if (objclienteDC.estado == 1)
                    {
                        objclienteDC.Estado = "Activo";
                    }
                    else
                    {
                        objclienteDC.Estado = "Inactivo";
                    }

                    // Añadimos el objeto a la lista
                    objLista.Add(objclienteDC);
                }

                return objLista;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool ActualizarCliente(ClienteDC objclienteDC)
        {
            try
            {
                GiacoReservaEntities MisReservas = new GiacoReservaEntities();

                MisReservas.usp_ActualizarCliente(objclienteDC.cliente_id, objclienteDC.nombre, objclienteDC.apellido,
                    objclienteDC.correo_electronico, objclienteDC.direccion, objclienteDC.Dni,
                    objclienteDC.telefono, objclienteDC.esEmpresa, objclienteDC.RazonSocial, objclienteDC.RUC,
                     objclienteDC.estado, objclienteDC.Id_Ubigeo);

                MisReservas.SaveChanges();

                return true;
            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public bool EliminarCliente(Int16 id)
        {
            try
            {
                GiacoReservaEntities MisVentas = new GiacoReservaEntities();

                MisVentas.usp_EliminarCliente(id);
                MisVentas.SaveChanges();

                return true;
            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public bool InsertarCliente(ClienteDC objclienteDC)
        {
            try
            {
                GiacoReservaEntities MisReservas = new GiacoReservaEntities();

                MisReservas.usp_InsertarCliente(objclienteDC.nombre, objclienteDC.apellido,
                    objclienteDC.correo_electronico, objclienteDC.direccion, objclienteDC.Dni,
                    objclienteDC.telefono, objclienteDC.creadoPor, objclienteDC.esEmpresa,
                    objclienteDC.RazonSocial, objclienteDC.RUC, objclienteDC.estado, objclienteDC.Id_Ubigeo);

                MisReservas.SaveChanges();

                return true;
            }
            catch (EntityException ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
