﻿using Reendv.Domain.Commands.Contracts;

namespace Reendv.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}