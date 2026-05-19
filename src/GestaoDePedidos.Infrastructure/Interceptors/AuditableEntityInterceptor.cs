using GestoDePedidos.Domain.Common;

namespace GestaoDePedidos.Infrastructure.Interceptors;

public sealed class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result
    )
    {
        SetCreateInfo(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new()
    )
    {
        SetCreateInfo(eventData.Context);
        SetUpdateInfo(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void SetCreateInfo(DbContext? context)
    {
        if (context is null)
            return;
        
        if (context.ChangeTracker.Entries().All(e => e.State != EntityState.Added))
            return;

        var createdEntities = context.ChangeTracker
            .Entries<IAuditableEntity>()
            .Where(e => e.State == EntityState.Added);

        foreach (var entry in createdEntities)
            entry.Entity.DataCriacao = DateTime.UtcNow;
    }
    
    private void SetUpdateInfo(DbContext? context)
    {
        if (context is null)
            return;
        
        if (context.ChangeTracker.Entries().All(e => e.State != EntityState.Modified))
            return;

        var createdEntities = context.ChangeTracker
            .Entries<IAuditableEntity>()
            .Where(e => e.State == EntityState.Modified);

        foreach (var entry in createdEntities)
            entry.Entity.DataAtualizacao = DateTime.UtcNow;
    }
}