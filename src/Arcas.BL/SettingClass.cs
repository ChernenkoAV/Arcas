using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Arcas.Settings;

#region Связка TFS-DB

public class TFSDBList : BindingList<TfsDbLink>
{
    private TFSDBList(List<TfsDbLink> lfd)
        : base(lfd)
    { }

    public static implicit operator TFSDBList(List<TfsDbLink> lfd) => new(lfd);

    public static implicit operator List<TfsDbLink>(TFSDBList tdbl) => new(tdbl);
}

#endregion
public class VerDB
{
    public long VersionBD { get; set; }
}

public class TfsDbLink
{
    public String Name { get; set; }
    public Uri ServerUri { get; set; }
    public String ServerPathToSettings { get; set; }
    public FormatBinaryData FormatBinary { get; set; }
}

/// <summary>
/// Форматировние бинарных данных
/// </summary>
public class FormatBinaryData
{
    /// <summary>
    /// Префикс к бинарному представлению
    /// </summary>
    public String Prefix { get; set; }
    /// <summary>
    /// Форматирование байта
    /// </summary>
    public String FormatByte { get; set; }
}

public class UpdateDbSetting
{
    /// <summary>
    /// Путь на сервере СКВ, куда складываются скрипты
    /// </summary>
    public String ServerPathScripts { get; set; }

    /// <summary>
    /// Полное имя типа (с пространством имен) коннекшена
    /// </summary>        
    public String TypeConnectionFullName { get; set; }

    /// <summary>
    /// Бинарный образ сборки, содержащей тип конекшена к БД, который реализует DbConnection. Null для SqlConnection
    /// </summary>
#pragma warning disable CA1819 // Свойства не должны возвращать массивы
    public byte[] AssemplyWithImplementDbConnection { get; set; }
#pragma warning restore CA1819 // Свойства не должны возвращать массивы

    /// <summary>
    /// Бинарные образы сборок, от которых зависит основная сборка с ркализацией DbConnection. 
    /// </summary>
    public List<byte[]> LinkedAssemblyDbConnection { get; set; }

    /// <summary>
    /// Строка соединения с БД для накатки (модельная БД)
    /// </summary>
    public String ConnectionStringModelDb { get; set; }

    /// <summary>
    /// Часть скрипта, идущая перед телом версии при наличии транзакции
    /// </summary>
    public String ScriptPartBeforeBodyWithTran { get; set; }

    /// <summary>
    /// Часть скрипта, идущая после тела версии при наличии транзакции
    /// </summary>
    public String ScriptPartAfterBodyWithTran { get; set; }

    /// <summary>
    /// Формат версии
    /// </summary>
    public string FormatVersion { get; set; }
    /// <summary>
    /// Скрипт измемения значения версии БД
    /// </summary>
    public string ScriptUpdateVer { get; set; }

    /// <summary>
    /// Настройки для форматировния бинарных данных для вставки в текст скрипта
    /// </summary>
    public FormatBinaryData FormatBinary { get; set; }
}
