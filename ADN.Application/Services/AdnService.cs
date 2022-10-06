using ADN.Domain.Entities;
using ADN.Domain.Interfaces.Repositories;
using ADN.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Application.Services
{
    internal class AdnService : IAdnService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdnService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public async Task<bool> Update(Adn obj)
        {
            await _unitOfWork.AdnRepository.Update(obj);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
