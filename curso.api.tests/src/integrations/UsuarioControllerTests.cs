using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace curso.api.tests.src.integrations.Controllers
{
    public class UsuarioControllerTests
    {
        public readonly WebApplicationFactory<Startup> _factory;
        {
            public UsuarioControllerTests(WebApplicationFactory<Startup> factory)
            {
                _factory = factory;
            }
            
        }
    }
}