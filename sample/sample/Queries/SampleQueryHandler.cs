using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Rebar.Core.Query;

namespace sample.Queries
{
    public class SampleQueryHandler : IQueryHandler<SampleQuery, SampleResponse>
    {

        public Task<SampleResponse> ExecuteAsync(SampleQuery query, CancellationToken cancellationToken)
        {
            var musicans = new List<string>() { "Bob Dylan", "Miles Davis", "Frank Sinatra" };
            var musican = musicans.FirstOrDefault(m => m.Contains(query.Name));

            return Task.FromResult(new SampleResponse(musican));
        }
    }
}
