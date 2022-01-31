using Core.Common.Domain.Model;

namespace KaphiyQuipu.DTO
{

    public class ConsultaContratoPorIdResponseDTO
    {
        public ConsultaContratoPorIdResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
