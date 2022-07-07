using System.Collections.Generic;
using IndependentExecution.Dto;

namespace IndependentExecution.Interfaces.Core
{
    public interface IExecutor
    {
        void ChangeProcessor(ProcessorId processorId);
        void ChangeExecutor(ExecutorId executorId);
        RunTimeParametersResponse GetRunTimeParameters(RunRequest runRequest);
        void RunAll();
        void CancelAll();
        void Run(RunRequest runRequest);
        void Cancel(IList<PluginId> pluginIds);
        void Invalid(IList<PluginId> pluginIds);
        void InvalidAll();
        void Stop(IList<PluginId> pluginIds);
        void StopAll();
        
        /// <summary>
        /// 1- در پلاگین هایی مثل ذخیره موقت استفاده دارد
        /// 2- نتیجه اجرا به سمت انجین برمی گرداند تا بتوان از آن دیتاتیبل ساخت
        /// </summary>
        /// <param name="pluginId"></param>
        /// <returns></returns>
        IList<IBaseTable> GetResult(PluginId pluginId);
    }
}
