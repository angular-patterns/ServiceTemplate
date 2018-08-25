using Business.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ServiceLocator
    {
        public static ServiceLocator Instance 
            {
                get; set;
            }
        public IServiceProvider Provider { get; }
        public ServiceLocator(IServiceProvider provider)
        {
            Provider = provider;
            Instance = this;
        }

        public static ContextService ContextService
        {
            get
            {
                return Instance.GetService<ContextService>();
            }
        }
        public static ModelService ModelService
        {
            get
            {
                return Instance.GetService<ModelService>();
            }
        }
        public static ReviewContextService ReviewContextService
        {
            get
            {
                return Instance.GetService<ReviewContextService>();
            }
        }

        public static ReviewRuleTypeService ReviewRuleTypeService
        {
            get
            {
                return Instance.GetService<ReviewRuleTypeService>();
            }
        }

        public static ReviewService ReviewService
        {
            get
            {
                return Instance.GetService<ReviewService>();
            }
        }

        public static RuleSetService RuleSetService
        {
            get
            {
                return Instance.GetService<RuleSetService>();
            }
        }
        public static JsonSchemaService JsonSchemaService
        {
            get
            {
                return Instance.GetService<JsonSchemaService>();
            }
        }
        public T GetService<T>()
        {
            return (T)Provider.GetService(typeof(T));
        }
    }
}
