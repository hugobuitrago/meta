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

        public async Task<int?> DeleteCaminhaoAsync(long idCaminhao)
        {
            Caminhao caminhao = await _caminhaoRepository.GetById(idCaminhao);

            if (caminhao == null)
                return null;

            return await _caminhaoRepository.Delete(caminhao);
        }

        public async Task<Caminhao> EditCaminhaoAsync(CaminhaoEditDTO caminhaoDTO)
        {
            Caminhao caminhao = await _caminhaoRepository.GetById(caminhaoDTO.Id);
            if (caminhao == null)
                return null;

            caminhao.Modelo = caminhaoDTO.Modelo;
            caminhao.AnoFabricacao = caminhaoDTO.AnoFabricacao;
            caminhao.AnoModelo = caminhaoDTO.AnoModelo;

            if ((caminhaoDTO.AnoFabricacao != DateTime.Now.Year) || (caminhaoDTO.AnoModelo != DateTime.Now.Year && caminhaoDTO.AnoModelo != DateTime.Now.AddYears(1).Year))
            {
                ArgumentException ex = new ArgumentException("Ano de Fabricacao ou Modelo fora do permitido");
                throw ex;
            }

            await _caminhaoRepository.Edit(caminhao);
            return caminhao;
        }

        public async Task<Caminhao> InsertCaminhaoAsync(CaminhaoInsertDTO caminhaoDTO)
        {
            Caminhao caminhao = new Caminhao();
            caminhao.Modelo = caminhaoDTO.Modelo;
            caminhao.AnoFabricacao = caminhaoDTO.AnoFabricacao;
            caminhao.AnoModelo = caminhaoDTO.AnoModelo;

            if ((caminhaoDTO.AnoFabricacao != DateTime.Now.Year) || (caminhaoDTO.AnoModelo != DateTime.Now.Year && caminhaoDTO.AnoModelo != DateTime.Now.AddYears(1).Year))
            {
                ArgumentException ex = new ArgumentException("Ano de Fabricacao ou Modelo fora do permitido");
                throw ex;
            }


            await _caminhaoRepository.Insert(caminhao);
            return caminhao;
        }


    }
}
