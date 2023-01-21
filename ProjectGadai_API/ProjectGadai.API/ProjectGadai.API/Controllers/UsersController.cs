using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectGadai.API.Data;
using ProjectGadai.API.Models;
using System;

namespace ProjectGadai.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ProjectGadaiDbContext _projectGadaiDbContext;
        public UsersController(ProjectGadaiDbContext projectGadaiDbContext)
        {
            _projectGadaiDbContext = projectGadaiDbContext;
        }

        public class UserSearch
        {
            public string searchId { get; set; }
            public string searchName { get; set; }
            public string searchKet { get; set; }
            public string searchHp { get; set; }
        }

        [HttpGet]
        public async Task<IActionResult> doGetAllUsers()
        {
            var users = await _projectGadaiDbContext.Users.ToListAsync();
            
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> doInsert([FromBody] User userRequest)
        {
            userRequest.user_id = Guid.NewGuid();

            await _projectGadaiDbContext.Users.AddAsync(userRequest);
            await _projectGadaiDbContext.SaveChangesAsync();

            return Ok(userRequest);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> doUpdate([FromRoute] Guid id, User updateUserRequest)
        {
            var user = await _projectGadaiDbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.nama_user = updateUserRequest.nama_user;
            user.nomor_hp = updateUserRequest.nomor_hp;
            user.keterangan = updateUserRequest.keterangan;
            user.maks_transaksi = updateUserRequest.maks_transaksi;

            await _projectGadaiDbContext.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> doGetDetailUser([FromRoute] Guid id)
        {
            var user = await _projectGadaiDbContext.Users.FirstOrDefaultAsync(x => x.user_id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> doDelete([FromRoute] Guid id)
        {
            var user = await _projectGadaiDbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _projectGadaiDbContext.Users.Remove(user);
            await _projectGadaiDbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpGet]
        [Route("{search}")]
        public async Task<ActionResult<IEnumerable<User>>> doSearchUser(string search, string? searchId, string? searchName, 
             string? searchKet, string? searchHp)
        {
            
            try
            {
                IQueryable<User> query = _projectGadaiDbContext.Users;

                /*if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(e => e.nama_user.Contains(name));
                }*/

                if (!string.IsNullOrEmpty(searchId))
                {
                    query = query.Where(e => e.user_id.ToString().Contains(searchId));
                }
                if (!string.IsNullOrEmpty(searchName))
                {
                    query = query.Where(e => e.nama_user.Contains(searchName));
                }
                if (!string.IsNullOrEmpty(searchKet))
                {
                    query = query.Where(e => e.keterangan.Contains(searchKet));
                }
                if (!string.IsNullOrEmpty(searchHp))
                {
                    query = query.Where(e => e.nomor_hp.Contains(searchHp));
                }

                Console.WriteLine(query);
                return await query.ToListAsync();
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*public async Task<ActionResult<IEnumerable<User>>> doSearchUser(Guid? id, string? name, string? keterangan)
        {

        }*/
    }
}
