using BBL.BusinessModels;
using BBL.DTO;
using System;
using System.Threading.Tasks;

namespace BBL.Services.Interfaces
{
    public interface IMarkService
    {
        public Task<Response<SkippedDaysDTO>> Mark(Guid id);
    }
}
