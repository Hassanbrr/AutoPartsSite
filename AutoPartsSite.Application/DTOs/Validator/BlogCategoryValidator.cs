using FluentValidation;

namespace AutoPartsSite.Application.DTOs.Validator;

public class BlogCategoryValidator : AbstractValidator<BlogCategoryDto>
{
    public BlogCategoryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("نام نمی‌تواند خالی باشد.")
            .MaximumLength(100).WithMessage("حداکثر طول نام 100 کاراکتر است.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("حداکثر طول توضیحات 1000 کاراکتر است.");

        RuleFor(x => x.ParentCategoryId)
            .Must(id => id == null || id > 0).WithMessage("شناسه دسته والد نامعتبر است.");
    }
}