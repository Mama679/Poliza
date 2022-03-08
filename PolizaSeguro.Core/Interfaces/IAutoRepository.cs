using PolizaSeguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolizaSeguro.Core.Interfaces
{
    public interface IAutoRepository
    {
        Task<IEnumerable<Auto>> getAutos();
        Task<Auto> getAuto(int id);
        Task<bool> addAuto(Auto auto);

        Task<bool> updateAuto(Auto auto);
        Task<bool> deleteAuto(int id);
    }
}
