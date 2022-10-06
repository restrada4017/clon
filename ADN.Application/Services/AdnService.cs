using ADN.Domain.CustomEntities;
using ADN.Domain.Entities;
using ADN.Domain.Interfaces.Repositories;
using ADN.Domain.Interfaces.Services;
using ADN.Domain.Interfaces.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace ADN.Application.Services
{
    internal class AdnService : IAdnService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdnAnalyses _AdnAnalyses;
        private const string Contador_clon_adn = "contador_clon_adn";
        private const string Contador_amigos_adn = "contador_amigos_adn";

        public AdnService(IUnitOfWork unitOfWork, IAdnAnalyses adnAnalyses)
        {
            _unitOfWork = unitOfWork;
            _AdnAnalyses = adnAnalyses;
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.AdnRepository.Delete(id);
        }

        public async Task<List<Adn>> GetAll()
        {


            var result = await Task.FromResult(_unitOfWork.AdnRepository.GetAll());
            return result.ToList();
        }

        public async Task<Adn> GetById(int id)
        {
            var result = await _unitOfWork.AdnRepository.GetById(id);
            return result;
        }

        public async Task Insert(Adn obj)
        {
            await _unitOfWork.AdnRepository.Add(obj);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> IsClon(string[] matrix)
        {
            bool resul = await _AdnAnalyses.IsClon(matrix);
            string adn = _AdnAnalyses.StringMatrix(matrix);
            await _unitOfWork.AdnRepository.InsertADN(adn, resul);
            await _unitOfWork.SaveChangesAsync();
            return resul;
        }

        public async Task<bool> Update(Adn obj)
        {
            await _unitOfWork.AdnRepository.Update(obj);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
