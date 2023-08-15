using lib.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Application.Contracts
{
    public interface IBookRepository
    {
        Task<bookDto> GetBookAsync(int id);
    }   

}
