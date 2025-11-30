using FluentValidation;
using WebsiteBackend.Controllers;

namespace WebsiteBackend.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("用户名不能为空")
                .MaximumLength(50).WithMessage("用户名长度不能超过50个字符");
            
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("密码不能为空")
                .MinimumLength(6).WithMessage("密码长度不能少于6个字符")
                .MaximumLength(50).WithMessage("密码长度不能超过50个字符");
        }
    }
    
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("用户名不能为空")
                .MaximumLength(50).WithMessage("用户名长度不能超过50个字符");
            
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("邮箱不能为空")
                .EmailAddress().WithMessage("请输入有效的邮箱地址")
                .MaximumLength(100).WithMessage("邮箱长度不能超过100个字符");
            
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("密码不能为空")
                .MinimumLength(6).WithMessage("密码长度不能少于6个字符")
                .MaximumLength(50).WithMessage("密码长度不能超过50个字符");
            
            RuleFor(x => x.Role)
                .MaximumLength(50).WithMessage("角色长度不能超过50个字符")
                .When(x => !string.IsNullOrEmpty(x.Role));
        }
    }
}