using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewer.IBusiness
{
    public class MediatrController : ControllerBase
    {
        private IMediator mediator;

        private IMediator Mediator => mediator ?? (mediator = base.HttpContext.RequestServices.GetService<IMediator>());

        protected Task<TResponse> SendRequest<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Mediator.Send(request, cancellationToken);
        }
    }
}
