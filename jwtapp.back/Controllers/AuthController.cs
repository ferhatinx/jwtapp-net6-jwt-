using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using jwtapp.back.Core.Application.Features.CQRS.Commands;
using jwtapp.back.Core.Application.Features.CQRS.Queries;
using jwtapp.back.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace jwtapp.back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("",request);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var dto = await _mediator.Send(request);
            if (dto.IsExist)
            {
                var token =JwtTokenGenerator.GenereateToken(dto);
                return Created("",token);
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
        }
         [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllAppUsersQueryRequest());
            return Ok(result);
        }
    }

}