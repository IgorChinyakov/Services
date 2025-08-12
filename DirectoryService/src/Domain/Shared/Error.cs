using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public class Error
    {
        public string Message { get; set; }

        private Error(string message) => Message = message;

        public static Error Create(string message)
            => new Error(message);
    }
}
