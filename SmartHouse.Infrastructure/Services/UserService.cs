﻿using Microsoft.AspNetCore.Http;
using SmartHouse.Core.Models;
using SmartHouse.Core.Repository;
using SmartHouse.Core.Services;
using SmartHouse.Email.Services;
using SmartHouse.Infrastructure.Common;
using SmartHouse.Shared.Core.Extensions;
using SmartHouse.Shared.Core.Helpers;
using SmartHouse.Shared.Infrastructure.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHouse.Infrastructure.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUtilityService utilityService;
        private readonly IEmailService emailService;

        public UserService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext, IUtilityService utilityService, IEmailService emailService) : base(unitOfWork, httpContext)
        {
            this.utilityService = utilityService;
            this.emailService = emailService;
        }

        public async Task<string> Authenticate(string email, string password)
        {
            var user = await unitOfWork.UserRepository
                .SingleOrDefaultAsync(u => u.Id == email);

            if (user == null || user.Password.Decrypt() != password)
                throw new NotFoundException("Invalid user credentials");
            else if (!user.Verify)
            {
                var genToken = utilityService.GenerateToken(user);
                await emailService.SendVerification(email, genToken);
                throw new AccountVerificationFailedException("Please check your email for the account verification");
            }

            unitOfWork.UserRepository.Update(user.LoggedDate());
            await unitOfWork.CommitAsync();

            var token = utilityService.GenerateToken(user);
            return token;
        }

        public async Task CreateAsync(User user)
        {
            #region Validate Email
            var trueMail = false;
            List<string> checkEmail = new List<string>() { "outlook.com", "gmail.com", "yahoo.com", "hotmail.com", "mingems.co.uk" };

            var index = user.Id.IndexOf("@");
            var removed = user.Id.Substring(index + 1, user.Id.Length - index - 1);

            foreach (var item in checkEmail)
            {
                if (item == removed)
                {
                    trueMail = true;
                }
            }
            #endregion

            if (!trueMail)
                throw new InvalidException("Invalid Email, Please try again with a valid mail");
            await unitOfWork.UserRepository.AddAsync(user.Create(Email, user));
            var token = utilityService.GenerateToken(user);
            await emailService.SendVerification(user.Id, token);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(string Id)
        {
            var query = await unitOfWork.UserRepository.GetByIdAsync(Id);
            if (query == null)
                throw new NotFoundException("No user exist or user has been removed");
            unitOfWork.UserRepository.Remove(query.Delete(Email));
            await unitOfWork.CommitAsync();
        }

        public async Task ForgotPasswordAsync(string email)
        {
            var user = await unitOfWork.UserRepository.GetByIdAsync(email);
            if (user == null)
                throw new NotFoundException("No user exist or user has been removed");
            var secret_token = utilityService.GenerateToken(user);
            await emailService.SendForgotPasswordLink(email, secret_token);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<User> GetAsync(string Id)
        {
            return await unitOfWork.UserRepository.SingleOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<User> GetMetaDataAsync(string token)
        {
            var email = utilityService.ValidateToken(token);
            return await unitOfWork.UserRepository.SingleOrDefaultAsync(u => u.Id == email);
        }

        public async Task ResendVerificationAsync(string email)
        {
            var user = await unitOfWork.UserRepository.GetByIdAsync(email);
            if (user == null)
                throw new NotFoundException("No user exist or user has been removed");
            var token = utilityService.GenerateToken(user);
            await emailService.SendVerification(user.Id, token);
        }

        public async Task UpdateAsync(User user)
        {
            var query = await unitOfWork.UserRepository.GetByIdAsync(user.Id);
            if (query == null)
                throw new NotFoundException("No user exist or user has been removed");
            unitOfWork.UserRepository.Update(query.Update(Email, user));
            await unitOfWork.CommitAsync();
        }

        public async Task UpdatePasswordAsync(PasswordModel model, string token)
        {
            var email = utilityService.ValidateToken(token);
            var query = await unitOfWork.UserRepository.GetByIdAsync(email);
            if (query == null)
                throw new NotFoundException("No user exist or user has been removed");
            unitOfWork.UserRepository.Update(query.UpdatePassword(model.Password));
            await unitOfWork.CommitAsync();
        }

        public async Task VerifyAccountAsync(string token)
        {
            var email = utilityService.ValidateToken(token);

            var user = await unitOfWork.UserRepository.GetByIdAsync(email);
            if (user == null)
                throw new NotFoundException("No user exist or user has been removed");
            unitOfWork.UserRepository.Update(user.VerifyAccount());
            await unitOfWork.CommitAsync();
        }
    }
}
