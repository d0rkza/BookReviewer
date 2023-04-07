using MediatR;
using Microsoft.AspNetCore.Mvc;

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
