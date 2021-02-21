using LeerDocXML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeerDocXML.Repositories
{
    public interface IRepositoryMusica
    {
        List<Album> GetAlbumes();
        Album GetAlbum(int idAlbum);
        void InsertarAlbum(int id, String titulo, String autor, String fechaPublicacion);
        void EliminarAbum(int id);
        void UpdateAlbum(int id, String titulo, String autor, String fechaPublicacion);
    }
}
