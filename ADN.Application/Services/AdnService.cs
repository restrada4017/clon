using ADN.Domain.CustomEntities;
using ADN.Domain.Entities;

using ADN.Domain.Interfaces.Services;
using ADN.Domain.Interfaces.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ADN.Application.Contracts.Persistence;

namespace ADN.Application.Services
{
    internal class AdnService : IAdnService
    {
       
        private readonly IAdnAnalyses _AdnAnalyses;
        private readonly ICache _cache;
        private readonly IUnitOfWork _unitOfWork;

        public AdnService(IUnitOfWork unitOfWork, IAdnAnalyses adnAnalyses, ICache cache)
        {
            _unitOfWork = unitOfWork;
            _AdnAnalyses = adnAnalyses;
            _cache = cache;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Adn>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Adn> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Adn obj)
        {
            throw new NotImplementedException();
        }

        //public Task<bool> IsClon(string[] matrix)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<bool> Update(Adn obj)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsClon(string[] matrix)
        {

            string adn = _AdnAnalyses.StringMatrix(matrix);

            string cacheAdn = adn;
            string serializedAdn;
            var redisAdn = await _cache.Get(cacheAdn);
            if (redisAdn != null)
            {
                serializedAdn = Encoding.UTF8.GetString(redisAdn);
                var objadn = JsonConvert.DeserializeObject<Adn>(serializedAdn);
                return objadn.IsClon;
            }
            else
            {
                bool resul = await _AdnAnalyses.IsClon(matrix);
                var objadn = await _unitOfWork.AdnRepository.InsertADN(adn, resul);
                await _unitOfWork.SaveChangesAsync();
                serializedAdn = JsonConvert.SerializeObject(objadn);
                redisAdn = Encoding.UTF8.GetBytes(serializedAdn);
                await _cache.Set(cacheAdn, redisAdn);
                return resul;
            }
        }

        /*
       public AdnService(IUnitOfWork unitOfWork, IAdnAnalyses adnAnalyses, ICache cache)
       {
           _unitOfWork = unitOfWork;
           _AdnAnalyses = adnAnalyses;
           _cache = cache;
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

           string adn = _AdnAnalyses.StringMatrix(matrix);

           string cacheAdn = adn;
           string serializedAdn;
           var redisAdn = await _cache.Get(cacheAdn);
           if (redisAdn != null)
           {
               serializedAdn = Encoding.UTF8.GetString(redisAdn);
               var objadn = JsonConvert.DeserializeObject<Adn>(serializedAdn);
               return objadn.IsClon;
           }
           else
           {
               bool resul = await _AdnAnalyses.IsClon(matrix);
               var objadn = await _unitOfWork.AdnRepository.InsertADN(adn, resul);
               await _unitOfWork.SaveChangesAsync();
               serializedAdn = JsonConvert.SerializeObject(objadn);
               redisAdn = Encoding.UTF8.GetBytes(serializedAdn);
               await _cache.Set(cacheAdn,redisAdn);
               return resul;
           }
       }

       public async Task<bool> Update(Adn obj)
       {
           await _unitOfWork.AdnRepository.Update(obj);
           await _unitOfWork.SaveChangesAsync();
           return true;
       }

       */

    }
}
