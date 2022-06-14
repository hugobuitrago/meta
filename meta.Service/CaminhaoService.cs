using meta.Domain;
using meta.DTO;
using meta.Infra.Data.Interfaces.Repositories;
using meta.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace meta.Service
{
    public class CaminhaoService : ICaminhaoService
    {
        readonly ICaminhaoRepository _caminhaoRepository;

        public CaminhaoService(ICaminhaoRepository caminhaoRepository)
        {
            _caminhaoRepository = caminhaoRepository;
        }

        public async Task<IEnumerable<Caminhao>> GetCaminhaoAsync()
        {
            return await _caminhaoRepository.GetAll();
        }

        public async Task<int> DeleteCaminhaoAsync(long idCaminhao)
        {
            Caminhao caminhao = await _caminhaoRepository.GetById(idCaminhao);
            return await _caminhaoRepository.Delete(caminhao);
        }

        public async Task<Caminhao> EditCaminhaoAsync(CaminhaoEditDTO caminhaoDTO)
        {
            Caminhao caminhao = await _caminhaoRepository.GetById(caminhaoDTO.Id);
            caminhao.Modelo = caminhaoDTO.Modelo;
            caminhao.AnoFabricacao = caminhaoDTO.AnoFabricacao;
            caminhao.AnoModelo = caminhaoDTO.AnoModelo;

            await _caminhaoRepository.Edit(caminhao);
            return caminhao;
        }

        public async Task<Caminhao> InsertCaminhaoAsync(CaminhaoInsertDTO caminhaoDTO)
        {
            Caminhao caminhao = new Caminhao();
            caminhao.Modelo = caminhaoDTO.Modelo;
            caminhao.AnoFabricacao = caminhaoDTO.AnoFabricacao;
            caminhao.AnoModelo = caminhaoDTO.AnoModelo;

            await _caminhaoRepository.Insert(caminhao);
            return caminhao;
        }


    }
}
