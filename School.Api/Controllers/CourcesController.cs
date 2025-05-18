using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.Handlers.CourseHandelers.Commands_.CreateCourse;
using School.Application.Handlers.CourseHandelers.Commands_.DeleteCourse;
using School.Application.Handlers.CourseHandelers.Queries.GetAll;
using School.Application.Handlers.CourseHandelers.Queries.GetById;
using School.Domain.Entities;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourcesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CourcesController(IMediator mediator,IMapper mapper)
        {
          _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
          var cources= await _mediator.Send(new GetAllCourseQuery());
         
            return Ok(cources);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cource = await _mediator.Send(new GetByIdCourseQuery() { Id=id});
            if (cource == null) return NotFound($"Course Id {id} not found");
            return Ok(cource);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCourseCommand model)
        {
            
                var course =await _mediator.Send( model);
                 return Ok(course);
       
           
        }

        [HttpDelete]
        public async Task<IActionResult> Delete( int id)
        {

            var result = await _mediator.Send(new DeleteCourseCommand() { id=id});
            return Ok(result);


        }
    }
}
