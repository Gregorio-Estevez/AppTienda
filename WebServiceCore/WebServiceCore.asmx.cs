using LibreriaClasesBD;
using LibreriaRequest_ResponseCaja;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServiceCore.DataSetBaseDeDatosTableAdapters;
using static WebServiceCore.DataSetBaseDeDatos;

namespace WebServiceCore
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
        public bool RegistrarMetPago(Met_Pago request)
        {
            Met_PagoTableAdapter met_pago = new Met_PagoTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                met_pago.Connection.Open();
                transaction = met_pago.Connection.BeginTransaction();
                met_pago.Transaction = transaction;
                met_pago.sp_Insert_Met_Pago(request.descripcion,request.activo);
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
        public bool ModificarMetPago(Met_Pago request)
        {
            Met_PagoTableAdapter met_pago = new Met_PagoTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                met_pago.Connection.Open();
                transaction = met_pago.Connection.BeginTransaction();
                met_pago.Transaction = transaction;
                met_pago.sp_Update_Met_Pago(request.id_metpago,request.descripcion,request.activo);
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
                Met_PagoDataTable datos = adapter.sp_SelectAll_Met_Pago_Get();
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

        [WebMethod]
        public bool RegistrarEstado(Estado request)
        {
            EstadoTableAdapter estado = new EstadoTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                estado.Connection.Open();
                transaction = estado.Connection.BeginTransaction();
                estado.Transaction = transaction;
                estado.sp_Insert_Estado(request.descripcion,request.nombre_estado,request.activo);
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
        public bool ModificarEstado(Estado request)
        {
            EstadoTableAdapter estado = new EstadoTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                estado.Connection.Open();
                transaction = estado.Connection.BeginTransaction();
                estado.Transaction = transaction;
                estado.sp_Update_Estado(request.id_estado,request.descripcion,request.activo,request.nombre_estado);
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
                EstadoDataTable datos = adapter.sp_SelectAll_Estado_Get();
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
                tipocompra.sp_Insert_Tipo_Compra(request.descripcion,request.activo);
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
                Tipo_CompraDataTable datos = adapter.sp_SelectAll_Tipo_Compra_Get();
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
        public bool RegistrarServicios(Servicio request)
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
        public bool ModificarServicio(Servicio request)
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
        public ObtenerServiciosResponses ObtenerServicios(bool soloactivos)
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
                Categoria_EmpleadosDataTable datos = adapter.sp_SelectAll_Categoria_Empleado_Get();
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
                Categoria_ProductoDataTable datos = adapter.sp_SelectAll_Categoria_Producto_Get();
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
                adapter.sp_Insert_Sucursales(request.nombre_sucursal,request.direccion_sucursal,request.activo);
                transaction.Commit();
                respuesta = true ;
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
                adapter.sp_Update_Sucursal(request.id_sucursal,request.nombre_sucursal, request.direccion_sucursal, request.activo);
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
                SucursalesDataTable datos = adapter.sp_SelectAll_Sucursal_Get();
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
        public bool RegistrarCategoriaProducto(LibreriaClasesBD.Categoria_Producto request)
        {
            Categoria_ProductoTableAdapter cat_producto = new Categoria_ProductoTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                cat_producto.Connection.Open();
                transaction = cat_producto.Connection.BeginTransaction();
                cat_producto.Transaction = transaction;
                cat_producto.sp_Insert_Categoria_Producto(request.descripcion, request.activo,request.nombre_categoria);
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
        public bool ModificarCategoriaProducto(LibreriaClasesBD.Categoria_Producto request)
        {
            Categoria_ProductoTableAdapter cat_producto = new Categoria_ProductoTableAdapter();
            bool respuesta;
            SqlTransaction transaction = null;
            try
            {
                cat_producto.Connection.Open();
                transaction = cat_producto.Connection.BeginTransaction();
                cat_producto.Transaction = transaction;
                cat_producto.sp_Update_Categoria_Producto(request.id_categoria,request.descripcion,request.nombre_categoria,request.activo);
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
                    adapter.sp_Insert_Empleados(request.nombre, request.apellido, request.Categoria_Empleados.id_categoria, request.email, request.cedula, request.salario, request.fecha_nac, request.direccion, request.num_telefono, request.Estado.id_estado, request.Sucursale.id_sucursal,request.ruta_foto);
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
                if ((bool)funcion.Verificar_Cedula_Empleado_Sea_de_El(request.cedula,request.id_empleado))
                {
                    respuesta.cedulanovalida = false;
                    adapter.sp_Update_Empleados(request.id_empleado,request.nombre, request.apellido, request.Categoria_Empleados.id_categoria, request.email, request.cedula, request.salario, request.fecha_nac, request.direccion, request.num_telefono, request.Estado.id_estado, request.Sucursale.id_sucursal,request.ruta_foto);
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

        public ObtenerEmpleadoPorIDResponses ObtenerEmpleadoPorIDResponses(int id_empleado)
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
        public ObtenerVentasResponses ObtenerVentasDeLaSucursal(ObtenerVentasRequest request)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BaseDatosProvicionalConnectionString"].ConnectionString);
            SqlCommand comando = new SqlCommand("sp_SelectAll_Factura_Sucursal2",connection);
            SqlTransaction transaction = null;
            ObtenerVentasResponses respuesta = new ObtenerVentasResponses();
            sp_SelectAll_Factura_Sucursal2DataTable  result = new sp_SelectAll_Factura_Sucursal2DataTable();
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                comando.Parameters.AddWithValue("@id_sucursal", request.sucursal.id_sucursal);
                SqlDataReader dr = comando.ExecuteReader();
                transaction.Commit();
                while (dr.Read())
                {
                    LibreriaClasesBD.Factura factura = new LibreriaClasesBD.Factura();
                    factura.id_factura = int.Parse(dr["id_factura"].ToString());
                    factura.metpago.id_metpago = int.Parse(dr["id_metpago"].ToString());
                    factura.metpago.descripcion = dr["Descripcion_Met_Pago"].ToString();
                    factura.empleado.id_empleado = int.Parse(dr["id_empleado"].ToString());
                    factura.empleado.nombre = dr["Nombre_Empleado"].ToString();
                    factura.empleado.apellido = dr["Apellido_Empleado"].ToString();
                    factura.subtotal_servicio = decimal.Parse(dr["subtotal_servicio"].ToString());
                    factura.tipo_compra.id_tipo_compra = int.Parse(dr["id_tipo_compra"].ToString());
                    factura.tipo_compra.descripcion = dr["Descripcion_Tipo_Compra"].ToString();
                    factura.impuestos = decimal.Parse(dr["impuestos"].ToString());
                    factura.total_descuento = decimal.Parse(dr["total_descuento"].ToString());
                    factura.monto_total = decimal.Parse(dr["monto_total"].ToString());
                    factura.ncf = dr["ncf"].ToString();
                    factura.vencimiento_fact = DateTime.Parse(dr["vencimiento_fact"].ToString());
                    factura.nombre_cliente = dr["Nombre_Cliente_F"].ToString();
                    factura.cliente.id_cliente = int.Parse(dr["Nombre_Cliente"].ToString());
                    factura.cliente.nombre = dr["Apellido_Cliente"].ToString();
                    factura.cliente.direccion = dr["Direc_Cliente"].ToString();
                    factura.cliente.num_telefono = dr["Num_Tel_Cliente"].ToString();
                    factura.entrega_domicilio = int.Parse(dr["entrega_domicilio"].ToString()) == 1 ? true:false;
                    factura.sucursal.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                    factura.sucursal.nombre_sucursal = dr["nombre_sucursal"].ToString();
                    factura.sucursal.direccion_sucursal = dr["direccion_sucursal"].ToString();
                    respuesta.facturas.Add(factura);
                }
                respuesta.estado = 1;
                transaction.Commit();
            }
            catch (Exception)
            {
                respuesta.estado = 0;
                transaction.Rollback();
            }
            return respuesta;
        }

       /* [WebMethod]
        public ObtenerComprasProveedoresResponse ObtenerVentasDeLaSucursal(ObtenerComprasProveedoresRequest request)
        {
            Compras_ProveedoresTableAdapter compras = new Compras_ProveedoresTableAdapter();
            ProveedoresTableAdapter proveedor = new ProveedoresTableAdapter();
            ObtenerComprasProveedoresResponse respuesta = new ObtenerComprasProveedoresResponse();
            try
            {
                Compras_ProveedoresDataTable datos = compras.sp_SelectAll_Compras_Proveedores_PorSucursal_Get(request.sucursal.id_sucursal);
               foreach (var consult in datos) 
                {
                    LibreriaClasesBD.Compras_Proveedores compra = new LibreriaClasesBD.Compras_Proveedores();
                    compra.id_compra = consult.id_compra;
                    compra.cod_envio = consult.cod_envio;
                    compra.descripcion = consult.descripcion;
                    compra.fecha_llegada = consult.fecha_llegada;
                    
                }
                respuesta.estado = 1;
                transaction.Commit();
            }
            catch (Exception)
            {
                respuesta.estado = 0;
                transaction.Rollback();
            }
            return respuesta;
        }*/
    }
}
