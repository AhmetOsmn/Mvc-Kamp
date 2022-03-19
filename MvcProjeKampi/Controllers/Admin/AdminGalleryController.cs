using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjem.Controllers
{
    public class AdminGalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());

        public ActionResult Index()
        {
            var images = imageFileManager.GetImageList();
            return View(images);
        }
    }
}