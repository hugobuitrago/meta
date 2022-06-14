using meta.Domain;
using meta.Infra.Data.Context;
using meta.Infra.Data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meta.Infra.Data.Repositories
{
    public class CaminhaoRepository : ICaminhaoRepository
    {
        readonly Meta_Context _context;
        public CaminhaoRepository(Meta_Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Caminhao>> GetAll()
        {
            return await _context.Caminhao.ToListAsync();
        }

        public async Task<Caminhao> GetById(long idCaminhao)
        {
            return await _context.Caminhao.FindAsync(idCaminhao);
        }

        public async Task<int> Delete(Caminhao caminhao)
        {
            _context.Caminhao.Remove(caminhao);
            return await _context.SaveChangesAsync();                
        }

        public async Task<int> Edit(Caminhao caminhao)
        {
            _context.Caminhao.Update(caminhao);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Insert(Caminhao caminhao)
        {
            _context.Caminhao.Add(caminhao);
            return await _context.SaveChangesAsync();
        }

    }
}
