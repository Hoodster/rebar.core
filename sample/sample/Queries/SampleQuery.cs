using System;
using Rebar.Core.Query;

namespace sample.Queries
{
    public class SampleQuery : IQuery<SampleResponse>
    {
        public string Name { get; set; }

        public SampleQuery(string name)
        {
            this.Name = name;
        }
    }
}
