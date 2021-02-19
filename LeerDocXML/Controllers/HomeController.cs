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

        //hacer metodo details y config startup
    }
}
