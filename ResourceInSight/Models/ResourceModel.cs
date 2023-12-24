using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceInSight.Models;

internal class ResourceModel(ResourceType resourceType) : IResourceModel
{
    public ResourceType ResourceType { get; } = resourceType;

    public decimal GetResourcePercent()
    {
        PerformanceCounter performanceCounter = new("Memory", "Available MBytes");
        return performanceCounter.RawValue;
    }
}
