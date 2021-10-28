using Core.Common.Domain.Model;

namespace KaphiyQuipu.DTO
{
    public class RegistrarActualizarDiagnosticoResponseDTO
    {

        public RegistrarActualizarDiagnosticoResponseDTO()
        {
            this.Result = new Result();
        }
        public Result Result { get; set; }


    }
}
