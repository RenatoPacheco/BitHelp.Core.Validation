using System.ComponentModel.DataAnnotations;

namespace BitHelp.Core.Validation {

    public enum ValidationCode {

        [Display(Name = "None")]
        None = 0,

        // 1xx Informational
        [Display(Name = "Continue")]
        Continue = 100,
        [Display(Name = "Switching Protocols")]
        SwitchingProtocols = 101,
        [Display(Name = "Processing")]
        Processing = 102,
        [Display(Name = "Early Hints")]
        EarlyHints = 103,

        // 2xx Success
        [Display(Name = "OK")]
        OK = 200,
        [Display(Name = "Created")]
        Created = 201,
        [Display(Name = "Accepted")]
        Accepted = 202,
        [Display(Name = "Non-Authoritative Information")]
        NonAuthoritativeInformation = 203,
        [Display(Name = "No Content")]
        NoContent = 204,
        [Display(Name = "Reset Content")]
        ResetContent = 205,
        [Display(Name = "Partial Content")]
        PartialContent = 206,
        [Display(Name = "Multi-Status")]
        MultiStatus = 207,
        [Display(Name = "Already Reported")]
        AlreadyReported = 208,
        [Display(Name = "IM Used")]
        IMUsed = 226,

        // 3xx Redirection
        [Display(Name = "Multiple Choices")]
        MultipleChoices = 300,
        [Display(Name = "Moved Permanently")]
        MovedPermanently = 301,
        [Display(Name = "Found")]
        Found = 302,
        [Display(Name = "See Other")]
        SeeOther = 303,
        [Display(Name = "Not Modified")]
        NotModified = 304,
        [Display(Name = "Use Proxy")]
        UseProxy = 305,
        [Display(Name = "Temporary Redirect")]
        TemporaryRedirect = 307,
        [Display(Name = "Permanent Redirect")]
        PermanentRedirect = 308,

        // 4xx Client Error
        [Display(Name = "Bad Request")]
        BadRequest = 400,
        [Display(Name = "Unauthorized")]
        Unauthorized = 401,
        [Display(Name = "Payment Required")]
        PaymentRequired = 402,
        [Display(Name = "Forbidden")]
        Forbidden = 403,
        [Display(Name = "Not Found")]
        NotFound = 404,
        [Display(Name = "Method Not Allowed")]
        MethodNotAllowed = 405,
        [Display(Name = "Not Acceptable")]
        NotAcceptable = 406,
        [Display(Name = "Proxy Authentication Required")]
        ProxyAuthenticationRequired = 407,
        [Display(Name = "Request Timeout")]
        RequestTimeout = 408,
        [Display(Name = "Conflict")]
        Conflict = 409,
        [Display(Name = "Gone")]
        Gone = 410,
        [Display(Name = "Length Required")]
        LengthRequired = 411,
        [Display(Name = "Precondition Failed")]
        PreconditionFailed = 412,
        [Display(Name = "Payload Too Large")]
        PayloadTooLarge = 413,
        [Display(Name = "URI Too Long")]
        URITooLong = 414,
        [Display(Name = "Unsupported Media Type")]
        UnsupportedMediaType = 415,
        [Display(Name = "Range Not Satisfiable")]
        RangeNotSatisfiable = 416,
        [Display(Name = "Expectation Failed")]
        ExpectationFailed = 417,
        [Display(Name = "I'm A Teapot")]
        ImATeapot = 418,
        [Display(Name = "Misdirected Request")]
        MisdirectedRequest = 421,
        [Display(Name = "Unprocessable Entity")]
        UnprocessableEntity = 422,
        [Display(Name = "Locked")]
        Locked = 423,
        [Display(Name = "Failed Dependency")]
        FailedDependency = 424,
        [Display(Name = "Too Early")]
        TooEarly = 425,
        [Display(Name = "Upgrade Required")]
        UpgradeRequired = 426,
        [Display(Name = "Precondition Required")]
        PreconditionRequired = 428,
        [Display(Name = "Too Many Requests")]
        TooManyRequests = 429,
        [Display(Name = "Request Header Fields Too Large")]
        RequestHeaderFieldsTooLarge = 431,
        [Display(Name = "Unavailable For Legal Reasons")]
        UnavailableForLegalReasons = 451,

        // 5xx Server Error
        [Display(Name = "Internal Server Error")]
        InternalServerError = 500,
        [Display(Name = "Not Implemented")]
        NotImplemented = 501,
        [Display(Name = "Bad Gateway")]
        BadGateway = 502,
        [Display(Name = "Service Unavailable")]
        ServiceUnavailable = 503,
        [Display(Name = "Gateway Timeout")]
        GatewayTimeout = 504,
        [Display(Name = "HTTP Version Not Supported")]
        HTTPVersionNotSupported = 505,
        [Display(Name = "Variant Also Negotiates")]
        VariantAlsoNegotiates = 506,
        [Display(Name = "Insufficient Storage")]
        InsufficientStorage = 507,
        [Display(Name = "Loop Detected")]
        LoopDetected = 508,
        [Display(Name = "Not Extended")]
        NotExtended = 510,
        [Display(Name = "Network Authentication Required")]
        NetworkAuthenticationRequired = 511
    }
}
