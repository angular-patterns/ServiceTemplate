using Autofac;
using Business;
using Business.Mutations.Models;
using Business.Mutations.RuleSets;
using Business.Queries;
using Business.Queries.RuleSets;
using Data;
using DynamicRules.Core;
using DynamicRules.Interfaces;
using Entities;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Schemas;
using System;
using System.Linq;

namespace Container
{

    public class AutofacModule : Module
    {
        public DbContextOptions<DataContext> Options { get; }

        public AutofacModule(DbContextOptions<DataContext> options)
        {
            Options = options;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new DataContext(Options));
            builder.RegisterType<RootSchema>();
            builder.RegisterType<RootQuery>();
            builder.RegisterType<RootMutation>();
            builder.RegisterType<ModelQuery>();
            builder.RegisterType<RuleSetQuery>();
            builder.RegisterType<CreateRuleSetMutation>();
            builder.RegisterType<CreateModelMutation>();
            builder.RegisterType<ModelService>();
            builder.RegisterType<RuleSetService>();
            builder.RegisterType<ReviewTypeService>();
            builder.RegisterType<ReviewService>();
            builder.RegisterType<ReviewRunner>();
            builder.RegisterType<JsonSchemaService>();
            builder.RegisterType<ContextService>();
            builder.RegisterType<ReviewContextService>();

            builder.RegisterType<CSharpCompiler>().As<ICSharpCompiler>();
            builder.RegisterType<JsonSchemaConverter>().As<IJsonSchemaConverter>();
            builder.RegisterType<JsonSchemaParser>().As<IJsonSchemaParser>();
            builder.RegisterType<JsonValidator>().As<IJsonValidator>();
            builder.RegisterType<RuleEvaluator>().As<IRuleEvaluator>();
            builder.RegisterType<ServiceLocator>();
          

        }

        

    }





}








