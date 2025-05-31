using FluentValidation;

namespace AutoPartsSite.Application.DTOs.Validator;

public class BlogPostValidator : AbstractValidator<BlogPostDto>
{
    public BlogPostValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("عنوان الزامی است.")
            .MaximumLength(200).WithMessage("عنوان نمی‌تواند بیش از 200 کاراکتر باشد.");

        RuleFor(x => x.Summary)
            .NotEmpty().WithMessage("خلاصه الزامی است.")
            .MaximumLength(500).WithMessage("خلاصه نمی‌تواند بیش از 500 کاراکتر باشد.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("محتوا الزامی است.");
 
        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("دسته‌بندی معتبر نیست.");
    }
}   
