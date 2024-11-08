using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Soenneker.Extensions.String;

namespace Soenneker.Extensions.List.IdNameValue;

/// <summary>
/// A collection of helpful List{IdNameValue} extension methods
/// </summary>
public static class ListIdNameValueExtension
{
    /// <summary>
    /// Checks if the list of <see cref="Dtos.IdNameValue.IdNameValue"/> objects contains an object with the specified Id.
    /// </summary>
    /// <param name="value">The list of <see cref="Dtos.IdNameValue.IdNameValue"/> objects. Must not be null.</param>
    /// <param name="id">The Id to check for.</param>
    /// <returns>True if the list contains an object with the specified Id; otherwise, false.</returns>
    [Pure]
    public static bool ContainsId(this List<Dtos.IdNameValue.IdNameValue> value, string id)
    {
        for (int i = 0; i < value.Count; i++)
        {
            if (value[i].Id == id)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Converts a list of <see cref="Dtos.IdNameValue.IdNameValue"/> objects to a list of their Ids.
    /// </summary>
    /// <param name="value">The list of <see cref="Dtos.IdNameValue.IdNameValue"/> objects. Must not be null.</param>
    /// <returns>A list of Ids from the provided <see cref="Dtos.IdNameValue.IdNameValue"/> objects.</returns>
    [Pure]
    public static List<string> ToListOfIds(this List<Dtos.IdNameValue.IdNameValue> value)
    {
        int count = value.Count;

        List<string> ids = new List<string>(count);

        for (int i = 0; i < count; i++)
        {
            ids.Add(value[i].Id);
        }

        return ids;
    }

    /// <summary>
    /// Converts a list of <see cref="Dtos.IdNameValue.IdNameValue"/> objects to an enumerable of their Ids.
    /// </summary>
    /// <param name="value">The list of <see cref="Dtos.IdNameValue.IdNameValue"/> objects. Must not be null.</param>
    /// <returns>An enumerable of Ids from the provided <see cref="Dtos.IdNameValue.IdNameValue"/> objects.</returns>
    [Pure]
    private static IEnumerable<string> ToEnumerableOfIds(this List<Dtos.IdNameValue.IdNameValue> value)
    {
        for (int i = 0; i < value.Count; i++)
        {
            yield return value[i].Id;
        }
    }

    /// <summary>
    /// Converts a list of <see cref="Dtos.IdNameValue.IdNameValue"/> objects to a list of their DocumentIds.
    /// </summary>
    /// <param name="value">The list of <see cref="Dtos.IdNameValue.IdNameValue"/> objects. Must not be null.</param>
    /// <returns>A list of DocumentIds from the provided <see cref="Dtos.IdNameValue.IdNameValue"/> objects.</returns>
    [Pure]
    public static List<string> ToListOfDocumentIds(this List<Dtos.IdNameValue.IdNameValue> value)
    {
        List<string> documentIds = new List<string>(value.Count);

        for (int i = 0; i < value.Count; i++)
        {
            documentIds.Add(value[i].Id.ToSplitId().DocumentId);
        }

        return documentIds;
    }

    /// <summary>
    /// Converts a list of <see cref="Dtos.IdNameValue.IdNameValue"/> objects to an enumerable of their DocumentIds.
    /// </summary>
    /// <param name="value">The list of <see cref="Dtos.IdNameValue.IdNameValue"/> objects. Must not be null.</param>
    /// <returns>An enumerable of DocumentIds from the provided <see cref="Dtos.IdNameValue.IdNameValue"/> objects.</returns>
    [Pure]
    public static IEnumerable<string> ToEnumerableOfDocumentIds(this List<Dtos.IdNameValue.IdNameValue> value)
    {
        for (int i = 0; i < value.Count; i++)
        {
            yield return value[i].Id.ToSplitId().DocumentId;
        }
    }

    /// <summary>
    /// Adds an <see cref="Dtos.IdNameValue.IdNameValue"/> object to the list if an object with the same Id does not already exist.
    /// </summary>
    /// <param name="value">The list of <see cref="Dtos.IdNameValue.IdNameValue"/> objects. Must not be null.</param>
    /// <param name="toAdd">The <see cref="Dtos.IdNameValue.IdNameValue"/> object to add. Must not be null.</param>
    public static void AddIfNotExists(this List<Dtos.IdNameValue.IdNameValue> value, Dtos.IdNameValue.IdNameValue toAdd)
    {
        for (int i = 0; i < value.Count; i++)
        {
            if (value[i].Id == toAdd.Id)
            {
                return;
            }
        }

        value.Add(toAdd);
    }

    /// <summary>
    /// Adds a range of <see cref="Dtos.IdNameValue.IdNameValue"/> objects to the list if objects with the same Ids do not already exist.
    /// </summary>
    /// <param name="value">The list of <see cref="Dtos.IdNameValue.IdNameValue"/> objects. Must not be null.</param>
    /// <param name="toAddRange">The range of <see cref="Dtos.IdNameValue.IdNameValue"/> objects to add. Must not be null.</param>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="value"/> or <paramref name="toAddRange"/> is null.</exception>
    public static void AddRangeIfNotExists(this List<Dtos.IdNameValue.IdNameValue> value, List<Dtos.IdNameValue.IdNameValue> toAddRange)
    {
        HashSet<string> existingIds = new HashSet<string>(value.Count);

        for (int i = 0; i < value.Count; i++)
        {
            existingIds.Add(value[i].Id);
        }

        for (int i = 0; i < toAddRange.Count; i++)
        {
            if (existingIds.Add(toAddRange[i].Id))
            {
                value.Add(toAddRange[i]);
            }
        }
    }
}
