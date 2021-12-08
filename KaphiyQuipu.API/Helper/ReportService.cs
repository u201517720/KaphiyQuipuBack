using AspNetCore.Reporting;
using AspNetCore.Reporting.ReportExecutionService;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaphiyQuipu.API.Helper
{
    public class ReportService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReportService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public byte[] Procesar(string reportName, Dictionary<string, string> parameters, List<(string, List<object>)> datasets)
        {
            string mimeType = "";
            int extension = 1;
            string path = $@"{this._webHostEnvironment.ContentRootPath}\Reports\{reportName}.rdlc";
            LocalReport localReport = new LocalReport(path);

            if (parameters is null)
                parameters = new Dictionary<string, string>();

            if (datasets != null) 
            {
                datasets.ForEach(x =>
                {
                    localReport.AddDataSource(x.Item1, x.Item2);
                });
            }
            
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimeType);

            return result.MainStream;
        }
    }
}
