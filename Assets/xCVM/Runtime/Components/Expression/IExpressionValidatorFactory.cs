namespace xCVM
{
    public interface IExpressionValidatorFactory
    {
        IExpressionValidator Create(xCVMObjectExpression expressionAvatar);
    }
}