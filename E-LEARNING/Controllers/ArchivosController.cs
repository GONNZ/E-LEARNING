using E_LEARNING.Models;
using IdentitySample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LEARNING.Controllers
{
    public class ArchivosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Archivos
    
        [HttpPost]
        public ActionResult SubirArchivo(HttpPostedFileBase file, string tipo,int lec)
        {
            if (file != null && file.ContentLength > 0)
            {
                // Extraemos el contenido en Bytes del archivo subido.
                var _contenido = new byte[file.ContentLength];
                file.InputStream.Read(_contenido, 0, file.ContentLength);

                //Leccion del archivo

                Lecciones leccion = db.Lecciones.Find(lec);


                // Separamos el Nombre del archivo de la Extensión.
                int indiceDelUltimoPunto = file.FileName.LastIndexOf('.');
                string _nombre = file.FileName.Substring(0, indiceDelUltimoPunto);
                string _extension = file.FileName.Substring(indiceDelUltimoPunto + 1,
                                    file.FileName.Length - indiceDelUltimoPunto - 1);

                // Instanciamos la clase Archivo y asignammos los valores.
                Archivo _archivo = new Archivo()
                {
                    Nombre = _nombre,
                    Extension = _extension,
                    Tipo = tipo,
                    lecciones = leccion
                };

                try
                {
                    // Subimos el archivo al Servidor.
                    _archivo.SubirArchivo(_contenido);
                    // Guardamos en la base de datos la instancia del archivo
                   
                        db.Archivos.Add(_archivo);
                        db.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Aquí el código para manejar la Excepción.
                }
            }

            // Redirigimos a la Acción 'Index' para mostrar
            // Los archivos subidos al Servidor.
            return RedirectToAction("Details","Lecciones", new { id = lec});
        }

        [HttpGet]
        public ActionResult DescargarArchivo(Guid id)
        {
            Archivo _archivo;
            FileContentResult _fileContent;

          
            _archivo = db.Archivos.FirstOrDefault(x => x.Id == id);
            

            if (_archivo == null)
            {
                return HttpNotFound();
            }
            else
            {
                try
                {
                     
                    _fileContent = new FileContentResult(_archivo.DescargarArchivo(),
                                                         "application/octet-stream");


                    _fileContent.FileDownloadName = _archivo.Nombre + "." + _archivo.Extension;                 

                    return File(_archivo.PathCompleto, "application/octet-stream","Descarga." + _archivo.Extension);
                }
                catch (Exception ex)
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpGet]
        public ActionResult EliminarArchivo(Guid id, int leccion)
        {
            Archivo _archivo;

                _archivo = db.Archivos.FirstOrDefault(x => x.Id == id);
           

            if (_archivo != null)
            {
                
                    _archivo = db.Archivos.FirstOrDefault(x => x.Id == id);
                    db.Archivos.Remove(_archivo);
                    if (db.SaveChanges() > 0)
                    {
                        // Eliminamos el archivo del Servidor.
                        _archivo.EliminarArchivo();
                    }
                
                // Redirigimos a la Acción 'Index' para mostrar
                // Los archivos subidos al Servidor.
                return RedirectToAction("Details", "Lecciones",new { id=leccion});
            }
            else
            {
                return HttpNotFound();
            }
        }

    }
}
