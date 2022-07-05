using System.Collections.Generic;
using IndependentExecution.Dto;

namespace IndependentExecution.Interfaces.Core
{
    public interface IExecutor
    {
        void RunAll();
        void CancelAll();
        void Run(RunRequest runRequest);
        void Cancel(IEnumerable<string> nodeIds);
        void Invalid(IEnumerable<string> nodeIds);
        void Stop(IEnumerable<string> nodeIds);
        /// <summary>
        /// 1- در پلاگین هایی مثل ذخیره موقت استفاده دارد
        /// 2- نتیجه اجرا به سمت انجین برمی گرداند تا بتوان از آن دیتاتیبل ساخت
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        IEnumerable<IBaseTable> GetResult(string nodeId);

        //Tabe haye dge chejori mishand?
        //melse gettable dataflow
    }
}
