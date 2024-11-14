using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using MyVideoResume.Data;

namespace MyVideoResume.Server.Controllers
{
    public partial class ExportDataContextController : ExportController
    {
        private readonly DataContext context;
        private readonly DataContextService service;

        public ExportDataContextController(DataContext context, DataContextService service)
        {
            this.service = service;
            this.context = context;
        }
    }
}
