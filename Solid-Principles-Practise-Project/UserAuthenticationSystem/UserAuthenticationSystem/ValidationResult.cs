using System;
using System.Collections.Generic;
using System.Text;

namespace UserAuthenticationSystem;

public class ValidationResult
{
    public List<string> Errors { get; set; } = new List<string>();
    public bool IsValid => !Errors.Any();
}

