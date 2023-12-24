using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;

namespace ResourceInSight.Models;

internal interface IResourceModel
{
    public ResourceType ResourceType { get; }

    public decimal GetResourcePercent();
}
