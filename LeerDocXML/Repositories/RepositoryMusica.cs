using LeerDocXML.Helpers;
using LeerDocXML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeerDocXML.Repositories
{
    public class RepositoryMusica : IRepositoryMusica
    {
        private XDocument docxml;
        PathProvider pathProvider;
        private String path;

        public RepositoryMusica(PathProvider pathProvider)
        {
            this.pathProvider = pathProvider;
            this.path = this.pathProvider.MapPath("musica.xml", Folders.Documents);
            this.docxml = XDocument.Load(path);
        }

        public Album GetAlbum(int idAlbum)
        {
            var consulta = from datos in this.docxml.Descendants("ALBUM")
                           where datos.Attribute("ID").Value == idAlbum.ToString()
                           select new Album
                           {
                               Id = int.Parse(datos.Attribute("ID").Value),
                               Titulo = datos.Element("TITULO").Value,
                               Autor = datos.Element("AUTOR").Value,
                               FechaPublicacion = datos.Element("FECHAPUBLICACION").Value
                           };
            return consulta.FirstOrDefault();
        }


        private XElement GetXElement(int id)
        {
            var consulta = from datos in this.docxml.Descendants("ALBUM")
                           where datos.Attribute("ID").Value == id.ToString()
                           select datos;
            return consulta.FirstOrDefault();
        }


        public List<Album> GetAlbumes()
        {
            var consulta = from datos in this.docxml.Descendants("ALBUM")
                           select new Album
                           {
                               Id = int.Parse(datos.Attribute("ID").Value),
                               Titulo = datos.Element("TITULO").Value,
                               Autor = datos.Element("AUTOR").Value,
                               FechaPublicacion = datos.Element("FECHAPUBLICACION").Value
                           };
            return consulta.ToList();
        }

        public void InsertarAlbum(int id, string titulo, string autor, string fechaPublicacion)
        {
            XElement xelem = new XElement("ALBUM");
            xelem.SetAttributeValue("ID", id);
            xelem.Add(new XElement("TITULO", titulo));
            xelem.Add(new XElement("AUTOR", autor));
            xelem.Add(new XElement("FECHAPUBLICACION", fechaPublicacion));
            this.docxml.Element("ALBUMES").Add(xelem);
            this.docxml.Save(this.path);
        }

        public void EliminarAbum(int id)
        {
            XElement xElement = this.GetXElement(id);
            xElement.Remove();
            this.docxml.Save(this.path);
        }

        public void UpdateAlbum(int id, string titulo, string autor, string fechaPublicacion)
        {
            XElement xElement = this.GetXElement(id);
            xElement.Element("TITULO").Value = titulo;
            xElement.Element("AUTOR").Value = autor;
            xElement.Element("FECHAPUBLICACION").Value = fechaPublicacion;
            this.docxml.Save(this.path);
        }
    }
}
