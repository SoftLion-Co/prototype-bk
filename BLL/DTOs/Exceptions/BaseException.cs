﻿using BLL.DTOs.Response;

namespace BLL.DTOs.Exceptions;

public abstract class BaseException : Exception, IAppException
{
    public virtual int StatusCode { get; }
    public IEnumerable<Error> Errors { get; }

    protected BaseException(string error)
    {
        Errors = new Error[] { new Error(error) };
    }

    protected BaseException(IEnumerable<string> errors)
    {
        Errors = errors.Select(e => new Error(e));
    }
}