﻿using Sinfonica.Web.Areas.Admin.Data;
using Sinfonica.Web.Areas.User.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.User.Data.Repositories
{
    public class EventosRepository : GenericRepository<Evento>, IEventosRepository

    {
        private readonly DataContext context;

        public EventosRepository(DataContext context) : base(context)
        {
            this.context = context;
        }


    }
}
