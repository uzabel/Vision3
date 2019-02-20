using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Patagames.Pdf.Net;

namespace Vision3
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([BlobTrigger("test/{name}", Connection = "")]Stream myBlob, string name, TraceWriter log)
        {
            log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
                           //Initialize the SDK library
                //You have to call this function before you can call any PDF processing functions.
                //PdfCommon.Initialize(specificPath: "C:\\Users\\UweZabel\\source\\repos\\Vision3\\Vision3\\bin\\Debug\\net461\\");
                PdfCommon.Initialize();
            //Open and load a PDF document from a file.
            using (var doc = PdfDocument.Load(myBlob)) // C# Read PDF File
                {
                    //Enumerate all pages sequentially in a given document
                    foreach (var page in doc.Pages)
                    {
                    //Extract and save images
                    //ExtractImagesFromPage(page);
                    log.Info($"page:");
                        //dipose page object to unload it from memory
                        page.Dispose();
                    }
                }
            }
    }
}
