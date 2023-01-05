using MapsterMapper;
using TFE.Infrastructure;

namespace TFE.Application.CQRS;

public abstract class BaseHandler
{
    protected readonly IMapper Mapper;
    protected readonly ApplicationDbContext DbContext;

    protected BaseHandler(IMapper mapper, ApplicationDbContext dbContext)
    {
        Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
}