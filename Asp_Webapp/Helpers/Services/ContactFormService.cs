using Asp_Webapp.Helpers.Repositories;
using Asp_Webapp.Models.Entities;
using Asp_WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Asp_Webapp.Helpers.Services
{
    public class ContactFormService
    {
        private readonly ContactFormRepo _repo;

        public ContactFormService(ContactFormRepo repo)
        {
            _repo = repo;
        }

        public async Task<bool> CreateAsync(ContactFormViewModel ViewModel)
        {
            try
            {
               var _ViewModel = await _repo.AddAsync(ViewModel);
                if (_ViewModel != null) 
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
