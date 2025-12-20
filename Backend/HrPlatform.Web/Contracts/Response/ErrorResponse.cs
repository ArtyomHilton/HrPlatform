using System.Runtime.CompilerServices;

namespace HrPlatform.Web.Contracts.Response;

public record ErrorResponse(string ErrorCode, int statusCode);
