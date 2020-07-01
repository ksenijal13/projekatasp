using Application;
using Application.Commands;
using Application.Email;
using Application.Queries;
using EFDataAccess;
using Implementation.Commands;
using Implementation.Email;
using Implementation.Queries;
using Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core
{
    public static class ExtensionsForContainer
    {
        public static void AddAllTransient(this IServiceCollection services)
        {
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<CreatePerfumeValidator>();
            services.AddTransient<UpdatePerfumeValidator>();
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<ICreatePerfumeCommand, EfCreatePerfumeCommand>();
            services.AddTransient<IDeletePerfumeCommand, EfDeletePerfumeCommand>();
            services.AddTransient<IUpdatePerfumeCommand, EfUpdatePerfumeCommand>();
            services.AddTransient<IGetPerfume, EfGetPerfumeQuery>();
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();
            services.AddTransient<IUpdateBrandCommand, EfUpdateBrandCommand>();
            services.AddTransient<UpdateBrandValidator>();
            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>();
            services.AddTransient<CreateBrandValidator>();
            services.AddTransient<AddInCartValidator>();
            services.AddTransient<IGetBrandWithPerfumesQuery, EfGetBrandWithPerfumes>();
            services.AddTransient<IGetPerfumesQuery, EfGetPerfumesQuery>();
            services.AddTransient<IAddUserUseCaseCommand, EfAddUserUseCaseCommand>();
            services.AddTransient<IUserUseCaseDeleteCommand, EfUserUseCaseDeleteCommand>();
            services.AddTransient<IGetAuditLogs, EfGetAuditLogs>();
            services.AddTransient<IAddInCartCommand, EfAddInCartCommand>();
            services.AddTransient<IDeleteFromCartCommand, EfDeleteFromCartCommand>();
            services.AddTransient<IUpdateCartQuantity, EfUpdateCartQuantity>();
            services.AddTransient<UpdateCartQuantityValidator>();
            services.AddTransient<IGetYourCartQuery, EfGetYourCartQuery>();
            services.AddTransient<ICreateOrderCommand, EfCreateOrderCommand>();
            services.AddTransient<IEmailSender, SmtpEmailSender>();
            services.AddTransient<IGetPerfumesByGender, EfGetPerfumesByGender>();
            services.AddTransient<IGetPerfumesByFragranceType, EfGetPerfumesByFragranceTypeQuery>();
            services.AddTransient<IGetGenders, EfGetGenders>();
            services.AddTransient<IGetFragranceTypes, EfGetFragranceTypeQuery>();
        }
        
    }
}
