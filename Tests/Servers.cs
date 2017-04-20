using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public static class Servers
    {
        private static T getServers<T>() where T : new()
        {
            var servers = new T();
            return servers;
        }
        public static General general
        {
            get { return getServers<General>(); }
        }
    }
}
