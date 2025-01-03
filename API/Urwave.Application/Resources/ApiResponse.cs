using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urwave.Application.Resources;
public class ApiResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public ApiResponse() { }

    public ApiResponse(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }
}

