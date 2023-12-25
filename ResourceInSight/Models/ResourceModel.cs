using System.Diagnostics;

namespace ResourceInSight.Models;

public static class ResourceModel
{
    private static readonly PerformanceCounter CpuCounter = new("Processor", "% Processor Time", "_Total", true);
    private static readonly PerformanceCounter MemoryCounter = new("Memory", "% Committed Bytes In Use", true);
    private static readonly PerformanceCounter DiskCounter = new("LogicalDisk", "% Idle Time", "_Total", true);

    static ResourceModel()
    {
        CpuCounter.NextValue();
        MemoryCounter.NextValue();
        DiskCounter.NextValue();
    }

    private static float GetPerformanceCounterPercent(PerformanceCounter performanceCounter)
    {
        return performanceCounter.NextValue();
    }

    private static float GetCpuPercent()
    {
        return GetPerformanceCounterPercent(CpuCounter);
    }

    private static float GetMemoryPercent()
    {
        return GetPerformanceCounterPercent(MemoryCounter);
    }

    private static float GetDiskPercent()
    {
        return 100 - GetPerformanceCounterPercent(DiskCounter);
    }

    public static float GetResourcePercent(ResourceType resourceType)
    {
        return resourceType switch
        {
            ResourceType.CPU => GetCpuPercent(),
            ResourceType.Memory => GetMemoryPercent(),
            ResourceType.Disk => GetDiskPercent(),
            _ => throw new ArgumentException("Invalid resource type")
        };
    }
}
