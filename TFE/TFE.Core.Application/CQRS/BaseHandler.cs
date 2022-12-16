using MapsterMapper;

namespace TFE.Application.CQRS;

public abstract class BaseHandler
{
    private readonly IMapper _mapper;

    protected BaseHandler(IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
}