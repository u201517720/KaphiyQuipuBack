using Core.Common.Domain.Model;

namespace KaphiyQuipu.DTO
{
    public class GenerarPDFEtiquetasLoteResponseDTO
    {
        public GenerarPDFEtiquetasLoteResponseDTO()
        {
            Result = new Result();
        }

        public Result Result { get; set; }
    }
}
