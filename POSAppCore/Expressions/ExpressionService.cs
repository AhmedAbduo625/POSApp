
using System.Linq.Expressions;
using System.Reflection;

namespace POSAppCore
{
    public static class ExpressionService
    {
        public static T GetProperty<T>(this Expression<Func<T>> exp) => exp.Compile().Invoke();

        public static void SetProperty<T>(this Expression<Func<T>> exp, T value)
        {
            var lambdaExpression = exp as LambdaExpression;
            var memberExpression = lambdaExpression.Body as MemberExpression;

            var propertInfo = (PropertyInfo)memberExpression.Member;
            var target = Expression.Lambda(memberExpression.Expression).Compile().DynamicInvoke();

            propertInfo.SetValue(target, value);

        }
    }
}
