using Beanify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beanify.Services
{
    public interface IProductService
    {
        Task<List<IModel>> GetProducts();
    }
}
