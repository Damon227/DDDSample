using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Options;

namespace DDDSample.Data
{
    public class DataOptions : IOptions<DataOptions>
    {
        DataOptions IOptions<DataOptions>.Value => this;

        public string ConnectionString { get; set; }
    }
}
