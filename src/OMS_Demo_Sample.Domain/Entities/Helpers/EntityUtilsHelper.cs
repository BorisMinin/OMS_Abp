using System;
using System.Diagnostics.CodeAnalysis;

namespace OMS_Demo_Sample.Entities.Helpers
{
    public static class EntityUtilsHelper
    {
        public static void SetEntityName([NotNull]string entityName)
        {
            if (string.IsNullOrWhiteSpace(entityName))
                throw new Exception("Value cannot be null or whitespace");
        }
    }
}