using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CullinaryCrossroads1._1.Core.Contacts
{
    public interface IAgentService
    {
        public Task<int> GetAgentIdAsync(string userId);
        
       public Task<bool> ExistByIdAsync(string userId);
       public Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber);
     
       public Task CreateAsync(string userId, string phoneNumber);
           
    }
}
