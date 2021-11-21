using Core.Common.Domain.Model;

namespace KaphiyQuipu.DTO
{
    public class ConsultarStickersAcopioResponseDTO
    {
        public ConsultarStickersAcopioResponseDTO()
        {
            Result = new Result();
        }

        public Result Result { get; set; }
    }
}
