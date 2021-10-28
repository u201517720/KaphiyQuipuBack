using Core.Common.Domain.Model;

namespace KaphiyQuipu.DTO
{
    public class RegistrarActualizarInspeccionInternaResponseDTO
    {

        public RegistrarActualizarInspeccionInternaResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }


    }
}
