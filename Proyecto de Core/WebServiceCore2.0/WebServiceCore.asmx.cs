using LibreriaClasesBD;
using LibreriaRequest_ResponseCaja;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServiceCore2._0._DSPrefinal_PlanBTableAdapters;
using static WebServiceCore2._0._DSPrefinal_PlanB;

namespace WebServiceCore2._0
{
    /// <summary>
    /// Summary description for WebServiceCore
    /// </summary>
    [WebService(Namespace = "http://softgames.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceCore : System.Web.Services.WebService
    {

        [WebMethod]
        public LoginClienteResponse VerificarLoginCliente(LoginClienteRequest request)
        {
            QueriesTableAdapter adapter = new QueriesTableAdapter();
            LoginClienteResponse respuesta;

            try
            {
                bool result = (bool)adapter.Comprar_Contraseñas_Clientes(request.email, request.hash_password);
                respuesta = new LoginClienteResponse() { estado = 1, resultado = result };

            }
            catch (Exception)
            {
                respuesta = new LoginClienteResponse() { estado = 0 };
            }
            return respuesta;
        }

        [WebMethod]
        public LoginEmpleadoResponse VerificarLoginEmpleado(LoginEmpleadoRequest request)
        {
            QueriesTableAdapter adapter = new QueriesTableAdapter();
            LoginEmpleadoResponse respuesta;
            try
            {
                bool result = (bool)adapter.Comprar_Contraseñas_Empleados(request.cedula, request.hash_password);
                respuesta = new LoginEmpleadoResponse() { estado = 1, resultado = result };

            }
            catch (Exception)
            {
                respuesta = new LoginEmpleadoResponse() { estado = 0 };
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarMetPago(Met_Pagos request)
        {
            Met_PagoTableAdapter met_pago = new Met_PagoTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                met_pago.Connection.Open();
                transaction = met_pago.Connection.BeginTransaction();
                met_pago.Transaction = transaction;
                met_pago.sp_Insert_Met_Pago(request.descripcion, request.activo);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ModificarMetPago(Met_Pagos request)
        {
            Met_PagoTableAdapter met_pago = new Met_PagoTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                met_pago.Connection.Open();
                transaction = met_pago.Connection.BeginTransaction();
                met_pago.Transaction = transaction;
                met_pago.sp_Update_Met_Pago(request.id_metpago, request.descripcion, request.activo);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerMetPagoResponses ObtenerMetPago(bool soloactivos)
        {
            Met_PagoTableAdapter adapter = new Met_PagoTableAdapter();
            ObtenerMetPagoResponses respuesta = new ObtenerMetPagoResponses();
            try
            {
                Met_PagoDataTable datos = adapter.sp_SelectAll_Met_Pago_Get(soloactivos);
                respuesta.metodos_pago = new List<LibreriaClasesBD.Met_Pagos>();
                //transaction.Commit();
                foreach (var metpag in datos)
                {
                    LibreriaClasesBD.Met_Pagos met = new LibreriaClasesBD.Met_Pagos
                    {
                        id_metpago = metpag.id_metpago,
                        descripcion = metpag.descripcion,
                        activo = metpag.activo
                    };
                    respuesta.metodos_pago.Add(met);
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {
                respuesta.estado = false;
                //  transaction.Rollback();
            }
            return respuesta;
        }

        public List<string> ObtenerFotosProductos(int id_producto)
        {
            Fotos_ProductosTableAdapter adapter = new Fotos_ProductosTableAdapter();
            List<string> respuesta = new List<string>();
            try
            {
                Fotos_ProductosDataTable datos = adapter.sp_Select_Fotos_Productos_ByProducto_Get(id_producto);
                //transaction.Commit();
                foreach (var foto in datos)
                {
                    respuesta.Add(foto.ruta_foto);
                }
            }
            catch (Exception)
            {

                //  transaction.Rollback();
            }
            return respuesta;
        }


        [WebMethod]
        public bool RegistrarEstado(Estados request)
        {
            EstadoTableAdapter estado = new EstadoTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                estado.Connection.Open();
                transaction = estado.Connection.BeginTransaction();
                estado.Transaction = transaction;
                estado.sp_Insert_Estado(request.descripcion, request.nombre_estado, request.activo,request.tipo_estado);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ModificarEstado(Estados request)
        {
            EstadoTableAdapter estado = new EstadoTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                estado.Connection.Open();
                transaction = estado.Connection.BeginTransaction();
                estado.Transaction = transaction;
                estado.sp_Update_Estado(request.id_estado, request.descripcion, request.activo, request.nombre_estado,request.tipo_estado);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerEstadosResponses ObtenerEstados(bool soloactivos)
        {
            EstadoTableAdapter adapter = new EstadoTableAdapter();
            ObtenerEstadosResponses respuesta = new ObtenerEstadosResponses();
            try
            {
                EstadoDataTable datos = adapter.sp_SelectAll_Estado_Get(soloactivos);
                respuesta.estados = new List<LibreriaClasesBD.Estados>();
                //transaction.Commit();
                foreach (var estado in datos)
                {
                    LibreriaClasesBD.Estados est = new LibreriaClasesBD.Estados
                    {
                        id_estado = estado.id_estado,
                        descripcion = estado.descripcion,
                        activo = estado.activo,
                        nombre_estado = estado.nombre_estado
                    };
                    respuesta.estados.Add(est);
                }
                respuesta.respuesta = true;
            }
            catch (Exception)
            {
                respuesta.respuesta = false;
                //  transaction.Rollback();
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerTipoEstadosResponses ObtenerTipoEstados(bool soloactivos)
        {
            Tipo_EstadoTableAdapter adapter = new Tipo_EstadoTableAdapter();
            ObtenerTipoEstadosResponses respuesta = new ObtenerTipoEstadosResponses();
            try
            {
                Tipo_EstadoDataTable datos = adapter.GetData();
                respuesta.tipo_Estados = new List<LibreriaClasesBD.Tipo_Estado>();
                //transaction.Commit();
                foreach (var tipoestado in datos)
                {
                    LibreriaClasesBD.Tipo_Estado est = new LibreriaClasesBD.Tipo_Estado
                    {
                        Id = tipoestado.id_tipo_estado,
                        descripcion = tipoestado.descripcion
                    };
                    respuesta.tipo_Estados.Add(est);
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {
                respuesta.estado = false;
                //  transaction.Rollback();
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarTipoCompra(Tipo_Compra request)
        {
            Tipo_CompraTableAdapter tipocompra = new Tipo_CompraTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                tipocompra.Connection.Open();
                transaction = tipocompra.Connection.BeginTransaction();
                tipocompra.Transaction = transaction;
                tipocompra.sp_Insert_Tipo_Compra(request.descripcion, request.activo);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ModificarTipoCompra(Tipo_Compra request)
        {
            Tipo_CompraTableAdapter tipocompra = new Tipo_CompraTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                tipocompra.Connection.Open();
                transaction = tipocompra.Connection.BeginTransaction();
                tipocompra.Transaction = transaction;
                tipocompra.sp_Update_Tipo_Compra(request.id_tipo_compra, request.descripcion, request.activo);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerTipoCompraResponses ObtenerTiposCompra(bool soloactivos)
        {
            Tipo_CompraTableAdapter adapter = new Tipo_CompraTableAdapter();
            ObtenerTipoCompraResponses respuesta = new ObtenerTipoCompraResponses();
            try
            {
                Tipo_CompraDataTable datos = adapter.sp_SelectAll_Tipo_Compra_Get(soloactivos);
                respuesta.tiposcompras = new List<LibreriaClasesBD.Tipo_Compra>();
                //transaction.Commit();
                foreach (var tipocompra in datos)
                {
                    LibreriaClasesBD.Tipo_Compra tipocom = new LibreriaClasesBD.Tipo_Compra()
                    {
                        id_tipo_compra = tipocompra.id_tipo_compra,
                        descripcion = tipocompra.descripcion,
                        activo = tipocompra.activo
                    };
                    respuesta.tiposcompras.Add(tipocom);
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {
                respuesta.estado = false;
                //  transaction.Rollback();
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarServicios(Servicios request)
        {
            ServiciosTableAdapter servicio = new ServiciosTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                servicio.Connection.Open();
                transaction = servicio.Connection.BeginTransaction();
                servicio.Transaction = transaction;
                servicio.sp_Insert_Servicios(request.descripcion, request.activo);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ModificarServicio(Servicios request)
        {
            ServiciosTableAdapter servicios = new ServiciosTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                servicios.Connection.Open();
                transaction = servicios.Connection.BeginTransaction();
                servicios.Transaction = transaction;
                servicios.sp_Update_Servicios(request.id_servicio, request.descripcion, request.activo);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerServiciosResponses ObtenerServicios()
        {
            ServiciosTableAdapter adapter = new ServiciosTableAdapter();
            ObtenerServiciosResponses respuesta = new ObtenerServiciosResponses();
            try
            {
                ServiciosDataTable datos = adapter.sp_SelectAll_Servicios_Get();
                respuesta.servicios = new List<LibreriaClasesBD.Servicios>();
                //transaction.Commit();
                foreach (var servicio in datos)
                {
                    LibreriaClasesBD.Servicios serv = new LibreriaClasesBD.Servicios()
                    {
                        id_servicio = servicio.id_servicio,
                        descripcion = servicio.descripcion,
                        activo = servicio.activo
                    };
                    respuesta.servicios.Add(serv);
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {
                respuesta.estado = false;
                //  transaction.Rollback();
            }
            return respuesta;
        }

        [WebMethod]
        public RegistrarCategoriaEmpleadoResponse RegistrarCategoriaEmpleado(Categoria_Empleado request)
        {
            Categoria_EmpleadosTableAdapter cat_empleado = new Categoria_EmpleadosTableAdapter();
            RegistrarCategoriaEmpleadoResponse respuesta = new RegistrarCategoriaEmpleadoResponse();
            SqlTransaction transaction = null;
            try
            {
                cat_empleado.Connection.Open();
                transaction = cat_empleado.Connection.BeginTransaction();
                cat_empleado.Transaction = transaction;
                cat_empleado.sp_Insert_Categoria_Empleados(request.nombre_categoria, request.nombre_categoria);
                transaction.Commit();
                respuesta.estado = 1;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = 0;
            }
            return respuesta;
        }

        [WebMethod]
        public ModificarCategoriaEmpleadoResponse ModificarCategoriaEmpleado(Categoria_Empleado request)
        {
            Categoria_EmpleadosTableAdapter cat_empleado = new Categoria_EmpleadosTableAdapter();
            ModificarCategoriaEmpleadoResponse respuesta = new ModificarCategoriaEmpleadoResponse();
            SqlTransaction transaction = null;
            try
            {
                cat_empleado.Connection.Open();
                transaction = cat_empleado.Connection.BeginTransaction();
                cat_empleado.Transaction = transaction;
                cat_empleado.sp_Update_Categoria_Empleados(request.id_categoria, request.nombre_categoria, request.descripcion, request.activo);
                transaction.Commit();
                respuesta.estado = 1;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = 0;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerCategoriaEmpleadoResponses ObtenerCategoriaEmpleado(bool soloactivos)
        {
            Categoria_EmpleadosTableAdapter adapter = new Categoria_EmpleadosTableAdapter();
            ObtenerCategoriaEmpleadoResponses respuesta = new ObtenerCategoriaEmpleadoResponses();
            try
            {
                Categoria_EmpleadosDataTable datos = adapter.sp_SelectAll_Categoria_Empleado_Get(soloactivos);
                respuesta.categoria = new List<Categoria_Empleado>();
                //transaction.Commit();
                foreach (var categorias in datos)
                {
                    Categoria_Empleado cat = new Categoria_Empleado()
                    {
                        id_categoria = categorias.id_categoria,
                        nombre_categoria = categorias.nombre_categoria,
                        descripcion = categorias.descripcion,
                        activo = categorias.activo
                    };
                    respuesta.categoria.Add(cat);
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {
                respuesta.estado = false;
                //  transaction.Rollback();
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerCategoriaProductoResponses ObtenerCategoriaProductos(bool soloactivos)
        {
            Categoria_ProductoTableAdapter adapter = new Categoria_ProductoTableAdapter();
            ObtenerCategoriaProductoResponses respuesta = new ObtenerCategoriaProductoResponses();
            try
            {
                Categoria_ProductoDataTable datos = adapter.sp_SelectAll_Categoria_Producto_Get(soloactivos);
                respuesta.categorias = new List<LibreriaClasesBD.Categoria_Producto>();
                //transaction.Commit();
                foreach (var categorias in datos)
                {
                    LibreriaClasesBD.Categoria_Producto cat = new LibreriaClasesBD.Categoria_Producto()
                    {
                        id_categoria = categorias.id_categoria,
                        nombre_categoria = categorias.nombre_categoria,
                        descripcion = categorias.descripcion,
                        activo = categorias.activo
                    };
                    respuesta.categorias.Add(cat);
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {
                respuesta.estado = false;
                //  transaction.Rollback();
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarSucursal(Sucursales request)
        {
            SucursalesTableAdapter adapter = new SucursalesTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Insert_Sucursales(request.nombre_sucursal, request.direccion_sucursal, request.activo);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ModificarSucursal(Sucursales request)
        {
            SucursalesTableAdapter adapter = new SucursalesTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Update_Sucursal(request.id_sucursal, request.nombre_sucursal, request.direccion_sucursal, request.activo);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerSucursalesResponses ObtenerSucursales(bool soloactivos)
        {
            SucursalesTableAdapter adapter = new SucursalesTableAdapter();
            ObtenerSucursalesResponses respuesta = new ObtenerSucursalesResponses();
            try
            {
                SucursalesDataTable datos = adapter.sp_SelectAll_Sucursal_Get(soloactivos);
                respuesta.sucursales = new List<Sucursales>();
                //transaction.Commit();
                foreach (var sucursales in datos)
                {
                    LibreriaClasesBD.Sucursales sucursal = new LibreriaClasesBD.Sucursales()
                    {
                        id_sucursal = sucursales.id_sucursal,
                        nombre_sucursal = sucursales.nombre_sucursal,
                        direccion_sucursal = sucursales.direccion_sucursal,
                        activo = sucursales.activo
                    };
                    respuesta.sucursales.Add(sucursal);
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {
                respuesta.estado = false;
                //  transaction.Rollback();
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarCategoriaProducto(Categoria_Producto request)
        {
            Categoria_ProductoTableAdapter cat_producto = new Categoria_ProductoTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                cat_producto.Connection.Open();
                transaction = cat_producto.Connection.BeginTransaction();
                cat_producto.Transaction = transaction;
                cat_producto.sp_Insert_Categoria_Producto(request.descripcion, request.activo, request.nombre_categoria);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ModificarCategoriaProducto(Categoria_Producto request)
        {
            Categoria_ProductoTableAdapter cat_producto = new Categoria_ProductoTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                cat_producto.Connection.Open();
                transaction = cat_producto.Connection.BeginTransaction();
                cat_producto.Transaction = transaction;
                cat_producto.sp_Update_Categoria_Producto(request.id_categoria, request.descripcion, request.nombre_categoria, request.activo);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = true;
            }
            return respuesta;
        }

        [WebMethod]
        public RegistrarEmpleadoResponses RegistrarEmpleado(Empleado request)
        {
            EmpleadosTableAdapter adapter = new EmpleadosTableAdapter();
            QueriesTableAdapter funcion = new QueriesTableAdapter();
            SqlTransaction transaction = null;
            RegistrarEmpleadoResponses respuesta = new RegistrarEmpleadoResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                if ((bool)funcion.Verificar_Cedula_Empleado_Unica(request.cedula))
                {
                    respuesta.cedulanovalida = false;
                    adapter.sp_Insert_Empleados(request.nombre, request.apellido, request.tipo_empleado.id_categoria, request.email, request.cedula, request.salario, request.fecha_nac, request.direccion, request.num_telefono, request.estado.id_estado, request.sucursal.id_sucursal, request.ruta_foto);
                    transaction.Commit();
                }
                else
                {
                    respuesta.cedulanovalida = true;
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {

                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ModificarEmpleadoResponses ModificarEmpleado(Empleado request)
        {
            EmpleadosTableAdapter adapter = new EmpleadosTableAdapter();
            QueriesTableAdapter funcion = new QueriesTableAdapter();
            SqlTransaction transaction = null;
            ModificarEmpleadoResponses respuesta = new ModificarEmpleadoResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                if ((bool)funcion.Verificar_Cedula_Empleado_Sea_de_El(request.cedula, request.id_empleado))
                {
                    respuesta.cedulanovalida = false;
                    adapter.sp_Update_Empleados(request.id_empleado, request.nombre, request.apellido, request.tipo_empleado.id_categoria, request.email, request.cedula, request.salario, request.fecha_nac, request.direccion, request.num_telefono, request.estado.id_estado, request.sucursal.id_sucursal, request.ruta_foto);
                    transaction.Commit();
                }
                else
                {
                    respuesta.cedulanovalida = true;
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {

                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerTodosEmpleadoResponses ObtenerTodosLosEmpleados()
        {
            EmpleadosTableAdapter adapter = new EmpleadosTableAdapter();
            SqlTransaction transaction = null;
            ObtenerTodosEmpleadoResponses respuesta = new ObtenerTodosEmpleadoResponses();
            try
            {
                respuesta.empleados = new List<LibreriaClasesBD.Empleado>();
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                EmpleadosDataTable datos = adapter.sp_SelectAll_Empleados_Get();
                transaction.Commit();
                foreach (var empleado in datos)
                {

                    LibreriaClasesBD.Empleado emp = new LibreriaClasesBD.Empleado()
                    {
                        id_empleado = empleado.id_empleado,
                        nombre = empleado.nombre,
                        apellido = empleado.apellido,
                        tipo_empleado = new LibreriaClasesBD.Categoria_Empleado { id_categoria = empleado.id_tipo_empleado },
                        email = empleado.email,
                        cedula = empleado.cedula,
                        salario = empleado.salario,
                        fecha_nac = empleado.fecha_nac,
                        direccion = empleado.direccion,
                        num_telefono = empleado.num_telefono,
                        estado = new LibreriaClasesBD.Estados() { id_estado = empleado.id_estado, },
                        sucursal = new LibreriaClasesBD.Sucursales() { id_sucursal = empleado.id_sucursal }
                    };
                    respuesta.empleados.Add(emp);
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {

                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerEmpleadoPorIDResponses ObtenerEmpleadoPorID(int id_empleado)
        {
            EmpleadosTableAdapter adapter = new EmpleadosTableAdapter();
            SqlTransaction transaction = null;
            ObtenerEmpleadoPorIDResponses respuesta = new ObtenerEmpleadoPorIDResponses();
            try
            {
                respuesta.empleado = new LibreriaClasesBD.Empleado();
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                EmpleadosDataTable datos = adapter.sp_Select_Empleado_ByID_Get(id_empleado);
                transaction.Commit();
                foreach (var empleado in datos)
                {
                    LibreriaClasesBD.Empleado emp = new LibreriaClasesBD.Empleado()
                    {
                        id_empleado = empleado.id_empleado,
                        nombre = empleado.nombre,
                        apellido = empleado.apellido,
                        tipo_empleado = new LibreriaClasesBD.Categoria_Empleado { id_categoria = empleado.id_tipo_empleado },
                        email = empleado.email,
                        cedula = empleado.cedula,
                        salario = empleado.salario,
                        fecha_nac = empleado.fecha_nac,
                        direccion = empleado.direccion,
                        num_telefono = empleado.num_telefono,
                        estado = new LibreriaClasesBD.Estados() { id_estado = empleado.id_estado, },
                        sucursal = new LibreriaClasesBD.Sucursales() { id_sucursal = empleado.id_sucursal }
                    };

                    respuesta.empleado = emp;
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerEmpleadoCoindicanResponses ObtenerEmpleadoCoindican(string nombre, string cedula, string telefono)
        {
            EmpleadosTableAdapter adapter = new EmpleadosTableAdapter();
            SqlTransaction transaction = null;
            ObtenerEmpleadoCoindicanResponses respuesta = new ObtenerEmpleadoCoindicanResponses();
            try
            {
                EmpleadosDataTable datos;
                if (nombre is null && cedula is null)
                {
                    datos = adapter.sp_Select_Empleado_By_Campos_Especificos_Get(true, false, false, null, null, telefono);
                }
                else if (cedula is null && telefono is null)
                {
                    datos = adapter.sp_Select_Empleado_By_Campos_Especificos_Get(false, true, false, null, nombre, null);
                }
                else
                {
                    datos = adapter.sp_Select_Empleado_By_Campos_Especificos_Get(false, false, true, cedula, null, null);
                }

                respuesta.empleados = new List<LibreriaClasesBD.Empleado>();
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                transaction.Commit();
                foreach (var empleado in datos)
                {
                    LibreriaClasesBD.Empleado emp = new LibreriaClasesBD.Empleado()
                    {
                        id_empleado = empleado.id_empleado,
                        nombre = empleado.nombre,
                        apellido = empleado.apellido,
                        tipo_empleado = new LibreriaClasesBD.Categoria_Empleado { id_categoria = empleado.id_tipo_empleado },
                        email = empleado.email,
                        cedula = empleado.cedula,
                        salario = empleado.salario,
                        fecha_nac = empleado.fecha_nac,
                        direccion = empleado.direccion,
                        num_telefono = empleado.num_telefono,
                        estado = new LibreriaClasesBD.Estados() { id_estado = empleado.id_estado, },
                        sucursal = new LibreriaClasesBD.Sucursales() { id_sucursal = empleado.id_sucursal },
                        ruta_foto = empleado.ruta_foto
                    };

                    respuesta.empleados.Add(emp);
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarEnvio(Envios request)
        {
            EnviosTableAdapter adapter = new EnviosTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;

                adapter.sp_Insert_Envios(request.cliente.id_cliente, request.factura.id_factura, request.direccion_envio, request.entregado, request.entrega_en_sucursal);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ModificarEnvio(Envios request)
        {
            EnviosTableAdapter adapter = new EnviosTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;

                adapter.sp_Update_Envios(request.id_envio, request.cliente.id_cliente, request.factura.id_factura, request.direccion_envio, request.entregado, request.entrega_en_sucursal);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerEnviosResponses ObtenerEnvios(bool solonoentregados)
        {
            EnviosTableAdapter adapter = new EnviosTableAdapter();
            SqlTransaction transaction = null;
            ObtenerEnviosResponses respuesta = new ObtenerEnviosResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                EnviosDataTable datos = adapter.sp_SelectAll_Envio_Get(solonoentregados);
                respuesta.Envios = new List<Envios>();
                foreach (var envios in datos)
                {
                    Envios env = new Envios()
                    {
                        id_envio = envios.id_envio,
                        cliente = new Cliente() { id_cliente = envios.id_cliente},
                        factura = new Factura() { id_factura = envios.id_factura},
                        direccion_envio = envios.direccion_envio,
                        entregado = envios.entregado,
                        entrega_en_sucursal = envios.entrega_en_sucursal
                    };
                    respuesta.Envios.Add(env);
                }
                transaction.Commit();
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerEnviosByIdFacturaResponses ObtenerEnviosByIDFactura(int id_factura)
        {
            EnviosTableAdapter adapter = new EnviosTableAdapter();
            SqlTransaction transaction = null;
            ObtenerEnviosByIdFacturaResponses respuesta = new ObtenerEnviosByIdFacturaResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                EnviosDataTable datos = adapter.sp_Select_Envio_PorIDFactura_Get(id_factura);
                respuesta.envio = new Envios();
                Envios envio = new Envios()
                {
                    id_envio = datos[0].id_envio,
                    cliente = new Cliente() { id_cliente = datos[0].id_cliente },
                    factura = new Factura() { id_factura = datos[0].id_factura },
                    direccion_envio = datos[0].direccion_envio,
                    entregado = datos[0].entregado,
                    entrega_en_sucursal = datos[0].entrega_en_sucursal
                };
                respuesta.envio = envio;
                transaction.Commit();
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        ///AÑADIR PUNTO DE REORDEN A PRODUCTO

        [WebMethod]
        public bool ModificarProductos(Productos request)
        {
            ProductosTableAdapter adapter = new ProductosTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Update_Productos(request.id_producto, request.nombre, request.activo, request.precio, request.descripcion, request.categoria.id_categoria, request.descuento,request.punto_reorden);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerProductosByIDResponses ObtenerProductosByID(int id_prod)
        {
            ProductosTableAdapter adapter = new ProductosTableAdapter();
            SqlTransaction transaction = null;
            ObtenerProductosByIDResponses respuesta = new ObtenerProductosByIDResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                ProductosDataTable datos = adapter.sp_Select_Productos_ByID_Get(id_prod);
                Productos producto = new Productos()
                {
                    id_producto = datos[0].id_producto,
                    nombre = datos[0].nombre,
                    activo = datos[0].activo,
                    precio = datos[0].precio,
                    descripcion = datos[0].descripcion,
                    categoria = new Categoria_Producto { id_categoria = datos[0].id_categoria },
                    descuento = datos[0].descuento
                };
                respuesta.Producto = new Productos();
                respuesta.Producto = producto;
                transaction.Commit();
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerProductosResponses ObtenerProductos(bool condescontinuados)
        {
            ProductosTableAdapter adapter = new ProductosTableAdapter();
            SqlTransaction transaction = null;
            ObtenerProductosResponses respuesta = new ObtenerProductosResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                ProductosDataTable datos = adapter.sp_SelectAll_Producto_Get();
                respuesta.productos = new List<Productos>();
                foreach (var producto in datos)
                {
                    Productos prod = new Productos()
                    {
                        id_producto = producto.id_producto,
                        nombre = producto.nombre,
                        activo = producto.activo,
                        precio = producto.precio,
                        descripcion = producto.descripcion,
                        categoria = new Categoria_Producto { id_categoria = producto.id_categoria },
                        descuento = producto.descuento,
                        foto_productos = ObtenerFotosProductos(producto.id_producto)
                    };
                    respuesta.productos.Add(prod);
                }
                transaction.Commit();
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerProductosCoincidanResponses ObtenerProductosCoincidan(string id_prod, string nombre_prod)
        {
            ProductosTableAdapter adapter = new ProductosTableAdapter();
            SqlTransaction transaction = null;
            ObtenerProductosCoincidanResponses respuesta = new ObtenerProductosCoincidanResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                ProductosDataTable datos;
                respuesta.productos = new List<Productos>();
                if (id_prod is null)
                {
                    datos = adapter.sp_Select_Productos_By_Campos_Especificos(false, true, null, nombre_prod);
                }
                else
                {
                    datos = adapter.sp_Select_Productos_By_Campos_Especificos(true, false, int.Parse(id_prod), null);
                }

                foreach (var producto in datos)
                {
                    Productos prod = new Productos()
                    {
                        id_producto = producto.id_producto,
                        nombre = producto.nombre,
                        activo = producto.activo,
                        precio = producto.precio,
                        descripcion = producto.descripcion,
                        categoria = new Categoria_Producto { id_categoria = producto.id_categoria },
                        descuento = producto.descuento
                    };
                    respuesta.productos.Add(prod);
                }
                transaction.Commit();
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }
        
        public void RegistrarFotosProductos(string nombre_producto, List<string> fotos)
        {
            Fotos_ProductosTableAdapter adapter = new Fotos_ProductosTableAdapter();
            List<string> respuesta = new List<string>();
            SqlTransaction trasaction = null;
            try
            {
                adapter.Connection.Open();
                trasaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = trasaction;
                ObtenerProductosCoincidanResponses resp = new ObtenerProductosCoincidanResponses();
                resp = ObtenerProductosCoincidan(null, nombre_producto);
                int idprod = resp.productos[0].id_producto;
                adapter.sp_Delete_Fotos_Productos(idprod);
                trasaction.Commit();
                foreach (var ft in fotos)
                {
                    adapter.sp_Insert_Fotos_Productos(idprod, ft);
                }
            }
            catch (Exception)
            {

                trasaction.Rollback();
            }
        }

        [WebMethod]
        public bool RegistrarProductos(Productos request)
        {
            ProductosTableAdapter adapter = new ProductosTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Insert_Productos(request.nombre, request.activo, request.precio, request.descripcion, request.categoria.id_categoria, request.descuento,request.punto_reorden);
                RegistrarFotosProductos(request.nombre, request.foto_productos);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarProveedores(Proveedores request)
        {
            ProveedoresTableAdapter adapter = new ProveedoresTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Insert_Proveedores(request.nombre, request.rnc, request.activo, request.email, request.telefono, request.direccion);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ModificarProveedores(Proveedores request)
        {
            ProveedoresTableAdapter adapter = new ProveedoresTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Update_Proveedores(request.id_proveedor, request.nombre, request.rnc, request.activo, request.email, request.telefono, request.direccion);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerProveedoresResponses ObtenerProveedores(bool soloactivos)
        {
            ProveedoresTableAdapter adapter = new ProveedoresTableAdapter();
            SqlTransaction transaction = null;
            ObtenerProveedoresResponses respuesta = new ObtenerProveedoresResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                ProveedoresDataTable datos = adapter.sp_SelectAll_Proveedor(soloactivos);
                respuesta.proveedores = new List<Proveedores>();
                transaction.Commit();
                foreach (var proveedor in datos)
                {
                    Proveedores prov = new Proveedores()
                    {
                        id_proveedor = proveedor.id_proveedor,
                        nombre = proveedor.nombre,
                        activo = proveedor.activo,
                        rnc = proveedor.rnc,
                        email = proveedor.email,
                        telefono = proveedor.telefono,
                        direccion = proveedor.direccion
                    };
                    respuesta.proveedores.Add(prov);
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerProveedoresByIDResponses ObtenerProveedoresByID(int id_proveedor)
        {
            ProveedoresTableAdapter adapter = new ProveedoresTableAdapter();
            SqlTransaction transaction = null;
            ObtenerProveedoresByIDResponses respuesta = new ObtenerProveedoresByIDResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                ProveedoresDataTable datos = adapter.sp_Select_Proveedores_ByID(id_proveedor);
                respuesta.proveedor = new Proveedores();
                transaction.Commit();
                Proveedores prov = new Proveedores()
                {
                    nombre = datos[0].nombre,
                    activo = datos[0].activo,
                    rnc = datos[0].rnc,
                    email = datos[0].email,
                    telefono = datos[0].telefono,
                    direccion = datos[0].direccion
                };
                respuesta.proveedor = prov;
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarComentarioCliente(Comentarios_Clientes request)
        {
            Comentarios_ClientesTableAdapter adapter = new Comentarios_ClientesTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Insert_Comentarios_Clientes(request.calificacion, request.comentario, request.cliente.id_cliente, request.producto);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ModificarComentarioCliente(Comentarios_Clientes request)
        {
            Comentarios_ClientesTableAdapter adapter = new Comentarios_ClientesTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Update_Comentarios_Clientes(request.id_comentario, request.calificacion, request.comentario, request.cliente.id_cliente);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerComentarioClienteByProductoResponses ObtenerComentarioClienteByProducto(int id_producto)
        {
            sp_SelectAll_Comentarios_Clientes_ByProductoTableAdapter adapter = new sp_SelectAll_Comentarios_Clientes_ByProductoTableAdapter();
            SqlTransaction transaction = null;
            ObtenerComentarioClienteByProductoResponses respuesta = new ObtenerComentarioClienteByProductoResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                sp_SelectAll_Comentarios_Clientes_ByProductoDataTable datos = adapter.GetData(id_producto);
                respuesta.comentarios = new List<Comentarios_Clientes>();
                foreach (var comentario in datos)
                {
                    Comentarios_Clientes coment = new Comentarios_Clientes()
                    {
                        id_comentario = comentario.id_comentario,
                        calificacion = comentario.calificacion,
                        comentario = comentario.comentario,
                        cliente = new Cliente() { apellido = comentario.apellido, nombre = comentario.nombre, id_cliente = comentario.id_cliente },
                        producto = comentario.id_producto
                    };
                    respuesta.comentarios.Add(coment);
                }
                transaction.Commit();
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerAllInventarioResponses ObtenerTodosLosInventarios()
        {
            InventarioTableAdapter adapter = new InventarioTableAdapter();
            SqlTransaction transaction = null;
            ObtenerAllInventarioResponses respuesta = new ObtenerAllInventarioResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                InventarioDataTable datos = adapter.sp_SelectAll_Inventario_Get();
                respuesta.Inventario = new List<Inventario>();
                foreach (var inventario in datos)
                {
                    Inventario ivnt = new Inventario()
                    {
                        id_registro = inventario.id_registro,
                        producto = new Productos() { id_producto = inventario.id_producto },
                        cant_stock = inventario.cant_stock,
                        cant_camino = inventario.cant_camino,
                        sucursal = new Sucursales() { id_sucursal = inventario.id_sucursal }
                    };
                    respuesta.Inventario.Add(ivnt);
                }
                transaction.Commit();
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerInventarioEspecificoResponses ObtenerInventarioIDSucursalProducto(int id_producto, int id_sucursal)
        {
            InventarioTableAdapter adapter = new InventarioTableAdapter();
            SqlTransaction transaction = null;
            ObtenerInventarioEspecificoResponses respuesta = new ObtenerInventarioEspecificoResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                InventarioDataTable datos = adapter.sp_Select_Inventarios_Sucursal_Producto_Get(id_sucursal, id_producto);
                respuesta.Inventario = new Inventario();
                Inventario ivnt = new Inventario()
                {
                    id_registro = datos[0].id_registro,
                    producto = new Productos() { id_producto = datos[0].id_producto },
                    cant_stock = datos[0].cant_stock,
                    cant_camino = datos[0].cant_camino,
                    sucursal = new Sucursales() { id_sucursal = datos[0].id_sucursal }
                };
                respuesta.Inventario = ivnt;
                transaction.Commit();
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerAllInventarioResponses ObtenerInventariosCoincidanCon(string nombre_sucursal, string nombre_producto)
        {
            InventarioTableAdapter adapter = new InventarioTableAdapter();
            SqlTransaction transaction = null;
            ObtenerAllInventarioResponses respuesta = new ObtenerAllInventarioResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                InventarioDataTable datos;
                if (nombre_producto is null) {
                    datos = adapter.sp_Select_Parecidos_Inventarios_Sucursal_Producto_Get( null,nombre_producto, true, false);
                }
                else
                {
                    datos = adapter.sp_Select_Parecidos_Inventarios_Sucursal_Producto_Get(nombre_sucursal, null, false, true);
                }
                respuesta.Inventario = new List<Inventario>();
                foreach (var inventario in datos)
                {
                    Inventario ivnt = new Inventario()
                    {
                        id_registro = inventario.id_registro,
                        producto = new Productos() { id_producto = inventario.id_producto },
                        cant_stock = inventario.cant_stock,
                        cant_camino = inventario.cant_camino,
                        sucursal = new Sucursales() { id_sucursal = inventario.id_sucursal }
                    };
                    respuesta.Inventario.Add(ivnt);
                }
                transaction.Commit();
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarComprasProveedores(RegistrarCompraProveedoresRequest request)
        {
            Compras_ProveedoresTableAdapter adapter = new Compras_ProveedoresTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Insert_Compras_Proveedores(request.compra.cod_envio, request.compra.descripcion, request.compra.fecha_llegada, request.compra.proveedor.id_proveedor, request.compra.valor_total, request.compra.estado.id_estado, request.compra.cant_productos_dif_ordenados, request.compra.sucursal.id_sucursal);

                foreach (var item in request.productoscomprados)
                {
                    adapter.sp_Insert_Compra_Producto(item.producto.id_producto, request.compra.id_compra, item.cant_ordenado, item.precio_unitario);
                }
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ModificarComprasProveedores(RegistrarCompraProveedoresRequest request)
        {
            Compras_ProveedoresTableAdapter adapter = new Compras_ProveedoresTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Update_Compras_Proveedores(request.compra.id_compra, request.compra.cod_envio, request.compra.descripcion, request.compra.fecha_llegada, request.compra.proveedor.id_proveedor, request.compra.valor_total, request.compra.estado.id_estado, request.compra.cant_productos_dif_ordenados, request.compra.sucursal.id_sucursal);
                adapter.sp_Delete_Compra_Producto(request.compra.id_compra);
                foreach (var item in request.productoscomprados)
                {
                    adapter.sp_Insert_Compra_Producto(item.producto.id_producto, request.compra.id_compra, item.cant_ordenado, item.precio_unitario);
                }
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerComprasProveedoresResponses ObtenerComprasProveedores(bool porsucursal, int id_sucursal)
        {
            Compras_ProveedoresTableAdapter adapter = new Compras_ProveedoresTableAdapter();
            SqlTransaction transaction = null;
            ObtenerComprasProveedoresResponses respuesta = new ObtenerComprasProveedoresResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                Compras_ProveedoresDataTable datos;
                if (porsucursal)
                {
                    datos = adapter.sp_SelectAll_Compras_Proveedores(true, id_sucursal);
                } else
                {
                    datos = adapter.sp_SelectAll_Compras_Proveedores(false, 0);
                }
                transaction.Commit();
                respuesta.compras = new List<Compras_Proveedores>();
                foreach (var compras in datos)
                {
                    Compras_Proveedores comp = new Compras_Proveedores()
                    {
                        id_compra = compras.id_compra,
                        cod_envio = compras.cod_envio,
                        descripcion = compras.descripcion,
                        fecha_llegada = compras.fecha_llegada,
                        proveedor = new Proveedores() { id_proveedor = compras.id_proveedor },
                        valor_total = compras.valor_total,
                        estado = new Estados { id_estado = compras.id_estado },
                        sucursal = new Sucursales { id_sucursal = compras.id_sucursal },
                        cant_productos_dif_ordenados = compras.cant_productos_dif_ordenados
                    };
                    respuesta.compras.Add(comp);
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerComprasProveedoresResponses ObtenerComprasProveedoresEspecifico(bool porcodenvio, bool pornombresucursal, bool porproveedor, bool porestado, string campo)
        {
            Compras_ProveedoresTableAdapter adapter = new Compras_ProveedoresTableAdapter();
            SqlTransaction transaction = null;
            ObtenerComprasProveedoresResponses respuesta = new ObtenerComprasProveedoresResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                Compras_ProveedoresDataTable datos = new Compras_ProveedoresDataTable();
                if (porcodenvio)
                {
                    datos = adapter.sp_Select_Parecidos_Compras_Proveedores_Get(false, true, false, false, campo, 0);
                }
                else if (pornombresucursal)
                {
                    datos = adapter.sp_Select_Parecidos_Compras_Proveedores_Get(true, false, false, false, campo, 0);
                }
                else if (porproveedor)
                {
                    datos = adapter.sp_Select_Parecidos_Compras_Proveedores_Get(false, false, true, false, campo, 0);
                }
                else if (porestado)
                {
                    datos = adapter.sp_Select_Parecidos_Compras_Proveedores_Get(false, false, false, true, "a", int.Parse(campo));
                }
                transaction.Commit();
                respuesta.compras = new List<Compras_Proveedores>();
                foreach (var compras in datos)
                {
                    Compras_Proveedores comp = new Compras_Proveedores()
                    {
                        id_compra = compras.id_compra,
                        cod_envio = compras.cod_envio,
                        descripcion = compras.descripcion,
                        fecha_llegada = compras.fecha_llegada,
                        proveedor = new Proveedores() { id_proveedor = compras.id_proveedor },
                        valor_total = compras.valor_total,
                        estado = new Estados { id_estado = compras.id_estado },
                        sucursal = new Sucursales { id_sucursal = compras.id_sucursal },
                        cant_productos_dif_ordenados = compras.cant_productos_dif_ordenados
                    };
                    respuesta.compras.Add(comp);
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerComprasProductoResponses ObtenerComprasProducto(int id_compra)
        {
            Compra_ProductoTableAdapter adapter = new Compra_ProductoTableAdapter();
            SqlTransaction transaction = null;
            ObtenerComprasProductoResponses respuesta = new ObtenerComprasProductoResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                Compra_ProductoDataTable datos = adapter.sp_SelectAll_Compra_Producto_Por_Compra(id_compra);
                transaction.Commit();
                respuesta.productos = new List<Compra_Producto>();
                foreach (var productos in datos)
                {
                    Compra_Producto comp = new Compra_Producto()
                    {
                        id_registro = productos.id_registro,
                        producto = new Productos() { id_producto = productos.id_producto },
                        compra = new Compras_Proveedores() { id_compra = productos.id_compra },
                        cant_ordenado = productos.cant_ordenado,
                        precio_unitario = productos.precio_unitario
                    };
                    respuesta.productos.Add(comp);
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarIncioFinSesionCliente(bool fin, bool inicio, int id_cliente, string tiempocon)
        {
            Registro_ClienteTableAdapter adapter = new Registro_ClienteTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                if (inicio)
                {
                    adapter.sp_Insert_Registro_Cliente(id_cliente);
                } else if (fin)
                {
                    adapter.sp_Update_Registro_Cliente(id_cliente, tiempocon);
                }
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarIncioFinSesionEmpleado(bool fin, bool inicio, int id_empleado, string tiempocon)
        {
            Registro_EmpleadosTableAdapter adapter = new Registro_EmpleadosTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                if (inicio)
                {
                    adapter.sp_Insert_Registro_Empleados(id_empleado, tiempocon);
                }
                else if (fin)
                {
                    adapter.sp_Update_Registro_Empleados(id_empleado, tiempocon);
                }
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public RegistrarClienteResponses RegistrarCliente(Cliente request)
        {
            ClienteTableAdapter adapter = new ClienteTableAdapter();
            QueriesTableAdapter funcion = new QueriesTableAdapter();
            SqlTransaction transaction = null;
            RegistrarClienteResponses respuesta = new RegistrarClienteResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                if ((bool)funcion.Verificar_Email_Cliente_Unico(request.email))
                {
                    respuesta.emailtomado = false;
                    adapter.sp_Insert_Clientes(request.nombre, request.apellido, request.fecha_nac, request.email, request.direccion, request.num_telefono, request.estado.id_estado, request.ruta_foto);
                }
                else
                {
                    respuesta.estado = true;
                }
                transaction.Commit();
                respuesta.estado = true;
            }
            catch (Exception)
            {

                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ModificarClienteResponses ModificarCliente(Cliente request)
        {
            ClienteTableAdapter adapter = new ClienteTableAdapter();
            QueriesTableAdapter funcion = new QueriesTableAdapter();
            SqlTransaction transaction = null;
            ModificarClienteResponses respuesta = new ModificarClienteResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                if ((bool)funcion.Verificar_Email_Cliente_Sea_de_El(request.email, request.id_cliente))
                {
                    respuesta.emailtomado = false;
                    adapter.sp_Update_Clientes(request.id_cliente, request.nombre, request.apellido, request.fecha_nac, request.email, request.direccion, request.num_telefono, request.estado.id_estado, request.ruta_foto);
                }
                else
                {
                    respuesta.emailtomado = true;
                }
                transaction.Commit();
                respuesta.estado = true;
            }
            catch (Exception)
            {

                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerClientePorIDResponses ObtenerClientePorID(int id_client)
        {
            ClienteTableAdapter adapter = new ClienteTableAdapter();
            SqlTransaction transaction = null;
            ObtenerClientePorIDResponses respuesta = new ObtenerClientePorIDResponses();
            try
            {
                respuesta.cliente = new Cliente();
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                ClienteDataTable datos = adapter.sp_Select_Cliente_ByID_Get(id_client);
                transaction.Commit();
                Cliente clt = new Cliente()
                {
                    id_cliente = datos[0].id_cliente,
                    nombre = datos[0].nombre,
                    apellido = datos[0].apellido,
                    fecha_nac = datos[0].fecha_nac,
                    email = datos[0].email,
                    direccion = datos[0].direccion,
                    num_telefono = datos[0].num_telefono,
                    estado = new Estados { id_estado = datos[0].id_estado },
                    ruta_foto = datos[0].ruta_foto
                };
                respuesta.cliente = clt;
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerClientesCoindicanResponses ObtenerListaClientesCoindican(string nombre = null, string correo = null, string telefono = null)
        {
            ClienteTableAdapter adapter = new ClienteTableAdapter();
            SqlTransaction transaction = null;
            ObtenerClientesCoindicanResponses respuesta = new ObtenerClientesCoindicanResponses();
            try
            {
                ClienteDataTable datos;
                if (nombre is null && telefono is null)
                {
                    datos = adapter.sp_Select_Cliente_By_Campos_Especificos(true, false, false, correo, null, null);

                }
                else if (correo is null && telefono is null)
                {
                    datos = adapter.sp_Select_Cliente_By_Campos_Especificos(false, true, false, null, nombre, null);
                }
                else
                {
                    datos = adapter.sp_Select_Cliente_By_Campos_Especificos(false, false, true, null, null, telefono);

                }

                respuesta.cliente = new List<Cliente>();
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                transaction.Commit();
                foreach (var cliente in datos)
                {
                    Cliente clt = new Cliente()
                    {
                        id_cliente = cliente.id_cliente,
                        nombre = cliente.nombre,
                        apellido = cliente.apellido,
                        fecha_nac = cliente.fecha_nac,
                        email = cliente.email,
                        direccion = cliente.direccion,
                        num_telefono = cliente.num_telefono,
                        estado = new Estados { id_estado = cliente.id_estado },
                        ruta_foto = cliente.ruta_foto
                    };
                    respuesta.cliente.Add(clt);
                }
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarTarjetaCredito(Tarjeta_Credito request)
        {
            Tarjeta_CreditoTableAdapter adapter = new Tarjeta_CreditoTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Insert_Tarjeta_Credito(request.cliente.id_cliente, request.nombre_dueno, request.num_tarjeta, request.fecha_vencimiento, request.cvv, request.activo);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {

                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ModificarTarjetaCredito(Tarjeta_Credito request)
        {
            Tarjeta_CreditoTableAdapter adapter = new Tarjeta_CreditoTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Update_Tarjeta_Credito(request.id_tarjeta_credito, request.cliente.id_cliente, request.nombre_dueno, request.num_tarjeta, request.fecha_vencimiento, request.cvv, request.activo);
                respuesta = true;
            }
            catch (Exception)
            {

                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerTarjetaDeUnClienteResponses ObtenerTarjetaDeUnCliente(int id_cliente)
        {
            Tarjeta_CreditoTableAdapter adapter = new Tarjeta_CreditoTableAdapter();
            SqlTransaction transaction = null;
            ObtenerTarjetaDeUnClienteResponses respuesta = new ObtenerTarjetaDeUnClienteResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                Tarjeta_CreditoDataTable datos = adapter.sp_Select_Tarjeta_Credito_DeUnCliente(id_cliente);
                transaction.Commit();
                if (datos.Count > 0)
                {
                    respuesta.tarjetas = new List<Tarjeta_Credito>();
                    foreach (var tarjeta in datos)
                    {
                        Tarjeta_Credito trj = new Tarjeta_Credito()
                        {
                            id_tarjeta_credito = tarjeta.id_tarjeta_credito,
                            cliente = new Cliente() { id_cliente = tarjeta.id_cliente },
                            nombre_dueno = tarjeta.nombre_dueno,
                            num_tarjeta = tarjeta.num_tarjeta,
                            fecha_vencimiento = tarjeta.fecha_vencimiento,
                            cvv = tarjeta.cvv,
                            activo = tarjeta.activo
                        };
                        respuesta.tarjetas.Add(trj);
                    }
                    respuesta.estado = true;
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarInfoRegistroEmpleados(Info_Login request)
        {
            EmpleadosTableAdapter adapter = new EmpleadosTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Insert_Info_Registro_Empleados(request.cedula_email, request.hash_password);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {

                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarInfoRegistroCliente(Info_Login request)
        {
            ClienteTableAdapter adapter = new ClienteTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Insert_Info_Registro_Cliente(request.cedula_email, request.hash_password);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {

                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ModificarInfoRegistroEmpleados(Info_Login request)
        {
            EmpleadosTableAdapter adapter = new EmpleadosTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Update_Info_Registro_Empleados(request.cedula_email, request.hash_password);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {

                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ModificarInfoRegistroCliente(Info_Login request)
        {
            ClienteTableAdapter adapter = new ClienteTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Update_Info_Registro_Cliente(request.cedula_email, request.hash_password);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {

                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarTransTarjeta(Trans_Tarjeta request) 
        {
            Trans_TarjetaTableAdapter adapter = new Trans_TarjetaTableAdapter();
            SqlTransaction transaction = null;
            bool respuesta;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Insert_Trans_Tarjeta(request.factuta.id_factura, request.tarjeta.id_tarjeta_credito);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta=false;
            }
            return respuesta;
        }

        [WebMethod]
        public RegistrarNuevaFacturaResponses RegistrarNuevaFactura (Factura request) 
        {
            FacturaTableAdapter adapter = new FacturaTableAdapter();
            RegistrarNuevaFacturaResponses respuesta = new RegistrarNuevaFacturaResponses();
            SqlTransaction transaction = null;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                respuesta.id_fact = (int)adapter.sp_Insert_Factura(request.metpago.id_metpago, request.empleado.id_empleado, request.subtotal_servicio, request.tipo_compra.id_tipo_compra, request.impuestos, request.total_descuento, request.monto_total, request.ncf, request.vencimiento_fact, request.nombre_cliente, request.cliente.id_cliente, request.entrega_domicilio, request.sucursal.id_sucursal, request.servicio.id_servicio);
                transaction.Commit();
                respuesta.estado = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta.estado = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarDetallesNuevaFacturaCompras(List<Detalles_Fact_Compras> request)
        {
            Detalles_Fact_ComprasTableAdapter adapter = new Detalles_Fact_ComprasTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                foreach (var detalle in request)
                {

                    adapter.sp_Insert_Detalles_Fact_Compras(detalle.factura.id_factura,detalle.producto.id_producto,detalle.cant_producto,detalle.precio_unitario,detalle.descuento);
                }
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool RegistrarDetallesNuevaFacturaReparaciones(List<Detalles_Fact_Reparaciones> request)
        {
            Detalles_Fact_ReparacionesTableAdapter adapter = new Detalles_Fact_ReparacionesTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                foreach (var detalle in request)
                {

                    adapter.sp_Insert_Detalles_Fact_Reparaciones(detalle.factura.id_factura,detalle.nombre_producto,detalle.categoria_producto.id_categoria,detalle.descripcion_producto,detalle.descripcion_problema,detalle.valor_reparacion,detalle.fecha_entrega,detalle.estado.id_estado);
                }
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ActualizarEntregaFacturaReparaciones(Detalles_Fact_Reparaciones request)
        {
            Detalles_Fact_ReparacionesTableAdapter adapter = new Detalles_Fact_ReparacionesTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Update_Detalles_Fact_Reparaciones(request.factura.id_factura,request.nombre_producto,request.categoria_producto.id_categoria,request.descripcion_producto,request.descripcion_problema,request.valor_reparacion,request.fecha_entrega,10);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public bool ActualizarReparadoFacturaReparaciones(Detalles_Fact_Reparaciones request)
        {
            Detalles_Fact_ReparacionesTableAdapter adapter = new Detalles_Fact_ReparacionesTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                adapter.sp_Update_Detalles_Fact_Reparaciones(request.factura.id_factura, request.nombre_producto, request.categoria_producto.id_categoria, request.descripcion_producto, request.descripcion_problema, request.valor_reparacion, request.fecha_entrega, 9);
                transaction.Commit();
                respuesta = true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                respuesta = false;
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerVentasResponses ObtenerAllVentas(ObtenerVentasRequest request)
        {
            sp_SelectAll_FacturaTableAdapter adapter = new sp_SelectAll_FacturaTableAdapter();
            ObtenerVentasResponses respuesta = new ObtenerVentasResponses();
            SqlTransaction transaction = null;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                sp_SelectAll_FacturaDataTable datos = adapter.GetData(request.id_servicio);
                transaction.Commit();
                respuesta.facturas = new List<Factura>();
                foreach (var factura in datos)
                {
                    Factura fct = new Factura()
                    {
                        id_factura = factura.id_factura,
                        metpago = new Met_Pagos() { id_metpago = factura.id_metpago, descripcion = factura.Descripcion_Met_Pago },
                        empleado = new Empleado() { id_empleado = factura.id_empleado, nombre = factura.Nombre_Empleado, apellido = factura.Apellido_Empleado },
                        subtotal_servicio = factura.subtotal_servicio,
                        tipo_compra = new Tipo_Compra() { id_tipo_compra = factura.id_tipo_compra, descripcion = factura.Descripcion_Tipo_Compra },
                        impuestos = factura.impuestos,
                        total_descuento = factura.total_descuento,
                        monto_total = factura.monto_total,
                        ncf = factura.ncf,
                        vencimiento_fact = factura.vencimiento_fact,
                        cliente = new Cliente() { id_cliente = factura.id_cliente, nombre = factura.Nombre_Cliente, apellido = factura.Apellido_Cliente, direccion = factura.Direc_Cliente },
                        nombre_cliente = factura.Nombre_Cliente_F,
                        entrega_domicilio = factura.entrega_domicilio,
                        sucursal = new Sucursales() { id_sucursal = factura.id_sucursal, direccion_sucursal = factura.direccion_sucursal },
                        servicio = new Servicios() { id_servicio = factura.id_servicio }
                    };
                    respuesta.facturas.Add(fct);
                }
                respuesta.estado = true;
                transaction.Commit();
            }
            catch (Exception)
            {
                respuesta.estado = false;
                transaction.Rollback();
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerVentasResponses ObtenerAllVentasDeSucursal(ObtenerVentasRequest request)
        {
            sp_SelectAll_Factura_PorSucursalTableAdapter adapter = new sp_SelectAll_Factura_PorSucursalTableAdapter();
            ObtenerVentasResponses respuesta = new ObtenerVentasResponses();
            SqlTransaction transaction = null;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                sp_SelectAll_Factura_PorSucursalDataTable datos = adapter.GetData(request.id_servicio,request.sucursal.id_sucursal);
                transaction.Commit();
                respuesta.facturas = new List<Factura>();
                foreach (var factura in datos)
                {
                    Factura fct = new Factura()
                    {
                        id_factura = factura.id_factura,
                        metpago = new Met_Pagos() { id_metpago = factura.id_metpago, descripcion = factura.Descripcion_Met_Pago },
                        empleado = new Empleado() { id_empleado = factura.id_empleado, nombre = factura.Nombre_Empleado, apellido = factura.Apellido_Empleado },
                        subtotal_servicio = factura.subtotal_servicio,
                        tipo_compra = new Tipo_Compra() { id_tipo_compra = factura.id_tipo_compra, descripcion = factura.Descripcion_Tipo_Compra },
                        impuestos = factura.impuestos,
                        total_descuento = factura.total_descuento,
                        monto_total = factura.monto_total,
                        ncf = factura.ncf,
                        vencimiento_fact = factura.vencimiento_fact,
                        cliente = new Cliente() { id_cliente = factura.id_cliente, nombre = factura.Nombre_Cliente, apellido = factura.Apellido_Cliente, direccion = factura.Direc_Cliente },
                        nombre_cliente = factura.Nombre_Cliente_F,
                        entrega_domicilio = factura.entrega_domicilio,
                        sucursal = new Sucursales() { id_sucursal = factura.id_sucursal, direccion_sucursal = factura.direccion_sucursal },
                        servicio = new Servicios() { id_servicio = factura.id_servicio }
                    };
                    respuesta.facturas.Add(fct);
                }
                respuesta.estado = true;
                transaction.Commit();
            }
            catch (Exception)
            {
                respuesta.estado = false;
                transaction.Rollback();
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerVentasByIDResponses ObtenerVentasDeSucursalByID(ObtenerVentasByIDRequest request)
        {
            sp_Select_Factura_By_IDTableAdapter adapter = new sp_Select_Factura_By_IDTableAdapter();
            ObtenerVentasByIDResponses respuesta = new ObtenerVentasByIDResponses();
            SqlTransaction transaction = null;
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                sp_Select_Factura_By_IDDataTable datos = adapter.GetData(request.id_fact);
                transaction.Commit();
                  Factura fct = new Factura()
                    {
                        id_factura = datos[0].id_factura,
                        metpago = new Met_Pagos() { id_metpago = datos[0].id_metpago, descripcion = datos[0].Descripcion_Met_Pago },
                        empleado = new Empleado() { id_empleado = datos[0].id_empleado, nombre = datos[0].Nombre_Empleado, apellido = datos[0].Apellido_Empleado },
                        subtotal_servicio = datos[0].subtotal_servicio,
                        tipo_compra = new Tipo_Compra() { id_tipo_compra = datos[0].id_tipo_compra, descripcion = datos[0].Descripcion_Tipo_Compra },
                        impuestos = datos[0].impuestos,
                        total_descuento = datos[0].total_descuento,
                        monto_total = datos[0].monto_total,
                        ncf = datos[0].ncf,
                        vencimiento_fact = datos[0].vencimiento_fact,
                        cliente = new Cliente() { id_cliente = datos[0].id_cliente, nombre = datos[0].Nombre_Cliente, apellido = datos[0].Apellido_Cliente, direccion = datos[0].Direc_Cliente },
                        nombre_cliente = datos[0].Nombre_Cliente_F,
                        entrega_domicilio = datos[0].entrega_domicilio,
                        sucursal = new Sucursales() { id_sucursal = datos[0].id_sucursal, direccion_sucursal = datos[0].direccion_sucursal },
                        servicio = new Servicios() { id_servicio = datos[0].id_servicio }
                    };
                respuesta.factura = new Factura();
                    respuesta.factura = fct;
                respuesta.estado = true;
                transaction.Commit();
            }
            catch (Exception)
            {
                respuesta.estado = false;
                transaction.Rollback();
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerDetallesFactComprasResponses ObtenerDetallesFacturaCompra(int id_factura)
        {
            Detalles_Fact_ComprasTableAdapter adapter = new Detalles_Fact_ComprasTableAdapter();
            SqlTransaction transaction = null;
            ObtenerDetallesFactComprasResponses respuesta = new ObtenerDetallesFactComprasResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                Detalles_Fact_ComprasDataTable datos= adapter.sp_Select_Detalles_Fact_Compras_ByIDFactura_Get(id_factura);
                respuesta.detalles_compra = new List<Detalles_Fact_Compras>();
                foreach (var detalles in datos)
                {
                    ObtenerProductosByIDResponses prod = ObtenerProductosByID(detalles.id_producto); 
                    Detalles_Fact_Compras compra = new Detalles_Fact_Compras()
                    {
                         id_det_fact = detalles.id_det_fact,
                         factura = new Factura() { id_factura = detalles.id_factura},
                         cant_producto = detalles.cant_producto,
                         precio_unitario = detalles.precio_unitario,
                         descuento = detalles.descuento,
                         producto = prod.Producto
                    };
                    respuesta.detalles_compra.Add(compra);
                }
                transaction.Commit();
                respuesta.estado = true;
            }
            catch (Exception)
            {
                respuesta.estado = false;
                transaction.Rollback();
            }
            return respuesta;
        }

        [WebMethod]
        public ObtenerDetallesFactReparacionResponses ObtenerDetallesFacturaReparacion(int id_factura)
        {
            Detalles_Fact_ReparacionesTableAdapter adapter = new Detalles_Fact_ReparacionesTableAdapter();
            SqlTransaction transaction = null;
            ObtenerDetallesFactReparacionResponses respuesta = new ObtenerDetallesFactReparacionResponses();
            try
            {
                adapter.Connection.Open();
                transaction = adapter.Connection.BeginTransaction();
                adapter.Transaction = transaction;
                Detalles_Fact_ReparacionesDataTable datos = adapter.sp_Select_Detalles_Reparaciones_Compras_ByIDFactura_Get(id_factura);
                respuesta.detalles_reparaciones = new List<Detalles_Fact_Reparaciones>();
                foreach (var detalles in datos)
                {
                    Detalles_Fact_Reparaciones compra = new Detalles_Fact_Reparaciones()
                    {
                        id_det_fact = detalles.id_det_fact,
                        factura = new Factura() { id_factura = detalles.id_factura },
                        nombre_producto = detalles.nombre_producto,
                        categoria_producto = new Categoria_Producto() { id_categoria = detalles.id_categoria_producto},
                        descripcion_problema = detalles.descripcion_problema,
                        descripcion_producto = detalles.descripcion_producto,
                        valor_reparacion = detalles.valor_reparacion,
                        fecha_entrega = detalles.fecha_entrega,
                        estado = new Estados() { id_estado = detalles.id_estado}
                    };
                    respuesta.detalles_reparaciones.Add(compra);
                }
                transaction.Commit();
                respuesta.estado = true;
            }
            catch (Exception)
            {
                respuesta.estado = false;
                transaction.Rollback();
            }
            return respuesta;
        }

       
        //HACER EL INSERT DE TRANS TARJETA CON LA FACTURA



        ///CREAR FUNCION QUE TE RETORNE EL NUMERO DE PERSONAS ACTIVAS
        ///CREAR METODO PARA OBTENER LOS PRODUCTOS POR CATEGORIA







    }
}
