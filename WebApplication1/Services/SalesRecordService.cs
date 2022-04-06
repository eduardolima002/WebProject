﻿using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Services
{
    public class SalesRecordService
    {
        private readonly WebApplication1Context _context;

        public SalesRecordService(WebApplication1Context context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result.Include(x => x.Seller).Include(x => x.Seller.Department).OrderByDescending(x => x.Date).ToListAsync();
        }


    }
}