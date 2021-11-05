
using AutoMapper;
using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Models;
using KaphiyQuipu.Service.Adjunto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace KaphiyQuipu.Service
{
    public partial class AduanaDocumentoAdjuntoService : IAduanaDocumentoAdjuntoService
    {
        private readonly IMapper _Mapper;


        private IAduanaDocumentoAdjuntoRepository _IAduanaDocumentoAdjuntoRepository;


        public IOptions<FileServerSettings> _fileServerSettings;

        public AduanaDocumentoAdjuntoService(IAduanaDocumentoAdjuntoRepository AduanaDocumentoAdjuntoRepository, IMapper mapper, IOptions<FileServerSettings> fileServerSettings)
        {
            _IAduanaDocumentoAdjuntoRepository = AduanaDocumentoAdjuntoRepository;
            _fileServerSettings = fileServerSettings;
            _Mapper = mapper;



        }
        private String getRutaFisica(string pathFile)
        {
            return _fileServerSettings.Value.RutaPrincipal + pathFile;
        }


        public ResponseDescargarArchivoDTO DescargarArchivo(RequestDescargarArchivoDTO request)
        {
            try
            {
                String rutaReal = Path.Combine(getRutaFisica(request.PathFile));

                if (File.Exists(rutaReal))
                {

                    Byte[] archivoBytes = System.IO.File.ReadAllBytes(rutaReal);
                    return new ResponseDescargarArchivoDTO()
                    {
                        archivoBytes = archivoBytes,
                        errores = new Dictionary<string, string>(),
                        ficheroVisual = request.ArchivoVisual
                    };
                }
                else
                {
                    var resp = new ResponseDescargarArchivoDTO()
                    {
                        archivoBytes = null,
                        errores = new Dictionary<string, string>(),
                        ficheroVisual = ""
                    };
                    resp.errores.Add("Error", "El Archivo solicitado no existe");
                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

    }
}
