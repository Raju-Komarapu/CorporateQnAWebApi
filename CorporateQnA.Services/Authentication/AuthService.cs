using AutoMapper;
using CorporateQnA.Core.Models.Authentication;
using CorporateQnA.Data.Models.Employee;
using CorporateQnA.Services.Interfaces;
using CorporateQnA.Services.Token;
using Microsoft.AspNetCore.Identity;

namespace CorporateQnA.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;

        private readonly IEmployeeService _employeeService;

        private readonly IMapper _mapper;

        private readonly UserManager<IdentityUser> _userManager;

        public AuthService(IEmployeeService employeeService, ITokenService tokenService, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            this._userManager = userManager;
            this._employeeService = employeeService;
            this._tokenService = tokenService;
            this._mapper = mapper;
        }

        public async Task<AuthResponse> Login(LoginModel loginModel)
        {
            //check if user exists or not
            var user = await this._userManager.FindByEmailAsync(loginModel.Email);
            if (user == null)
            {
                return new AuthResponse() { Succeeded = false, Message = "User not found" };
            }

            //check password entered by user is correct or not
            var checkPassword = await this._userManager.CheckPasswordAsync(user, loginModel.Password);
            if (!checkPassword)
            {
                return new AuthResponse() { Succeeded = false, Message = "Credentials didn't match" };
            }

            //login success. Generate token
            var token = this._tokenService.GenerateToken(user);
            return new AuthResponse() { Succeeded = true, Message = "Login Successfull", Token = token };
        }

        public async Task<AuthResponse> Register(RegisterModel registerModel)
        {
            //check if user with email id already exists or not
            var user = await this._userManager.FindByEmailAsync(registerModel.Email);
            if (user != null)
            {
                return new AuthResponse() { Succeeded = false, Message = "User with emailId already exists" };
            }

            //create new user
            var newUser = new IdentityUser() { Email = registerModel.Email, UserName = registerModel.Email };
            var result = await this._userManager.CreateAsync(newUser, registerModel.Password);

            //registration of new user successfull
            if (result.Succeeded)
            {
                //if user created successfully then add new employee
                var newlyAddedUser = await this._userManager.FindByEmailAsync(newUser.Email);
                var newEmployee = this._mapper.Map<Employee>(registerModel);
                newEmployee.UserId = Guid.Parse(newlyAddedUser.Id);
                this._employeeService.AddEmployee(newEmployee);

                //generate token
                var token = this._tokenService.GenerateToken(newlyAddedUser);
                return new AuthResponse { Succeeded = true, Message = "Registration successfull", Token = token };
            }

            //registration of new user failed
            return new AuthResponse() { Succeeded = false, Message = "Registration failed" };
        }
    }
}
