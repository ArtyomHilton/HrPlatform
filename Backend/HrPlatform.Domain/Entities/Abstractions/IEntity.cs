using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrPlatform.Domain.Entities.Abstractions;

/// <summary>
/// Базовая сущность.
/// </summary>
/// <typeparam name="T">Любой тип данных</typeparam>
public interface IEntity<T>
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    T Id { get; set; }

    /// <summary>
    /// Версия записи в БД.
    /// </summary>
    Guid Version { get; set; }
}
