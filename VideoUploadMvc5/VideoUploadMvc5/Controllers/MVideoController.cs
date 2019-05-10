using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoUploadMvc5.Models;

namespace VideoUploadMvc5.Controllers
{
    public class MVideoController : Controller
    {
      
        // GET: MVideo
        public ActionResult Index()
        {
            ApplicationDbContext entities = new ApplicationDbContext();
            return View(entities.tblFiles.Where(p => p.ContentType == "video/mp4").ToList());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            ApplicationDbContext entities = new ApplicationDbContext();
            entities.tblFiles.Add(new tblFile
            {
                Name = Path.GetFileName(postedFile.FileName),
                ContentType = postedFile.ContentType,
                Data = bytes
            });
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public FileResult DownloadFile(int? fileId)
        {
            ApplicationDbContext entities = new ApplicationDbContext();
            tblFile file = entities.tblFiles.ToList().Find(p => p.id == fileId.Value);
            return File(file.Data, file.ContentType, file.Name);
        }
    }
}