using KaphiyQuipu.DTO;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Service
{
    public interface IGeneralService
    {
        List<ConsultarDocumentoPagoDTO> ConsultarDocumentoPago(ConsultarDocumentoPagoRequestDTO request);
        ConsultarDocumentoPagoPorIdDTO ConsultarDocumentoPagoPorId(ConsultarDocumentoPagoPorIdRequestDTO request);
        void GuardarVoucher(GuardarVoucherRequestDTO request, IFormFile file);
        void ConfirmarVoucherPago(ConfirmarVoucherPagoRequestDTO request);
        void GenerarPagoPendientePlanta(GenerarPagoPendientePlantaRequestDTO request);
        List<ConsultarDocumentoPagoPlantaDTO> ConsultarDocumentoPagoPlanta(ConsultarDocumentoPagoPlantaRequestDTO request);
        ConsultarDocumentoPagoPlantaPorIdDTO ConsultarDocumentoPagoPlantaPorId(ConsultarDocumentoPagoPlantaPorIdRequestDTO request);
        void AprobarDepositoPlanta(AprobarDepositoPlantaRequestDTO request);
        void GuardarVoucherPlanta(GuardarVoucherPlantaRequestDTO request, IFormFile file);
        void ConfirmarVoucherPagoPlanta(ConfirmarVoucherPagoPlantaRequestDTO request);
        List<ConsultarPagoContratoDTO> ConsultarPagoContrato(ConsultarPagoContratoRequestDTO request);
        ConsultarPagoContratoIdDTO ConsultarPagoContratoId(ConsultarPagoContratoIdRequestDTO request);
        void GuardarVoucherContratoCompra(GuardarVoucherContratoCompraRequestDTO request, IFormFile file);
        void ConfirmarVoucherPagoContratoCompra(ConfirmarVoucherPagoContratoCompraRequestDTO request);
        ProyectarCosechaResponseDTO ProyectarCosecha(ProyectarCosechaRequestDTO request);
        ProyectarVentaResponseDTO ProyectarVenta(ProyectarVentaRequestDTO request);
        ProyectarTodasCosechasResponseDTO ProyectarTodasCosechasAcopio(ProyectarTodasCosechasRequestDTO request);
        List<ValoracionesPorAgricultorDTO> ValoracionesPorAgricultor(ValoracionesPorAgricultorRequestDTO request);
        List<ListarPuntajeValoracionesAgricultoresDTO> ListarPuntajeValoracionesAgricultores(ListarPuntajeValoracionesAgricultoresRequestDTO request);
        string GuardarValoracionClienteExterno(GuardarValoracionClienteExternoRequestDTO request);
    }
}
