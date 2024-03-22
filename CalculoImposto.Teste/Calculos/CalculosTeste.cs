using CalculoImposto.API.Controllers;
using CalculoImposto.API.Servico.Calculo.Interface;
using CalculoImposto.Modelo.DTO.INSS;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CalculoImposto.Teste.Calculos;

[TestClass]
public class CalculosTeste
{
    private CalculosController _calculosController;
    private Mock<ICalculoImpostoServico> _mockCalculoImposto;

    public CalculosTeste()
    {
        _mockCalculoImposto = new Mock<ICalculoImpostoServico>();
        _calculosController = new CalculosController(_mockCalculoImposto.Object);

    }

    [TestMethod]
    public async Task CalculoInss()
    {
        var strCompetencia = "01/01/2024";
        var baseInss = 5000m;

        _mockCalculoImposto.Setup(x => x.CalculoInssProgressivo(It.IsAny<DateTime>(), It.IsAny<decimal>()))
            .ReturnsAsync(new CalculoInssProgressivoDto());

        var result = await _calculosController.Calculo(strCompetencia, baseInss);

        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

    }
}
