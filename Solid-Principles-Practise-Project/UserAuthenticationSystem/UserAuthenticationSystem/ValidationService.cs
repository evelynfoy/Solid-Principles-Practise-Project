using System;
using System.Collections.Generic;
using System.Text;

namespace UserAuthenticationSystem;

public interface IValidationService
{
    public ValidationResult ValidateUser(User user);
}

public class ValidationService : IValidationService
{
    private readonly List<IValidationRule> _rules;

    public ValidationService(List<IValidationRule> rules)
    {
        _rules = rules;
    }

    public ValidationResult ValidateUser(User user)
    {
        ValidationResult finalResult = new ValidationResult();

        foreach (IValidationRule rule in _rules)
        {
            ValidationResult result = rule.Validate(user);
            finalResult.Errors.AddRange(result.Errors);
        }
        return finalResult;
    }
}
