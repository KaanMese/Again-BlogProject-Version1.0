using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class JsonResponce
    {
        public OperationStatu Code { get; set; }
        public string Message { get; set; }
        public string TempProp { get; set; }
    }
    public enum OperationStatu
    {
        Success,
        Error,
        EmailError,
        ClientSideError
    }
}
