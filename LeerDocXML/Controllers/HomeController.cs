using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeerDocXML.Models;
using LeerDocXML.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LeerDocXML.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryMusica repo;
        public HomeController(IRepositoryMusica repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Album> albumes = this.repo.GetAlbumes();
            return View(albumes);
        }

        public IActionResult Details(int idalbum)
        {
            Album album = this.repo.GetAlbum(idalbum);
            return View(album);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id, String titulo, String autor, String fechaPublicacion)
        {
            this.repo.InsertarAlbum(id, titulo, autor, fechaPublicacion);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int idAlbum)
        {
            this.repo.EliminarAbum(idAlbum);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int idAlbum)
        {
            Album album = this.repo.GetAlbum(idAlbum);
            return View(album);
        }

        [HttpPost]
        public IActionResult Edit(int idAlbum, String titulo, String autor, String fechaPublicacion)
        {
            this.repo.UpdateAlbum(idAlbum, titulo, autor, fechaPublicacion);
            return RedirectToAction("Index");
        }
    }
}
