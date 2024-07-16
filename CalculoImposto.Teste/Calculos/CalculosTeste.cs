using CalculoImposto.API.Controllers;
using CalculoImposto.API.Servico.Calculo.Interface;
using CalculoImposto.Modelo.DTO.INSS;
using CalculoImposto.Modelo.DTO.IRRF;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CalculoImposto.Teste.Calculos;

[TestClass]
public class CalculosTeste
{
    private readonly CalculosController _calculosController;
    private readonly Mock<ICalculoImpostoServico> _mockCalculoImposto;

    public CalculosTeste()
    {
        _mockCalculoImposto = new Mock<ICalculoImpostoServico>();
        _calculosController = new CalculosController(_mockCalculoImposto.Object, null);
    }

    [TestMethod]
    public async Task CalculoInss()
    {
        var strCompetencia = "01/01/2024";
        var baseInss = 5000m;

        _mockCalculoImposto.Setup(x => x.CalculoInssProgressivo(It.IsAny<DateTime>(), It.IsAny<decimal>()))
                                        .ReturnsAsync(new CalculoInssProgressivoDto());

        var result = await _calculosController.CalculoInssProgressivo(strCompetencia, baseInss);
        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
    }
    [TestMethod]
    public async Task CalculoIrrfProgressivo()
    {
        var strCompetencia = "01/01/2024";
        var valorIrrf = 5000m;
        var baseInss = 5000m;
        var qtDependente = 0;

        _mockCalculoImposto.Setup(x => x.CalculoIrrfProgressivo(It.IsAny<DateTime>(),
                                                                It.IsAny<decimal>(),
                                                                It.IsAny<decimal>(),
                                                                It.IsAny<int>()))
                                        .ReturnsAsync(new CalculoProgressivoDto());

        var result = await _calculosController.CalculoIrrfProgressivo(strCompetencia, valorIrrf, baseInss, qtDependente);
        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
    }
    [TestMethod]
    public async Task CalculoIrrfNormal()
    {
        var strCompetencia = "01/01/2024";
        var valorIrrf = 5000m;
        var baseInss = 5000m;
        var qtDependente = 0;

        _mockCalculoImposto.Setup(x => x.CalculoIrrfNormal(It.IsAny<DateTime>(),
                                                                It.IsAny<decimal>(),
                                                                It.IsAny<decimal>(),
                                                                It.IsAny<int>()))
                                        .ReturnsAsync(new CalculoNormalDto());

        var result = await _calculosController.CalculoIrrfNormal(strCompetencia, valorIrrf, baseInss, qtDependente);
        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
    }
    [TestMethod]
    public async Task CalculoIrrfSimplificado()
    {
        var strCompetencia = "01/01/2024";
        var valorIrrf = 5000m;

        _mockCalculoImposto.Setup(x => x.CalculoIrrfSimplificado(It.IsAny<DateTime>(),
                                                                It.IsAny<decimal>()
                                                                ))
                                        .ReturnsAsync(new CalculoSimplificadoDto());

        var result = await _calculosController.CalculoIrrfSimplificado(strCompetencia, valorIrrf);
        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
    }
}
