using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pharmaceutical.Common.Models
{
    public class ErrorModel
    {
        public bool IsError { get; set; }
        public string Message { get; set; }      

    }
}
