﻿using Api.Dto;
using Dictionary_MVC.Data;
using Dictionary_MVC.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Service
{
    
    public class LanguageService : ServiceBase<Language>, ILanguageService
    {
        public LanguageService(DatabaseContext context, AbstractValidator<Language> validator):base(context, validator) { }

        public Language GetByName(string name)
        {
            return repo.Find(name);
        }

        public override bool IsReadyToAdd(Language entity)
        {
            var name = entity.Name;
            if (context.Languages.Any(x => x.Name == name))
            {
                ValidationDictionary.AddError(nameof(entity.Name), $"Language with name {name} already exists in the database");
                return false;
            }

            return true;
        }

        public override bool IsReadyToUpdate(Language entity)
        {
            return false;
        }

    }
}
