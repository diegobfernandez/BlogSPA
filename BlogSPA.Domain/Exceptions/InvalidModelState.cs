using System;
using System.Collections.Generic;

namespace BlogSPA.Domain.Exceptions
{
    public class InvalidModelState : Exception
    {
        public InvalidModelState(string message, IEnumerable<string> details, Exception ex = null)
            : base(message, ex)
        {
            Details = details;
        }

        public InvalidModelState(string message, string detail, Exception ex = null)
            : base(message, ex)
        {
            Details = new List<string> { detail };
        }


        public IEnumerable<string> Details { get; set; }
    }
}
