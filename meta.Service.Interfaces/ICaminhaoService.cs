using meta.Domain;
using meta.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta.Service.Interfaces
{
    public interface ICaminhaoService
    {
        Task<IEnumerable<Caminhao>> GetCaminhaoAsync();
        Task<int> DeleteCaminhaoAsync(long idCaminhao);
        Task<Caminhao> EditCaminhaoAsync(CaminhaoEditDTO caminhaoDTO);
        Task<Caminhao> InsertCaminhaoAsync(CaminhaoInsertDTO caminhaoDTO);
    }
}
