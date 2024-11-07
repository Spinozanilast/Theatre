using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Theatre.Infrastructure.Data;

public static class OneToOneConfigurator
{
    public static void ConfigureOneToOneRelationship<TEntity, TRelatedEntity>(
        this EntityTypeBuilder<TEntity> modelBuilder,
        Expression<Func<TEntity, TRelatedEntity?>> navigationExpression,
        Expression<Func<TEntity, object?>> foreignKeyExpression)
        where TEntity : class
        where TRelatedEntity : class
    {
        modelBuilder
            .HasOne<TRelatedEntity>(navigationExpression)
            .WithOne()
            .HasForeignKey<TEntity>(foreignKeyExpression);
    }

    public static void ConfigureOneToOneRelationship<TEntity, TRelatedEntity>(
        this EntityTypeBuilder<TEntity> modelBuilder,
        string navigationPropertyName,
        Expression<Func<TEntity, object?>> foreignKeyExpression)
        where TEntity : class
        where TRelatedEntity : class
    {
        modelBuilder
            .HasOne<TRelatedEntity>(navigationPropertyName)
            .WithOne()
            .HasForeignKey<TEntity>(foreignKeyExpression);
    }
}