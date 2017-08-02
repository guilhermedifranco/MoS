using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Web.Utils
{
    public class ImageResult : ActionResult
    {
        public string ContentType { get; set; }
        public byte[] ImageBytes { get; set; }
        public string SourceFilename { get; set; }

        public ImageResult(string sourceFilename, string contentType)
        {
            SourceFilename = sourceFilename;
            ContentType = contentType;
        }

        public ImageResult(byte[] sourceStream, string contentType)
        {
            ImageBytes = sourceStream;
            ContentType = contentType;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.Clear();
            response.Cache.SetCacheability(HttpCacheability.NoCache);
            response.ContentType = ContentType;

            if (ImageBytes != null)
            {
                var stream = new MemoryStream(ImageBytes);
                stream.WriteTo(response.OutputStream);
                stream.Dispose();
            }
        }
    }
}