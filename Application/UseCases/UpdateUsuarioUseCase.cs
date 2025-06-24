using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.UseCases
{
    public class UpdateUsuarioUseCase
    {
        private readonly IRepository<Usuario> _repository;

        public UpdateUsuarioUseCase(IRepository<Usuario> repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(UpdateUsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                throw new ArgumentNullException(nameof(usuarioDTO));

            var usuario = await _repository.GetByIdAsync(usuarioDTO.Id);
            if (usuario == null)
                throw new KeyNotFoundException($"Usuario with ID {usuarioDTO.Id} not found");

            // Validate DTO
            var validationContext = new ValidationContext(usuarioDTO);
            Validator.ValidateObject(usuarioDTO, validationContext, true);

            // If password is being updated, validate confirmation
            if (!string.IsNullOrEmpty(usuarioDTO.Contraseña))
            {
                if (usuarioDTO.Contraseña != usuarioDTO.ConfirmarContraseña)
                    throw new ValidationException("Las contraseñas no coinciden");
            }

            // Create new usuario instance with updated fields
            var updatedUsuario = new Usuario(
                usuarioDTO.Email ?? usuario.Email,
                usuarioDTO.NombreUsuario ?? usuario.NombreUsuario,
                usuarioDTO.Contraseña ?? usuario.Contraseña,
                usuario.Estatus, // Maintain current status
                usuarioDTO.Sexo ?? usuario.Sexo
            );

            await _repository.UpdateAsync(updatedUsuario);
        }
    }
}
