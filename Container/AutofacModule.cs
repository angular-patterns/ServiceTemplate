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
using Schemas.Resolvers;
using Schemas.Resolvers.ForContext;
using Schemas.Resolvers.ForContextItem;
using Schemas.Resolvers.ForReview;
using Schemas.Resolvers.ForRoot;
using System;
using System.Linq;
using Business.Services;
using Schemas.Resolvers.ForReviewType;
using Schemas.Resolvers.ForRuleSetType;

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
            builder.RegisterType<ReviewRuleTypeService>();
            builder.RegisterType<ReviewService>();
            builder.RegisterType<ReviewRunner>();
            builder.RegisterType<JsonSchemaService>();
            builder.RegisterType<ContextService>();
            builder.RegisterType<ReviewContextService>();

            builder.RegisterType<ModelsResolver>();
            builder.RegisterType<RuleSetsResolver>();
            builder.RegisterType<ReviewsResolver>();
            builder.RegisterType<ContextsResolver>();
            builder.RegisterType<ReviewContextsResolver>();
            builder.RegisterType<ModelResolver>();
            builder.RegisterType<ContextResolver>();
            builder.RegisterType<ContextItemsResolver>();
            builder.RegisterType<ReviewContextResolver>();
            builder.RegisterType<ReviewRulesResolver>();
            builder.RegisterType<RuleSetResolver>();
            builder.RegisterType<ReviewContextItemsResolver>();
            builder.RegisterType<ReviewRuleTypesResolver>();
            builder.RegisterType<Schemas.Resolvers.ForReviewContext.ContextResolver>();
            builder.RegisterType<Schemas.Resolvers.ForReviewContextItem.ModelResolver>();
            builder.RegisterType<Schemas.Resolvers.ForReviewContextItem.ReviewContextResolver>();
            builder.RegisterType<Schemas.Resolvers.ForReviewRuleType.RuleSetResolver>();
            builder.RegisterType<Schemas.Resolvers.ForReviewRule.ReviewRuleTypeResolver>();
            builder.RegisterType<Schemas.Resolvers.ForModel.RuleSetsResolver>();



            builder.RegisterType<CSharpCompiler>().As<ICSharpCompiler>();
            builder.RegisterType<JsonSchemaConverter>().As<IJsonSchemaConverter>();
            builder.RegisterType<JsonSchemaParser>().As<IJsonSchemaParser>();
            builder.RegisterType<JsonValidator>().As<IJsonValidator>();
            builder.RegisterType<RuleEvaluator>().As<IRuleEvaluator>();
            builder.RegisterType<ServiceLocator>();
          

        }

        

    }





}








