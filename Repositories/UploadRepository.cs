using AutoMapper;
using Document.Data;

namespace Document.Repository
{
    public class UploadRepository
    {
        private readonly ConfigDataContext _context;
        private readonly IMapper _mapper;

        public UploadRepository(ConfigDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Insert()
        {
            
        }
    }
}