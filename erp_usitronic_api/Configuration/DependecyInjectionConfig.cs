using erp_usitronic.business.interfaces;
using erp_usitronic.business.notifications;
using erp_usitronic.business.services;
using erp_usitronic.database.Repositories;
using erp_usitronic.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace erp_usitronic.api.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            #region Repository            
            services.AddScoped<IAddressRepository, AddressRepository>()
                .AddScoped<IBankRepository, BankRepository>()
                .AddScoped<ICityRepository, CityRepository>()
                .AddScoped<ICheckRepository, CheckRepository>()
                .AddScoped<ICompanyRepository, CompanyRepository>()
                .AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<IEmailRepository, EmailRepository>()
                .AddScoped<IPaymentRepository, PaymentRepository>()
                .AddScoped<IPersonRepository, PersonRepository>()
                .AddScoped<IReceiptRepository, ReceiptRepository>()
                .AddScoped<IStateRepository, StateRepository>()
                .AddScoped<ISupplierRepository, SupplierRepository>()
                .AddScoped<ITelephoneRepository, TelephoneRepository>()
                .AddScoped<IApiTokenRepository, ApiTokenRepository>()
                .AddScoped<IApiUserRepository, ApiUserRepository>()
                .AddScoped<IFinancialMovementRepository, FinancialMovementRepository>();
            #endregion

            #region config          
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            services.AddScoped<INotificator, Notificator>()
                .AddTransient<ApiUserRepository>()
                .AddDbContext<ApiDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SQLServerConnection")), ServiceLifetime.Transient);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Service
            services.AddScoped<IAddressService, AddressService>()
                .AddScoped<IBankService, BankService>()
                .AddScoped<ICheckService, CheckService>()
                .AddScoped<ICityService, CityService>()
                .AddScoped<ICompanyService, CompanyService>()
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<IEmailService, EmailService>()
                .AddScoped<IPaymentService, PaymentService>()
                .AddScoped<IPersonService, PersonService>()
                .AddScoped<IReceiptService, ReceiptService>()
                .AddScoped<IStateService, StateService>()
                .AddScoped<ISupplierService, SupplierService>()
                .AddScoped<ITelephoneService, TelephoneService>()
                .AddScoped<ICashFlowService, CashFlowService>()
                .AddScoped<ICashFlowDayService, CashFlowDayService>()
                .AddScoped<IFinancialMovementService, FinancialMovementService>()
                .AddScoped<IApiUserService, ApiUserService>();
            #endregion

            return services;
        }

        public static T GetService<T>()
        {
            var services = new ServiceCollection();
            services.ResolveDependencies();
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider.GetService<T>();
        }
    }
}
