using Guardian_API.Application.Dtos;
using Guardian_API.Application.Interfaces;
using Guardian_API.Domain.Entities;
using Guardian_API.Domain.Interfaces;

namespace Guardian_API.Application.Services
{
    public class AerogeradorApplicationService : IAerogeradorApplicationService
    {
        private readonly IAerogeradorRepository _repository;

        public AerogeradorApplicationService(IAerogeradorRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<AerogeradorEntity>? ObterAerogeradores()
        {
            return _repository.ObterTodos();
        }

        public AerogeradorEntity? ObterAerogeradorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public AerogeradorEntity? AdicionarAerogerador(AerogeradorDto aerogerador)
        {
            var Aerogerador = new AerogeradorEntity
            {
                Modelo = aerogerador.Modelo,
                Tecnologia = aerogerador.Tecnologia,
                CapacidadeMW = aerogerador.CapacidadeMW,
                AlturaMastro = aerogerador.AlturaMastro,
                VelocidadeCorte = aerogerador.VelocidadeCorte,
                StatusOperacao = aerogerador.StatusOperacao,
                DiametroMotor = aerogerador.DiametroMotor,
                DataInstalacao = aerogerador.DataInstalacao,
                Garantia = aerogerador.Garantia,
            };

            return _repository.Adicionar(Aerogerador);
        }

        public AerogeradorEntity? EditarAerogerador(int id, AerogeradorDto aerogerador)
        {
            var Aerogerador = new AerogeradorEntity
            {
                Id = id,
                Modelo = aerogerador.Modelo,
                Tecnologia = aerogerador.Tecnologia,
                CapacidadeMW = aerogerador.CapacidadeMW,
                AlturaMastro = aerogerador.AlturaMastro,
                VelocidadeCorte = aerogerador.VelocidadeCorte,
                StatusOperacao = aerogerador.StatusOperacao,
                DiametroMotor = aerogerador.DiametroMotor,
                DataInstalacao = aerogerador.DataInstalacao,
                Garantia = aerogerador.Garantia,
            };

            return _repository.Editar(Aerogerador);
        }

        public AerogeradorEntity? ExcluirAerogerador(int id)
        {
            return _repository.Excluir(id);
        }
    }
}
