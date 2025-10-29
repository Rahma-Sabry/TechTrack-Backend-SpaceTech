using System.Reflection;

namespace TechPathNavigator.Mappers
{
    public static class GenericMapper
    {
        // Map Entity -> DTO
        public static TDto ToDto<TEntity, TDto>(this TEntity entity) where TDto : new()
        {
            var dto = new TDto();
            var entityProps = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var dtoProps = typeof(TDto).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var dtoProp in dtoProps)
            {
                var entityProp = entityProps.FirstOrDefault(p => p.Name == dtoProp.Name && p.PropertyType == dtoProp.PropertyType);
                if (entityProp != null)
                {
                    dtoProp.SetValue(dto, entityProp.GetValue(entity));
                }
            }

            return dto;
        }

        // Map DTO -> Entity
        public static TEntity ToEntity<TEntity, TDto>(this TDto dto, int? id = null) where TEntity : new()
        {
            var entity = new TEntity();
            var dtoProps = typeof(TDto).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var entityProps = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var entityProp in entityProps)
            {
                if (entityProp.Name == "Id" && id.HasValue)
                {
                    entityProp.SetValue(entity, id.Value);
                    continue;
                }

                var dtoProp = dtoProps.FirstOrDefault(p => p.Name == entityProp.Name && p.PropertyType == entityProp.PropertyType);
                if (dtoProp != null)
                {
                    entityProp.SetValue(entity, dtoProp.GetValue(dto));
                }
            }

            return entity;
        }
    }
}
