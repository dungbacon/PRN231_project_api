﻿using e_commerce_app_api.Config;
using e_commerce_app_api.DTOs;
using e_commerce_app_api.DTOs.Request;
using e_commerce_app_api.DTOs.Response;
using e_commerce_app_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace e_commerce_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {

        private readonly IAccountRepository repo;
        private readonly IConfiguration configuration;

        public AccountController(IAccountRepository _repo, IConfiguration _configuration)
        {
            repo = _repo;
            configuration = _configuration;
        }

        [HttpPost("verify")]
        [Authorize]
        public async Task<IActionResult> VerifyJwtToken()
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            if (string.IsNullOrWhiteSpace(token)) return Unauthorized();
            var isVerified = JwtConfig.VerifyToken(token, configuration);
            return isVerified ? Ok() : Unauthorized();
        }

        [HttpGet("accounts")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetUsers()
        {
            var list = await repo.GetAccounts();
            return Ok(list);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO req)
        {
            var item = await repo.GetAccount(req.Email, req.Password);
            if (item == null)
            {
                return Unauthorized();
            }
            var token = JwtConfig.CreateToken(item, configuration);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(token);

            LoginResponseDTO response = new LoginResponseDTO
            {
                Account = item,
                AccessToken = token,
                CreateDate = DateTime.Now,
                ExpiredDate = DateTime.Now.AddMinutes(30)
            };
            return Ok(response);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO input)
        {
            var _item = await repo.GetAccountByEmail(input.Email);
            if (_item != null)
            {
                return Conflict("Email have been chosen!");
            }

            AccountDTO account = new AccountDTO
            {
                FullName = input.FullName,
                Email = input.Email,
                Password = input.Password,
                Phone = input.PhoneNumber,
                CreateDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                RoleId = 3,
                IsActive = true
            };

            var item = await repo.AddAccount(account);

            return Ok(item);
        }

        [HttpPut("update/{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromBody] AccountRequestUpdateDTO account, int id)
        {

            var getAccountByIdTask = await repo.GetAccountById(id);

            if (getAccountByIdTask == null)
            {
                return NotFound("No user found!");
            }

            var item = await repo.UpdateAccount(account, id);
            return Ok(item);
        }

        [HttpGet("{accountId}")]
        [Authorize]
        public async Task<IActionResult> GetAccountOrdersById(int accountId)
        {
            try
            {
                var item = await repo.GetAccountById(accountId);
                if (item == null)
                {
                    return NotFound("No account found!");
                }
                return Ok(item);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }

        }
    }
}
