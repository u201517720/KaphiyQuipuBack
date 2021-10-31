using Core.Common.Domain.Model;

namespace KaphiyQuipu.DTO
{

    public class ConsultaContratoResponseDTO
    {
        public ConsultaContratoResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
