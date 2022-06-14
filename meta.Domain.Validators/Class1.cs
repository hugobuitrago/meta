using System;
using System.Collections.Generic;
using System.Net;

namespace meta.Domain.Validators
{
    public class DomainResult
    {
        public ICollection<string> ApplicationErros { get; }
        public Dictionary<string, string[]> ModelErros { get; }
        public bool Fail { get; }
        public bool Success { get; }
        public HttpStatusCode Status { get; }

        public static DomainResult<T> Failure<T>(string error, Dictionary<string, string[]> modelErros = null, HttpStatusCode status = HttpStatusCode.BadGateway);
        public static DomainResult Failure(string error, Dictionary<string, string[]> modelErros = null, HttpStatusCode status = HttpStatusCode.BadGateway);
        public static DomainResult<T> Failure<T>(ICollection<string> applicationErros, Dictionary<string, string[]> modelErros = null, HttpStatusCode status = HttpStatusCode.BadGateway);
        public static DomainResult Failure(ICollection<string> applicationErros, Dictionary<string, string[]> modelErros = null, HttpStatusCode status = HttpStatusCode.BadGateway);
        public static DomainResult Ok();
        public static DomainResult Ok(HttpStatusCode status);
        public static DomainResult<T> Ok<T>(T value, HttpStatusCode status = HttpStatusCode.OK);
    }

    public class DomainResult<T>
    {
        public ICollection<string> ApplicationErros { get; }
        public Dictionary<string, string[]> ModelErros { get; }
        public HttpStatusCode Status { get; }
        public bool Success { get; }
        public T Value { get; }
    }
}
