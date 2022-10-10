using AutoMapper;
using JobTask.Data.IRepositories;
using JobTask.Domain.Entities;
using JobTask.Service.DTOs;
using JobTask.Service.Exceptions;
using JobTask.Service.Extentions;
using JobTask.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobTask.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async ValueTask<User> CreateAsync(UserForCreationDto dto)
        {
            var user = await userRepository.GetAsync(u => u.Username == dto.Username);

            if (user is not null)
                throw new JobTaskException(400, "User already exists");

            User mappedUser = mapper.Map<User>(dto);

            mappedUser.Password = dto.Password.Encrypt();

            User newUser = await userRepository.AddAsync(mappedUser);

            await userRepository.SaveChangesAsync();

            return newUser;
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            var user = await userRepository.GetAsync(expression);

            if (user is null)
                throw new JobTaskException(404, "User not found");

            userRepository.Delete(user);

            await userRepository.SaveChangesAsync();

            return true;
        }

        public async ValueTask<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null)
        {
            var users = userRepository.GetAll(expression);

            return users;
        }

        public async ValueTask<User> GetAsync(Expression<Func<User, bool>> expression)
        {
            var user = await userRepository.GetAsync(expression);

            if (user is null)
                throw new JobTaskException(404, "User not found");

            return user;
        }

        public async ValueTask<User> UpdateAsync(long id, UserForCreationDto dto)
        {
            var user = await userRepository.GetAsync(u => u.Id == id);

            if (user is null)
                throw new JobTaskException(404, "User not found!");

            user = mapper.Map(dto, user);

            user.Password = user.Password.Encrypt();

            userRepository.Update(user);

            await userRepository.SaveChangesAsync();

            return user;
        }
    }
}
