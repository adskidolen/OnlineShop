namespace KeepHome.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using KeepHome.Data;
    using KeepHome.Models;
    using KeepHome.Web.Middlewares.Extensions;
    using KeepHome.Web.Infrastructure;

    using AutoMapper;
    using KeepHome.Services.Contracts;
    using KeepHome.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<KeepHomeContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"))
                       .UseLazyLoadingProxies());

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

                options.SignIn.RequireConfirmedEmail = false;
            });

            services.AddIdentity<KeepHomeUser, IdentityRole>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<KeepHomeContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                options.Cookie.Name = "FooteoCookie";
                options.Cookie.HttpOnly = true;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
            services.AddScoped<IAddressesService, AddressesService>();
            services.AddScoped<IChildCategoryService, ChildCategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IParentCategoryService, ParentCategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShoppingBagService, ShoppingBagService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPaymentsService, PaymentsService>();
            services.AddScoped<IBlogPostsService, BlogPostsService>();
            services.AddScoped<IBlogCommentsService, BlogCommentsService>();

            services.AddAutoMapper();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            //External Login
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

            //services.AddAuthentication().AddGoogle(googleOptions =>
            //{
            //    googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
            //    googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSeedDataMiddleware();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}