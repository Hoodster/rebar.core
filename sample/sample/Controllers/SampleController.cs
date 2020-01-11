using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rebar.Core.Command;
using Rebar.Core.Controller;
using Rebar.Core.Query;
using sample.Commands;
using sample.Queries;

namespace sample.Controllers
{
    [ApiController]
    public class SampleController : Controller
    {
        private ICommandDispatcher _commandDispatcher;
        private IQueryDispatcher _queryDispatcher;

        private const string _NAME = "Bob";

        public SampleController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            this._commandDispatcher = commandDispatcher;
            this._queryDispatcher = queryDispatcher;
        }

        //EXAMPLE COMMAND IMPLEMENTATION
        [HttpPost]
        public async Task<IActionResult> SampleCommand()
        {
            var command = new SampleCommand(_NAME);

            return await this.HandleRequest(_commandDispatcher, command);
        }

        //EXAMPLE QUERY IMPLEMENTATION
        [HttpGet]
        public async Task<IActionResult> SampleQuery()
        {
            var query = new SampleQuery(_NAME);

            return await this.HandleResponse<SampleQuery, SampleResponse>(_queryDispatcher, query);
        }
        
    }
}