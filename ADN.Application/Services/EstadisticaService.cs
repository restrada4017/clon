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
    public class EstadisticaService : IEstadisticaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstadisticaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.EstadisticaRepository.Delete(id);
        }

        public async Task<List<Estadistica>> GetAll()
        {
            var result = await Task.FromResult(_unitOfWork.EstadisticaRepository.GetAll());
            return result.ToList();
        }

        public async Task<Estadistica> GetById(int id)
        {
            var result = await _unitOfWork.EstadisticaRepository.GetById(id);
            return result;
        }

        public async Task Insert(Estadistica obj)
        {
            await _unitOfWork.EstadisticaRepository.Add(obj);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(Estadistica obj)
        {
            await _unitOfWork.EstadisticaRepository.Update(obj);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
