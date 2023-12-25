using System.Diagnostics;

namespace ResourceInSight.Models;

public static class ResourceModel
{
    public static readonly PerformanceCounter CpuCounter = new("Processor", "% Processor Time", "_Total", true);
    public static readonly PerformanceCounter MemoryCounter = new("Memory", "% Committed Bytes In Use", true);
    public static readonly PerformanceCounter DiskCounter = new("LogicalDisk", "% Free Space", "_Total", true);

    private static float GetPerformanceCounterPercent(PerformanceCounter performanceCounter)
    {
        // repeat 3 times to get the correct value
        for (int i = 0; i < 3; i++)
            performanceCounter.NextValue();

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
        return GetPerformanceCounterPercent(DiskCounter);
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
