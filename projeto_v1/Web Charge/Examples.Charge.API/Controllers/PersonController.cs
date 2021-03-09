using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;
using Examples.Charge.Application.Dtos;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController, IDisposable
    {
        private IPersonFacade _facade;
        private IMapper _mapper;

        public PersonController(IPersonFacade facade, IMapper mapper)
        {
            _mapper = mapper;
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDetailsResponse>> Get(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            var response = await _facade.GetById(id);
            if (response == null)
            {
                return NotFound();
            }

            return Response(response);
        }

        [HttpPost]
        [Route("phone")]
        public async Task<IActionResult> Post([FromBody] PersonPhoneRequest request)
        {
            var personPhoneDto = _mapper.Map<PersonPhoneDto>(request);
            await _facade.InsertPhoneAsync(personPhoneDto);

            return Response();
        }

        [HttpPut]
        [Route("{id}/phone")]
        public async Task<IActionResult> Update([FromBody] List<PersonPhoneUpdateRequest> request, int id)
        {
            var phonesDto = request.Select(x => _mapper.Map<PersonPhoneDto>(x)).ToList();
            await _facade.UpdatePhonesAsync(phonesDto, id);

            return Response();
        }

        [HttpDelete]
        [Route("phone/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }

            await _facade.RemovePhonesAsync(id);

            return Response();
        }

        public void Dispose()
        {
            _facade?.Dispose();
        }
    }
}
