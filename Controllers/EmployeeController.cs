using AutoMapper;
using CompanyApp.DTOs;
using CompanyApp.Model;
using CompanyApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        //mjujthgdfdhgjhsgfjhg,hjsrgfjhddfgjhhgfsv
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _repo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeReadDTO>>(employees));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var emp = await _repo.GetByIdAsync(id);
            if (emp == null) return NotFound();
            return Ok(_mapper.Map<EmployeeReadDTO>(emp));
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateDTO dto)
        {
            var emp = _mapper.Map<Employee>(dto);
            var created = await _repo.AddAsync(emp);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, _mapper.Map<EmployeeReadDTO>(created));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeUpdateDTO dto)
        {
            if (id != dto.Id) return BadRequest();
            var emp = _mapper.Map<Employee>(dto);
            var updated = await _repo.UpdateAsync(emp);
            return Ok(_mapper.Map<EmployeeReadDTO>(updated));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
