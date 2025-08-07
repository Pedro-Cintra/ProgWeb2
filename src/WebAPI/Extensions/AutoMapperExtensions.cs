using AutoMapper;

namespace WebAPI.Extensions;

public static class AutoMapperExtensions
{
    public static void IgnoreNullsOnSource<T, U>(this IMappingExpression<T, U> expression)
    {
        expression.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
