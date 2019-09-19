using System;
using System.Threading;
using System.Threading.Tasks;
using App.Db;
using MediatR;

namespace App.BLL.Activities
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Id);
                if (activity == null)
                {
                    throw new Exception("No activity found");
                }
                _context.Remove(activity);
                //handler logic
                var success = await _context.SaveChangesAsync() > 0;
                return success ? Unit.Value : throw new Exception("Problem saving changes");
            }
        }
    }
}