using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class AddUsuarioUseCase<TDTO>
    {
        private readonly IRepository<Usuario> _repository;
        private readonly IMapper<TDTO, Usuario> _mapper;

        public AddUsuarioUseCase(IRepository<Usuario> repository, 
            IMapper<TDTO, Usuario> mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task ExecuteAsync(TDTO usuarioDTO)
        {
            var usuario = _mapper.ToEntity(usuarioDTO);
            await _repository.AddAsync(usuario);
        }
    }
}
