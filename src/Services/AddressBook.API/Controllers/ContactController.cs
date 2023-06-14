using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AddressBook.Application.Contracts;
using AddressBook.Application.Exceptions;
using AddressBook.Application.Features.Contacts.Commands.CreateContact;
using AddressBook.Application.Features.Contacts.Commands.DeleteContact;
using AddressBook.Application.Features.Contacts.Commands.UpdateContact;
using AddressBook.Application.Features.Contacts.Queries.GetContacsFiltered;
using AddressBook.Application.Features.Contacts.Queries.GetContactById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AddressBook.API.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IMediator _mediator;

        public ContactController(
            IMediator mediator,
            ILogger<ContactController> logger
            )
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/values
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ContactSearchItemResultVm>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContactSearchItemResultVm>>> Get(
            string contact = "")
        {
            var query = new GetContacsFilteredQuery();
            query.Contact = contact;

            var searchResult = await _mediator.Send(query);
            return Ok(searchResult);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(typeof(ContactVm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactVm>> GetById(int id)
        {
            var query = new GetContactByIdQuery(id);            
            var contact = await _mediator.Send(query);
            if (contact == null)
                return NotFound();
            return Ok(contact);
        }

        // POST api/values
        [HttpPost(Name = "CreateContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateContact([FromBody] CreateContactCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}", Name = "UpdateContact")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateContact(int id, [FromBody] UpdateContactCommand command)
        {
            command.Id = id;

            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}", Name = "Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteContactCommand(id);
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

