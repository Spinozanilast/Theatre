namespace Theatre.CqrsMediator.Special;

public static class GenericTypeMaker
{
    public static Type FillGenericInterfaceWithTwoParameters(this Type baseInterfaceType, Type firstParam,
        Type? secondParam)
    {
        if (baseInterfaceType is { IsInterface: false, IsGenericType: false })
        {
            throw new ArgumentException("TBaseInterfaceType must be an interface with generic parameters");
        }

        return secondParam is null
            ? baseInterfaceType.MakeGenericType(firstParam)
            : baseInterfaceType.MakeGenericType(firstParam, secondParam);
    }
}