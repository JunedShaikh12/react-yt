
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Repository.Services
{
    public interface IPService
    {
        public IEnumerable<PModel> GetAll();
        PModel? GetById(int id);
        IEnumerable<PModel> Searchh(string? category);
        public IEnumerable<PModel> AddPrd(PModel product);
        //bool UpdatePrice(int id, decimal discountPercent);
    }
}
