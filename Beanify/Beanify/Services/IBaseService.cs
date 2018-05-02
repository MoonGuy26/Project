using Beanify.Models;
using Beanify.RestClients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beanify.Services
{
    public interface IBaseService
    {
       
        Task AddItem(IModel item);
    }
}
