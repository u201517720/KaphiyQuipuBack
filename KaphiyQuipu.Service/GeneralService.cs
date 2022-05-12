using KaphiyQuipu.DTO;
using KaphiyQuipu.DTO.Adjunto;
using KaphiyQuipu.Interface.Repository;
using KaphiyQuipu.Interface.Service;
using KaphiyQuipu.Service.Adjunto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace KaphiyQuipu.Service
{
    public class GeneralService : IGeneralService
    {
        private IGeneralRepository _generalRepository;
        private ICorrelativoRepository _ICorrelativoRepository;
        private IUsersRepository _IIUsersRepository;
        public IOptions<FileServerSettings> _fileServerSettings;

        public GeneralService(IGeneralRepository generalRepository, ICorrelativoRepository correlativoRepository, IUsersRepository userRepository, IOptions<FileServerSettings> fileServerSettings)
        {
            _generalRepository = generalRepository;
            _fileServerSettings = fileServerSettings;
            _ICorrelativoRepository = correlativoRepository;
            _IIUsersRepository = userRepository;
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

        public void GenerarPagoPendientePlanta(GenerarPagoPendientePlantaRequestDTO request)
        {
            request.Fecha = DateTime.Now;
            request.Correlativo = _ICorrelativoRepository.Obtener(null, Documentos.DocumentoPagoPlanta);
            _generalRepository.GenerarPagoPendientePlanta(request.Id, request.Correlativo, request.Usuario, request.Fecha);
        }

        public List<ConsultarDocumentoPagoPlantaDTO> ConsultarDocumentoPagoPlanta(ConsultarDocumentoPagoPlantaRequestDTO request)
        {
            List<ConsultarDocumentoPagoPlantaDTO> response = new List<ConsultarDocumentoPagoPlantaDTO>();
            var lista = _generalRepository.ConsultarDocumentoPagoPlanta(request.Documento);
            if (lista.Any())
            {
                response = lista.ToList();
            }
            return response;
        }

        public ConsultarDocumentoPagoPlantaPorIdDTO ConsultarDocumentoPagoPlantaPorId(ConsultarDocumentoPagoPlantaPorIdRequestDTO request)
        {
            ConsultarDocumentoPagoPlantaPorIdDTO response = new ConsultarDocumentoPagoPlantaPorIdDTO();
            var lista = _generalRepository.ConsultarDocumentoPagoPlantaPorId(request.Id);
            if (lista.Any())
            {
                response = lista.FirstOrDefault();
            }
            return response;
        }

        public void AprobarDepositoPlanta(AprobarDepositoPlantaRequestDTO request)
        {
            request.Fecha = DateTime.Now;
            _generalRepository.AprobarDepositoPlanta(request.Id, request.Usuario, request.Fecha);
        }

        public void GuardarVoucherPlanta(GuardarVoucherPlantaRequestDTO request, IFormFile file)
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
                        pathFile = _fileServerSettings.Value.DocumentoPagoPlanta
                    });
                    request.Ruta = string.Format(@"{0}\{1}", _fileServerSettings.Value.DocumentoPagoPlanta, response.ficheroReal);
                }
            }

            _generalRepository.GuardarVoucherPlanta(request);
        }

        public void ConfirmarVoucherPagoPlanta(ConfirmarVoucherPagoPlantaRequestDTO request)
        {
            request.Fecha = DateTime.Now;
            _generalRepository.ConfirmarVoucherPagoPlanta(request.Id, request.Usuario, request.Fecha);
        }

        public List<ConsultarPagoContratoDTO> ConsultarPagoContrato(ConsultarPagoContratoRequestDTO request)
        {
            List<ConsultarPagoContratoDTO> response = new List<ConsultarPagoContratoDTO>();
            var lista = _generalRepository.ConsultarPagoContrato(request.Documento);
            if (lista.Any())
            {
                response = lista.ToList();
            }
            return response;
        }

        public ConsultarPagoContratoIdDTO ConsultarPagoContratoId(ConsultarPagoContratoIdRequestDTO request)
        {
            ConsultarPagoContratoIdDTO response = new ConsultarPagoContratoIdDTO();
            var lista = _generalRepository.ConsultarPagoContratoId(request.Id);
            if (lista.Any())
            {
                response = lista.FirstOrDefault();
            }
            return response;
        }

        public void GuardarVoucherContratoCompra(GuardarVoucherContratoCompraRequestDTO request, IFormFile file)
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
                        pathFile = _fileServerSettings.Value.DocumentoPagoContratoCompra
                    });
                    request.Ruta = string.Format(@"{0}\{1}", _fileServerSettings.Value.DocumentoPagoContratoCompra, response.ficheroReal);
                }
            }

            _generalRepository.GuardarVoucherContratoCompra(request);
        }

        public void ConfirmarVoucherPagoContratoCompra(ConfirmarVoucherPagoContratoCompraRequestDTO request)
        {
            request.Fecha = DateTime.Now;
            _generalRepository.ConfirmarVoucherPagoContratoCompra(request.Id, request.Usuario, request.Fecha);
        }

        public ProyectarCosechaResponseDTO ProyectarCosecha(ProyectarCosechaRequestDTO request)
        {
            ProyectarCosechaResponseDTO response = new ProyectarCosechaResponseDTO();
            response.Data = _generalRepository.ProyectarCosecha(request.CantMeses, request.UserId);
            object objData = response.Data;
            string jsonData = JsonConvert.SerializeObject(objData);
            response.Columnas = JObject.Parse(jsonData.TrimEnd(']').TrimStart('[')).Children().OfType<JProperty>().Select(x => char.ToUpper(x.Name[0]) + x.Name.Replace(".", string.Empty).Substring(1)).ToList();
            response.Valores = JObject.Parse(jsonData.TrimEnd(']').TrimStart('[')).Children().OfType<JProperty>().Select(x => Convert.ToDecimal(x.Value)).ToList();
            return response;
        }

        public ProyectarVentaResponseDTO ProyectarVenta(ProyectarVentaRequestDTO request)
        {
            ProyectarVentaResponseDTO result = new ProyectarVentaResponseDTO();
            result.Data = _generalRepository.ProyectarVenta(request.NroMeses);
            object objData = result.Data;
            string jsonData = JsonConvert.SerializeObject(objData).TrimEnd(']').TrimStart('[');
            result.Columnas = JObject.Parse(jsonData).Children().OfType<JProperty>().Select(x => char.ToUpper(x.Name[0]) + x.Name.Replace(".", string.Empty).Substring(1)).ToList();
            result.Valores = JObject.Parse(jsonData).Children().OfType<JProperty>().Select(x => Convert.ToDecimal(x.Value)).ToList();
            int cntCols = result.Columnas.Where(x => x.Contains("Oct")).Count();
            cntCols = cntCols + result.Columnas.Where(x => x.Contains("Abr")).Count();
            var usersIds = _IIUsersRepository.ListarUsersSocios().ToList();
            List<ColumnasProyeccionDTO> colsProyecs = new List<ColumnasProyeccionDTO>();
            List<UserProyeccionCosechaDTO> usersProyecs = new List<UserProyeccionCosechaDTO>();
            objData = _generalRepository.ProyectarCosecha(cntCols, usersIds[0].UserId);
            jsonData = JsonConvert.SerializeObject(objData).TrimEnd(']').TrimStart('[');
            foreach (var item in JObject.Parse(jsonData).Children().OfType<JProperty>().Select(x => char.ToUpper(x.Name[0]) + x.Name.Replace(".", string.Empty).Substring(1)))
            {
                colsProyecs.Add(new ColumnasProyeccionDTO { NameCol = item });
            }

            for (int i = 0; i < usersIds.Count; i++)
            {
                usersProyecs.Add(new UserProyeccionCosechaDTO { UserId = usersIds[i].UserId, CantMeses = cntCols });
            }
            objData = _generalRepository.ProyectarCosechaTodos(colsProyecs, usersProyecs);
            jsonData = JsonConvert.SerializeObject(objData).TrimEnd(']').TrimStart('[');
            result.ColumnasCosecha = JObject.Parse(jsonData).Children().OfType<JProperty>().Select(x => x.Name).ToList();
            result.ValoresCosecha = JObject.Parse(jsonData).Children().OfType<JProperty>().Select(x => Convert.ToDecimal(x.Value)).ToList();
            return result;
        }

        public ProyectarTodasCosechasResponseDTO ProyectarTodasCosechasAcopio(ProyectarTodasCosechasRequestDTO request)
        {
            ProyectarTodasCosechasResponseDTO response = new ProyectarTodasCosechasResponseDTO();
            List<string> valuesJson = new List<string>();
            List<string> tempValsJson = new List<string>();
            List<string> colsJson = new List<string>();
            object objData = _generalRepository.ProyectarTodasCosechasAcopio(request.NroMeses);
            string jsonData = JsonConvert.SerializeObject(objData).TrimEnd(']').TrimStart('[');
            var objectsJson = jsonData.Split('}');
            colsJson = JObject.Parse(string.Concat(objectsJson[0].Trim(), "}")).Children().OfType<JProperty>().Select(x => char.ToUpper(x.Name[0]) + x.Name.Replace(".", string.Empty).Substring(1)).ToList();
            response.Columnas.Add(colsJson[0]);
            for (int i = colsJson.Count - 1; i >= 1; i--)
            {
                response.Columnas.Add(colsJson[i]);
            }
            for (int i = 0; i < objectsJson.Length; i++)
            {
                if (!string.IsNullOrEmpty(objectsJson[i]))
                {
                    valuesJson = new List<string>();
                    tempValsJson = JObject.Parse(string.Concat(objectsJson[i].TrimStart(','), "}")).Children().OfType<JProperty>().Select(x => x.Value.ToString()).ToList();
                    valuesJson.Add(tempValsJson[0]);
                    for (int a = tempValsJson.Count - 1; a >= 1; a--)
                    {
                        valuesJson.Add(tempValsJson[a]);
                    }
                    response.Valores.Add(valuesJson);
                }
            }
            return response;
        }
    }
}
