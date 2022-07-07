using System.Collections.Generic;
using IndependentExecution.Dto;

namespace IndependentExecution.Interfaces.Core
{
    public interface IExecutor
    {
        void ChangeProcessor(string processorId);
        void ChangeExecutor(string executorId);
        RunTimeParametersResponse GetRunTimeParameters(RunRequest runRequest);
        void RunAll();
        void CancelAll();
        void Run(RunRequest runRequest);
        void Cancel(IList<string> pluginIds);
        void Invalid(IList<string> pluginIds);
        void Stop(IList<string> pluginIds);
        /// <summary>
        /// 1- در پلاگین هایی مثل ذخیره موقت استفاده دارد
        /// 2- نتیجه اجرا به سمت انجین برمی گرداند تا بتوان از آن دیتاتیبل ساخت
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        IList<IBaseTable> GetResult(string pluginId);

        //Tabe haye dge chejori mishand?
        //melse gettable dataflow
    }
}
