using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN.Domain.Interfaces.Services
{
    public interface IService<T>
    {

        Task<T> GetById(int id);

        Task Insert(T obj);

        Task<bool> Update(T obj);

        Task Delete(int id);

        Task<List<T>> GetAll();

    }
}
