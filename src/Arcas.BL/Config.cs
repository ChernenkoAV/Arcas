using System;
using System.Collections.Generic;
using Arcas.Settings;
using Cav.Configuration;

namespace Arcas
{
#pragma warning disable CS0618 // Тип или член устарел
    public class Config : ProgramSettingsBase<Config>
#pragma warning restore CS0618 // Тип или член устарел
    {
        /// <summary>
        /// Последняя использованная конфигурация при накатке БД
        /// </summary>
        public String SelestedTFSDB { get; set; }

        /// <summary>
        /// Настройки накатки + сохранение состояние ввода.
        /// </summary>
        public UpdaterDbSetting UpdaterDb { get; set; }

        /// <summary>
        /// Последние успешно использованные настройки при работе с Mq
        /// </summary>
        public MqSettingT MqSets { get; set; }
        /// <summary>
        /// Коллекция настроек связок TFS-DB
        /// </summary>
        public List<TfsDbLink> TfsDbSets { get; set; }

        /// <summary>
        /// Настройки для генаратора из wsdl и xsd
        /// </summary>
        public WsdlXsdGenSettingT WsdlXsdGenSetting { get; set; }
    }

    /// <summary>
    /// Последняя использованная конфигурация при накатке БД
    /// </summary>
    public class UpdaterDbSetting
    {
        /// <summary>
        /// Коллекция настроек связок TFS-DB
        /// </summary>
        public List<TfsDbLink> TfsDbSets { get; set; }
        /// <summary>
        /// Последняя использованная конфигурация при накатке БД
        /// </summary>
        public String SelestedTFSDB { get; set; }
        /// <summary>
        /// Комментарий к последнему скрипту
        /// </summary>
        public String Comment { get; set; }
        /// <summary>
        /// Последний скрипт
        /// </summary>
        public String Script { get; set; }
        /// <summary>
        /// Последние привязанные таски
        /// </summary>
        public List<int> Tasks { get; set; }
    }

    public struct WsdlXsdGenSettingT
    {
        public String Wsdl_PathToWsdl { get; set; }
        public String Wsdl_PathToSaveFile { get; set; }
        public String Wsdl_Namespace { get; set; }
        public string Xsd_PathToXsd { get; set; }
        public string Xsd_PathToSaveFile { get; set; }
        public string Xsd_Namespace { get; set; }
    }

    public struct MqSettingT
    {
        public string Host { get; set; }
        public string ManagerName { get; set; }
        public string ChannelName { get; set; }
        public string QueueName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
