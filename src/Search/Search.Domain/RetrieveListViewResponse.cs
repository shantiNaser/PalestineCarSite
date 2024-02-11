using System;
using static Sieve.Extensions.MethodInfoExtended;

namespace Search.Domain;

/// <summary>
/// Retrieve readOnly data response
/// </summary>
public class RetrieveListViewResponse<T>
{
    /// <summary>
    /// Retrieved Entities
    /// </summary>
    public List<T> Entities { get; set; }

    /// <summary>
    /// Total count
    /// </summary>
    public long TotalCount { get; set; } = -1;
}

