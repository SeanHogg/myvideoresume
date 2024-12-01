using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Radzen;

using MyVideoResume.Data;

namespace MyVideoResume.Services;

public partial class DataContextService
{
    public DataContext Context
    {
        get
        {
            return context;
        }
    }

    private readonly DataContext context;
    private readonly NavigationManager navigationManager;

    public DataContextService(DataContext context, NavigationManager navigationManager)
    {
        this.context = context;
        this.navigationManager = navigationManager;
    }

    public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

    public void ApplyQuery<T>(ref IQueryable<T> items, Query query = null)
    {
        if (query != null)
        {
            if (!string.IsNullOrEmpty(query.Filter))
            {
                if (query.FilterParameters != null)
                {
                    items = items.Where(query.Filter, query.FilterParameters);
                }
                else
                {
                    items = items.Where(query.Filter);
                }
            }

            if (!string.IsNullOrEmpty(query.OrderBy))
            {
                items = items.OrderBy(query.OrderBy);
            }

            if (query.Skip.HasValue)
            {
                items = items.Skip(query.Skip.Value);
            }

            if (query.Top.HasValue)
            {
                items = items.Take(query.Top.Value);
            }
        }
    }

}