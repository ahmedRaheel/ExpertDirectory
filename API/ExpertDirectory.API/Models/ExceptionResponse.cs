using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertDirectory.API.Models
{
    /// <summary>
    ///   ExceptionResponse
    /// </summary>
    public class ExceptionResponse
    {
        public string Message { set; get; }
        public DateTime ResponseDateTime { get; set; }
        public int ResponseCode { get; set; }
    }
}
