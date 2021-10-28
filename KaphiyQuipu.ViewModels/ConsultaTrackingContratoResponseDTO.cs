using Core.Common.Domain.Model;

namespace KaphiyQuipu.DTO
{

    public class ConsultaTrackingContratoResponseDTO
    {
        public ConsultaTrackingContratoResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
