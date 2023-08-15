using lib.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Application.Contracts
{
    public interface IBookService
    {
        Task<bookDto> GetBookAsync(int id);
    }

}
