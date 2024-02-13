using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication3.Models;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;


namespace WebApplication3.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/personas")]

    public class PruebasController : ApiController
    {
       PruebasEntities db = new PruebasEntities();

        /////////////////////////Mostrar Usuarios//////////////////////////////
        [HttpGet]
        [Route("listado-personas")]
        public List<Pruebas_FN_TodosEmpleados_Result> GetEmpleados()
        {
            return db.Pruebas_FN_TodosEmpleados().ToList();
        }

        /////////////////////////Detalle del Usuario//////////////////////////////
        [HttpGet]
        [Route("detalle-usuario/{Id}")]
        public IQueryable<Pruebas_SoloUnEmpleado_Result> GetEmpleado(int Id)
        {
            return db.Pruebas_SoloUnEmpleado(Id);
        }

        /////////////////////////Mostrar Puestos//////////////////////////////
        [HttpGet]
        [Route("puestos")]
        public List<Pruebas_TraerPuestos_Result> GetPuestos()
        {
            return db.Pruebas_TraerPuestos().ToList();
        }

        /////////////////////////Mostrar foto de usuario//////////////////////////////
        [HttpGet]
        [Route("imagen/{Id}")]
        public HttpResponseMessage ConvertByteToImage(int Id)
        {
            Respuesta r = new Respuesta();
            try
            {
                var extension = db.Pruebas_FN_ImagenUnEmpleado(Id).Select(a => a.Extension).FirstOrDefault();
                
                byte[] dd = db.Pruebas_FN_ImagenUnEmpleado(Id).Select(e => e.FotografiaEmpleado).FirstOrDefault();
                if (dd == null)
                {
                    r.status = true;
                    r.message = null;
                }
                else
                {
                    var imreBase64Data = Convert.ToBase64String(dd);
                    string imgDataUrl = string.Format("data:" + extension+ ";base64,{0}", imreBase64Data);
                    r.status = true;
                    r.message = imgDataUrl;
                }
                
                return Request.CreateResponse(HttpStatusCode.OK, r);
            }
            catch
            {
                r.status = false;
                r.message = "Hubo un problema, por favor hablar con sistemas.";
                return Request.CreateResponse(HttpStatusCode.InternalServerError, r);
            } 
        }

        /////////////////////////Mostrar horas de usuario//////////////////////////////
        [HttpGet]
        [Route("horas/{Id}")]
        public List<Object> GetCotrolHoras(int Id)
        {
            List<Pruebas_FN_ControlHoras_Result> horas = new List<Pruebas_FN_ControlHoras_Result>();
            horas = db.Pruebas_FN_ControlHoras(Id).ToList();
            List<Object> list = new List<Object>();

            horas.ToList().ForEach(i =>
            {
                list.Add(new
                {
                    Id = i.Id,
                    RefIdEmpleado = i.RefIdEmpleado,
                    HoraEntrada = extraerHora(i.HoraEntrada),
                    HoraSalida = extraerHora((TimeSpan)i.HoraSalida),
                    Fecha = i.Fecha,
                });
            });

            return list;
        }

        public static string extraerHora(TimeSpan extraerFormatoHora)
        {

            var hora = extraerFormatoHora.Hours;
            var minutos = extraerFormatoHora.Minutes;
            var segundos = extraerFormatoHora.Seconds;
            var HoraConcatenada = $"{hora:D2}:{minutos:D2}:{segundos:D2}";

            return HoraConcatenada;
        }

        ////Arreglar para que funcione enviar la foto >:v
        //[HttpPut]
        //[Route("editar-usuario")]
        //public async Task<HttpResponseMessage> PostFormData()
        //{
        //    // Check if the request contains multipart/form-data.
        //    if (!Request.Content.IsMimeMultipartContent())
        //    {
        //        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //    }

        //    string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");
        //    var provider = new MultipartFormDataStreamProvider(root);

        //    try
        //    {
        //        if (provider.Contents == null)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound);
        //        }
        //        else
        //        {
        //        await Request.Content.ReadAsMultipartAsync(provider);

        //        byte[] data = null;
        //        // This illustrates how to get the file names.
        //        foreach (MultipartFileData file in provider.FileData)
        //        {
        //            Trace.WriteLine(file.Headers.ContentDisposition.FileName);//get FileName
        //            Trace.WriteLine("Server file path: " + file.LocalFileName);//get File Path

        //            using (FileStream fs = File.OpenRead(file.LocalFileName))
        //            {
        //                data = new byte[fs.Length];
        //                fs.Read(data, 0, data.Length);
        //            }

        //        }
        //            return Request.CreateResponse(HttpStatusCode.OK, provider.Contents);

        //        }
        //        // Read the form data.
        //    }
        //    catch (System.Exception e)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
        //    }
        //}


        /////////////////////////Editar Usuario y su foto//////////////////////////////
        [HttpPut]
        [Route("editar-usuario/{Id}")]

        public async Task<HttpResponseMessage> PutUsuario(int Id, string NombreEmpleado = "", int EdadEmpleado = 0, string SexoEmpleado = "", int IdPuesto = 0, string extension = "")
        { 
            Respuesta r = new Respuesta();
            try
            {
                
                if (Request.Content.IsMimeMultipartContent() && !Request.Content.IsMimeMultipartContent() || !Request.Content.IsMimeMultipartContent() == null)
                {
                    r.status = false;
                    r.message = "Falta la imagen o se envío un formato incorrecto.";
                    return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
                }
                else
                {
                    
                    var nombreMayuscula = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NombreEmpleado);
                    var empleado = (from d in db.Pruebas_EMP where d.Id == Id select d).FirstOrDefault();
                    var nombre = nombreMayuscula != "" ? nombreMayuscula : empleado.NombreEmpleado.ToString();
                    var edad = EdadEmpleado != 0 ? EdadEmpleado : empleado.EdadEmpleado;
                    var sexo = SexoEmpleado != "" ? SexoEmpleado : empleado.SexoEmpleado.ToString();
                    var idpuesto = IdPuesto != 0 ? IdPuesto : empleado.IdPuesto;

                    try
                    {
                        if (Request.Content.Headers.ContentType == null)
                        {
                            db.Pruebas_EditarEmpleado(Id, nombre, edad, sexo, idpuesto, null, null);
                            r.status = true;
                            r.message = "Usuario actualizado exitosamente.";
                        }
                        else
                        {
                            // Read the form data.
                            string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");
                            var provider = new MultipartFormDataStreamProvider(root);
                            byte[] data = null;
                            await Request.Content.ReadAsMultipartAsync(provider);
                            // This illustrates how to get the file names.
                            foreach (MultipartFileData file in provider.FileData)
                            {
                                Trace.WriteLine(file.Headers.ContentDisposition.FileName);//get FileName
                                Trace.WriteLine("Server file path: " + file.LocalFileName);//get File Path
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    using (FileStream fs = File.OpenRead(file.LocalFileName))
                                    {
                                        await fs.CopyToAsync(ms);
                                    }
                                    data = ms.ToArray();
                                }
                            }
                            db.Pruebas_EditarEmpleado(Id, nombre, edad, sexo, idpuesto, data, extension);
                            r.status = true;
                            r.message = "Usuario actualizado exitosamente.";
                        }
                        return Request.CreateResponse(HttpStatusCode.OK, r);
                        
                    }
                    catch (Exception e)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
                    }
                }
            }
            catch (Exception ex)
            {
                r.status = false;
                r.message = "Hubo un problema, por favor hablar con sistemas.";
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        } 

        /////////////////////////Crear Usuario//////////////////////////////
        [HttpPost]
        [Route("crear-usuario")]
        public HttpResponseMessage PostUsuario(string NombreEmpleado, int EdadEmpleado, string SexoEmpleado, int IdPuesto)
        {
            try
            {
                var nombre = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(NombreEmpleado);
                var existe = (from d in db.Pruebas_EMP where d.NombreEmpleado == nombre select d).Count();
                if (existe == 0)
                {
                    db.Pruebas_CrearEmpleado(nombre, EdadEmpleado, SexoEmpleado, IdPuesto, null);
                    return Request.CreateResponse(HttpStatusCode.OK,"Usuario creado exitosamente.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Usuario ya existe.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Hubo un problema, por favor hablar con sistemas.");
            }
        }

/////////////////////////Elimnar Usuario//////////////////////////////
        [HttpDelete]
        [Route("eliminar-usuario/{Id}")]
        public HttpResponseMessage DeleteUsuario(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                var pruebas_SoloUnEmpleado_Result = db.Pruebas_SoloUnEmpleado(Id);
                if (pruebas_SoloUnEmpleado_Result == null)
                {
                     return Request.CreateResponse(HttpStatusCode.NotFound, "No existe ningun usuario.");
                }
                else
                {
                    db.Pruebas_EliminarEmpleado(Id);
                    return Request.CreateResponse(HttpStatusCode.OK, "Usuario eliminado.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Hubo un problema, por favor hablar con sistemas.");
            }
        }
        /////////////////////////Clase donde se guarda el status y el message de respuesta//////////////////////////////
        public class Respuesta
        {
            public bool status { get; set; }
            public string message { get; set; }
        }

    }
}
