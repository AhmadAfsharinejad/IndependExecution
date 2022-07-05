using IndependentExecution.Dto;

namespace IndependentExecution.Interfaces.Core
{
    public interface IScenarioConfigurable
    {
        /// <summary>
        /// 1- تنظیمات پلاگین را تغییر میدهد
        /// 2- تنظیمات پلاگین هایی بعدی ممکن است تغییر کند
        /// 3- ممکن است لینکی حذف شود و به کلاینت خبر دهد
        /// </summary>
        /// <param name="changeConfigRequest"></param>
        void ChangeConfig(ChangeConfigRequest changeConfigRequest);
        IScenarioPluginConfig GetConfig(string nodeId);
    }
}
