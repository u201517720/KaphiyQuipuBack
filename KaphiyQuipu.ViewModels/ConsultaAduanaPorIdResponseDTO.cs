using Core.Common.Domain.Model;

namespace KaphiyQuipu.DTO
{

    public class ConsultaAduanaPorIdResponseDTO
    {
        public ConsultaAduanaPorIdResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }
    }
}
