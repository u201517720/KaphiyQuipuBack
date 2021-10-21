using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace KaphiyQuipu.Blockchain.Facade
{
    public partial class ContractFacade : IContractFacade
    {
        protected IConfiguration Config;
        protected readonly ILogger Logger;
        protected IMemoryCache Cache;
        private readonly object _locker = new object();
        public ContractFacade(IConfiguration config, ILogger<ContractFacade> logger, IMemoryCache cache)
        {
            Config = config;
            Logger = logger;
            Cache = cache;
        }
    }
}
