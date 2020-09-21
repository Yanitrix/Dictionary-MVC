﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Service
{
    public interface IMeaningRepository : IRepository<Meaning>
    {
        public Meaning GetByID(int id);
    }
}