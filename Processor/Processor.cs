using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor
{
    public class Processor<T, TRequest>
    {
        protected Func<TRequest, bool> Check;
        protected Func<TRequest, T> Register;
        protected Action<T> Save;

        public Processor(Func<TRequest, bool> Check, Func<TRequest, T> Register, Action<T> Save)
        {
            this.Check = Check;
            this.Register = Register;
            this.Save = Save;
        }

        public T Process(TRequest request)
        {
            if (!Check(request))
                throw new ArgumentException();
            var result = Register(request);
            Save(result);
            return result;
        }
    }
}
