using PTA.BL.Dtos;
using PTA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTA.BL.Contracts
{
    public interface IEsettHttpClient : IService
    {
        ValueTask<List<DistributionSystemOperatorDto>> GetDistributionSystemOperatorsAsync();
    }
}