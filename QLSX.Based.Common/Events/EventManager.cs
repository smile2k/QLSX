using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSX.Based.Common.Events
{

    public class EventPayload<T>
    {
        public string Id { get; set; }
        public T Data { get; set; }
    }

    public class GenericEvent<T> : PubSubEvent<EventPayload<T>>
    {
    }
  
}
