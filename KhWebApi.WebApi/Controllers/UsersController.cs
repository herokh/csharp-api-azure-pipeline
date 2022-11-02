using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KhWebApi.WebApi.Models;
using KhWebApi.WebApi.DTOs.User;
using AutoMapper;
using KhWebApi.WebApi.Repositories.Interfaces;

namespace KhWebApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public readonly IMapper _mapper;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<ReadonlyUserDto>> GetUsers()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadonlyUserDto>>(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadonlyUserDto>> GetUser(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<ReadonlyUserDto>(user);
            return userDto;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _unitOfWork.UserRepository.UpdateAsync(id, user);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _unitOfWork.UserRepository.ExistsAsync(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, _mapper.Map<ReadonlyUserDto>(user));
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            if (!await _unitOfWork.UserRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _unitOfWork.UserRepository.RemoveAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
