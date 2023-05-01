using DigitalTwinMiddleware.DTOs;
using DigitalTwinMiddleware.DTOs.Enums;
using DigitalTwinMiddleware.DTOs.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DigitalTwinMiddleware.Utilities
{
    public static class ResponseBuilder
    {
        public static GlobalResponse<T> BuildResponse<T>(ModelStateDictionary errs, T data)
        {
            var listOfErrorItems = new List<ErrorItemModel>();
            var benchMark = new List<string>();

            if (errs != null)
            {
                foreach (var err in errs)
                {
                    var key = err.Key;
                    var errValues = err.Value;
                    var errList = new List<string>();
                    foreach (var errItem in errValues.Errors)
                    {
                        errList.Add(errItem.ErrorMessage);
                        if (!benchMark.Contains(key))
                        {
                            listOfErrorItems.Add(new ErrorItemModel { Key = key, ErrorMessages = errList });
                            benchMark.Add(key);
                        }
                    }
                }
            }

            var response = new GlobalResponse<T>
            {
                Data = data,
                Errors = listOfErrorItems,
            };

            return response;
        }
    }
}
