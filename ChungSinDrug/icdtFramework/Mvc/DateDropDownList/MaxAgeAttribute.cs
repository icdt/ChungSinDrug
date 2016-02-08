﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace icdtFramework.Mvc
{
    public class MaxAgeAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly int _MaxAge;
        public MaxAgeAttribute(int maxAge)
        {
            _MaxAge = maxAge;
        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }

            var birthDate = Convert.ToDateTime(value);

            var age = DateTime.Now.Year - Convert.ToDateTime(value).Year;
            var m = DateTime.Now.Month - birthDate.Month;

            if (m < 0 || (m == 0 && DateTime.Now.Day < birthDate.Day))
            {
                age--;
            }

            return age <= _MaxAge
                ? null
                : new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata,
            ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ValidationType = "maxagevalidation",
                ErrorMessage = FormatErrorMessage(metadata.DisplayName)
            };

            rule.ValidationParameters["maxage"] = _MaxAge;
            yield return rule;
        }

    }
}