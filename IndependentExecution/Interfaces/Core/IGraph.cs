using System.Collections.Generic;
using IndependentExecution.Dto;
using IndependentExecution.Interfaces.Plugin;

namespace IndependentExecution.Interfaces.Core
{
    public interface IGraph
    {
        /// <summary>
        /// 1- تنظیمات در سمت انجین ساخته شود
        /// 2- به کلاینت خبر دهد
        /// </summary>
        /// <param name="addPluginRequest"></param>
        AddPluginResponse AddPlugin(AddPluginRequest addPluginRequest);
        
        /// <summary>
        /// 1- لینک از میدا به مقصد اضافه میشود
        /// 2- تنظیمات پلاگین ورودی را به میدا بگوید
        /// 3- به کلاینت خبر دهد که لینک اضافه شد
        /// </summary>
        /// <param name="addLinkRequest"></param>
        void AddLink(AddLinkRequest addLinkRequest);
        
        /// <summary>
        /// 1- استیت پلاگین های بعدی را تغییر دهد و به کلاینت خبر دهد
        /// 2- تنظیمات پلاگین ها بعدی را آپدیت کند
        /// 3- لینک هایی متصل به پاتگین را پاک کند و به کلاینت خبر دهد
        /// </summary>
        /// <param name="pluginId"></param>
        void RemovePlugin(string pluginId);
        
        /// <summary>
        /// 1- استیت پلاگین های بعدی را تغییر دهد
        /// 2- تنظیمات پلاگین های بعدی را آپدیت کند
        /// 3- لینک را حذف کند و به کلاینت خبر دهد
        /// </summary>
        /// <param name="link"></param>
        void RemoveLink(ILink link);

        void MovePlugins(IList<MovePluginRequest> plugins);

        void ChangeNote(string pluginId, string? note);
        void ChangeLabel(string pluginId, string? label);
    }
}
