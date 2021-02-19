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
                               FechaPublicacion = DateTime.Parse(datos.Element("FECHAPUBLICACION").Value)
                           };
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
                               FechaPublicacion = DateTime.Parse(datos.Element("FECHAPUBLICACION").Value)
                           };
            return consulta.ToList();
        }
    }
}
