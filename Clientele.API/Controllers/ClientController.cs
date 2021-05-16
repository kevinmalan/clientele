using Clientele.Core.Dtos;
using Clientele.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clientele.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clients = await _clientService.GetClientsAsync();

            return Ok(clients);
        }

        [HttpGet("file/csv")]
        public async Task<IActionResult> GetCsv()
        {
            var clients = await _clientService.GetClientsAsync();
            var headers = _clientService.ToCsvheader(clients);
            var body = _clientService.ToCsvBody(clients);
            var content = headers + Environment.NewLine + body;
            return File(
                Encoding.UTF8.GetBytes(content),
                "text/csv",
                $"Clients Export {DateTimeOffset.UtcNow:dd-MMMM-yyyy}.csv"
            );
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClientDto createClientDto)
        {
            await _clientService.CreateClientAsync(createClientDto);

            return Ok();
        }
    }
}