﻿using KaphiyQuipu.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Interface.Repository
{
    public interface IGeneralRepository
    {
        IEnumerable<ConsultarDocumentoPagoDTO> ConsultarDocumentoPago(string correlativoDPA, string correlativoCC, int id);
        IEnumerable<ConsultarDocumentoPagoPorIdDTO> ConsultarDocumentoPagoPorId(int id);
        void GuardarVoucher(GuardarVoucherRequestDTO request);
        void ConfirmarVoucherPago(int id, string usuario, DateTime fecha);
        void GenerarPagoPendientePlanta(int id, string correlativo, string usuario, DateTime fecha);
        IEnumerable<ConsultarDocumentoPagoPlantaDTO> ConsultarDocumentoPagoPlanta(string documento);
        IEnumerable<ConsultarDocumentoPagoPlantaPorIdDTO> ConsultarDocumentoPagoPlantaPorId(int id);
        void AprobarDepositoPlanta(int id, string usuario, DateTime fecha);
        void GuardarVoucherPlanta(GuardarVoucherPlantaRequestDTO request);
        void ConfirmarVoucherPagoPlanta(int id, string usuario, DateTime fecha);
    }
}