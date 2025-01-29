using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CulinaryCrossroads1._1.Interface.Data;
using CullinaryCrossroads1._1.Core.Contacts;
using CullinaryCrossroads1._1.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CullinaryCrossroads1._1.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly ApplicationDbContext data;
        public AgentService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task CreateAsync(string userId, string phoneNumber)
        {
            var agent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };
            await data.Agents.AddAsync(agent);
            await data.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await data.Agents.AnyAsync(a => a.UserId == userId);
        }

        public async Task<int> GetAgentIdAsync(string userId)
        {
            var agent = await data.Agents.FirstOrDefaultAsync(a => a.UserId == userId);
            return agent?.Id ?? -1;
        }

        public async Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber)
        {
            return await data.Agents.AnyAsync(a => a.PhoneNumber == phoneNumber);
        }
    }
}
