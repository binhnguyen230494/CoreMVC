﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
namespace CoreMVCViewModels.System.Users
{
    public class LoginRequestValidator
    {
        public LoginRequestValidator()
        {
            /*RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password is at least 6 characters");*/
        }
    }
}