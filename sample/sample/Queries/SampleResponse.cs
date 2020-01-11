using System;
using Rebar.Core.Query;

namespace sample.Queries
{
    public class SampleResponse : IQueryResponse
    {
        public string Person { get; set; }

        public SampleResponse(string person)
        {
            this.Person = person;
        }
    }
}
