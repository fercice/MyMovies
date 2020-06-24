using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MyMovies.Presentation.Api.Extensions
{
    public static class HttpStatusCodeExtensions
    {
        public static int ToInt(this HttpStatusCode httpStatusCode)
            => (int)httpStatusCode;
    }
}
