using meta.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta.Infra.Data.Interfaces.Repositories
{
    public interface ICaminhaoRepository
    {
        Task<IEnumerable<Caminhao>> GetAll();
        Task<Caminhao> GetById(long idCaminhao);
        Task<int> Delete(Caminhao caminhao);
        Task<int> Edit(Caminhao caminhao);
        Task<int> Insert(Caminhao caminhao);
    }
}
