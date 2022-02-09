using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Service.Adjunto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KaphiyQuipu.Service
{
    public class GeneralService : IGeneralService
    {
        private IGeneralRepository _generalRepository;
        public IOptions<FileServerSettings> _fileServerSettings;

        public GeneralService(IGeneralRepository generalRepository, IOptions<FileServerSettings> fileServerSettings)
        {
            _generalRepository = generalRepository;
            _fileServerSettings = fileServerSettings;
        }

        public List<ConsultarDocumentoPagoDTO> ConsultarDocumentoPago(ConsultarDocumentoPagoRequestDTO request)
        {
            List<ConsultarDocumentoPagoDTO> response = new List<ConsultarDocumentoPagoDTO>();
            var lista = _generalRepository.ConsultarDocumentoPago(request.CorrelativoDPA, request.CorrelativoCC, request.Id);
            if (lista.Any())
            {
                response = lista.ToList();
            }
            return response;
        }

        public ConsultarDocumentoPagoPorIdDTO ConsultarDocumentoPagoPorId(ConsultarDocumentoPagoPorIdRequestDTO request)
        {
            ConsultarDocumentoPagoPorIdDTO response = new ConsultarDocumentoPagoPorIdDTO();
            var lista = _generalRepository.ConsultarDocumentoPagoPorId(request.Id);
            if (lista.Any())
            {
                response = lista.FirstOrDefault();
            }
            return response;
        }

        public void GuardarVoucher(GuardarVoucherRequestDTO request, IFormFile file)
        {
            request.Fecha = DateTime.Now;
            var AdjuntoBl = new AdjuntarArchivosBL(_fileServerSettings);
            byte[] fileBytes = null;
            if (file != null)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);
                    }

                    request.Archivo = file.FileName;
                    ResponseAdjuntarArchivoDTO response = AdjuntoBl.AgregarArchivo(new RequestAdjuntarArchivosDTO
                    {
                        filtros = new AdjuntarArchivosDTO
                        {
                            archivoStream = fileBytes,
                            filename = file.FileName,
                        },
                        pathFile = _fileServerSettings.Value.DocumentoPagoAcopio
                    });
                    request.Ruta = string.Format(@"{0}\{1}", _fileServerSettings.Value.DocumentoPagoAcopio, response.ficheroReal);
                }
            }

            _generalRepository.GuardarVoucher(request);
        }

        public void ConfirmarVoucherPago(ConfirmarVoucherPagoRequestDTO request)
        {
            request.Fecha = DateTime.Now;
            _generalRepository.ConfirmarVoucherPago(request.Id, request.Usuario, request.Fecha);
        }
    }
}
