using FluentAssertions;
using Moq;
using PersonaService.Cache;
using PersonaService.Models;
using PersonaService.Repositories;
using PersonaService.Validators;

namespace PersonaService.Test.Service;

[TestFixture]
public class PersonaServiceTest {
    
    private Services.PersonaService _service = null!;
    private Mock<IPersonaRepository> _mockRepository = null!;
    private Mock<IValidador<Persona>> _valPersonaMock = null!;
    private Mock<ICache<int, Persona>> _cacheMock = null!;


    [SetUp]
    public void SetUp() {
        // Se crea un mock para cada test
        _mockRepository = new Mock<IPersonaRepository>();
        _valPersonaMock = new Mock<IValidador<Persona>>();
        _cacheMock = new Mock<ICache<int, Persona>>();
    }
    
    [Test]
    

    [Test]
    public void GetById_ConCache_DeberiaRetornarDeCache() {
        // Arrange: Configuración específica de ESTE Test
        var persona = new Persona { Id = 1, Nombre = "Diego" };
        _cacheMock.Setup(r => r.Get(1)).Returns((Persona?) null);
        _mockRepository.Setup(r => r.GetById(1)).Returns(persona);
            
        // Act
        var resultado = _service.GetById(1);
            
        // Assert
        resultado.Should().NotBeNull();
        resultado.Nombre.Should().Be("Diego");
        _cacheMock.Verify(c => c.Get(1), Times.Once);
        _cacheMock.Verify(c => c.Add(1, persona), Times.Once);
        _mockRepository.Verify(r => r.GetById(1), Times.Once);

    }

    [Test]
    public void GetById_SinCache_DeberiaBuscarEnRepositorioYAgregarACache() {
        // Arrange
        var persona = new Persona { Id = 1, Nombre = "Diego" };
        _cacheMock.Setup(r => r.Get(1)).Returns((Persona?) null);
        _mockRepository.Setup(r => r.GetById(1)).Returns(persona);
        
        
        // Act 
        var resultado = _service.GetById(1);
        
        // Assert 
        resultado.Should().NotBeNull();
        resultado.Nombre.Should().Be("Diego");
        _cacheMock.Verify(c => c.Get(1), Times.Once);
        _cacheMock.Verify(c => c.Add(1, persona), Times.Once);
        _mockRepository.Verify(r => r.GetById(1), Times.Once);
    }
        
        
}
    
