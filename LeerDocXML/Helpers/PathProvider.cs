using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LeerDocXML.Helpers
{
    public enum Folders
    {
        Documents = 0
    }
    public class PathProvider
    {
        IWebHostEnvironment environment;
        public PathProvider(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public String MapPath(String filename, Folders folder)
        {
            String carpeta = ""; 
            if (folder == Folders.Documents)
            {
                carpeta = "Documents";
            }
            String path = Path.Combine(this.environment.WebRootPath
                , carpeta, filename);
            return path;
        }
    }
}
