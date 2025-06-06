﻿using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace School.Application.Bahavoir
{
    public class RequestResponseLoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    {
        private readonly ILogger<RequestResponseLoggingBehavior<TRequest, TResponse>> logger;

        public RequestResponseLoggingBehavior(ILogger<RequestResponseLoggingBehavior<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var correlationId = Guid.NewGuid();

            // Request Logging
            // Serialize the request
            var requestJson = JsonSerializer.Serialize(request);
            // Log the serialized request
            logger.LogInformation("Handling request {CorrelationID}: {Request}", correlationId, requestJson);

            // Response logging
            var response = await next();
            // Serialize the request
            var responseJson = JsonSerializer.Serialize(response);
            // Log the serialized request
            logger.LogInformation("Response for {Correlation}: {Response}", correlationId, responseJson);

            // Return response
            return response;
        }
    }
}
