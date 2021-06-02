using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Datos;
using Datos.Models;

namespace Sistema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ComercioDbContext _context;
        private readonly IGenericRepository<Producto> _genericrepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductosController(ComercioDbContext context,IGenericRepository<Producto> genericRepository, IUnitOfWork unitOfWork)
        {
            _context=context;
            _genericrepository=genericRepository;
            _unitOfWork=unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<Producto>> GetProductosAsync(){
            return await _genericrepository.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Producto producto){
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _genericrepository.CreateAsync(producto);
            _unitOfWork.Commit();
            return Created("Created",new {Response= StatusCode(201)});
        }

    }
}