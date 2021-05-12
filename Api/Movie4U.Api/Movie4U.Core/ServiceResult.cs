﻿using Movie4U.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Core
{
    public class ServiceResult<T>
    {

        public ServiceResult(ResponseCode  responseCode , string error , T result)
        {
            ResponseCode = responseCode;
            Error = error;
            Result = result;

        }

        public ResponseCode ResponseCode { get; set; }

        public string Error { get; set; }

        public T Result { get; set; }

        public static ServiceResult<T> ErrorResult(string error)
        {
            return new ServiceResult<T>(ResponseCode.Error, error, default(T));

        }

        public static ServiceResult<T> SuccesResult(T entity )
        {
            return new ServiceResult<T>(ResponseCode.Success, string.Empty, entity);

        }
        public static ServiceResult<T> NotFoundResult(string error)
        {
            return new ServiceResult<T>(ResponseCode.NotFound, error, default(T));

        }
    }
}
