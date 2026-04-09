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
    public void GetById_Usuario_RetornoUsuario() {
        // Arrange: Configuración específica de ESTE Test
        _mockRepository.Setup(r => r.GetById(1))
            .Returns(new Persona { Id = 1, Nombre = "Diego" });
            
        // Act
        var resultado = _service.GetById(1);
            
        // Assert
        resultado.Nombre.Should().Be("Juan");
            
    }

    [Test]
    public void GetById_UsuarioNoExiste_RetornaNull() {
        // Arrange: OTRA configuracion para este test
        _mockRepository.Setup()
    }
        
        
        
}
    
