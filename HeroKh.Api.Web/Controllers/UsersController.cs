using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HeroKh.Api.Web.Models;
using HeroKh.Api.Web.DTOs.User;
using AutoMapper;
using HeroKh.Api.Web.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace HeroKh.Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Users/5
        [HttpGet]
        public async Task<ActionResult<ReadonlyUserDto>> GetUser()
        {
            var user = await _unitOfWork.UserRepository.GetByEmailAddressAsync(User.Identity.Name);

            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<ReadonlyUserDto>(user);
            return userDto;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var currentUser = await _unitOfWork.UserRepository.GetByEmailAddressAsync(User.Identity.Name);
            await _unitOfWork.UserRepository.UpdateAsync(currentUser.Id, user);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _unitOfWork.UserRepository.ExistsAsync(currentUser.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}
