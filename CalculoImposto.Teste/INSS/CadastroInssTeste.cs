using CalculoImposto.API.Controllers;
using CalculoImposto.API.Servico.INSS.Interface;
using CalculoImposto.Modelo.DTO.INSS;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CalculoImposto.Teste.INSS;

[TestClass]
public class CadastroInssTeste
{
    private readonly InssController _inssController;
    private readonly Mock<IInssServico> _mockInssServico;
    public CadastroInssTeste()
    {
        _mockInssServico = new Mock<IInssServico>();
        _inssController = new InssController(_mockInssServico.Object);
    }
    [TestMethod]
    public async Task Post_Inss_Created()
    {
        InssDto inssDto = new()
        {
            Competencia = DateTime.Parse("01/01/2024"),
            Faixa = 1,
            Porcentagem = 7.5m,
            Valor = 1412m
        };
        _mockInssServico.Setup(x => x.CriarInss(It.IsAny<InssDto>())).Returns(Task.CompletedTask);
        var inssDtoResult = await _inssController.Post(inssDto);
        Assert.IsInstanceOfType(inssDtoResult, typeof(ActionResult<InssDto>));
    }
    [TestMethod]
    public async Task Put_Inss_Ok()
    {
        InssDto inssDto = new()
        {
            Id = 1,
            Competencia = DateTime.Parse("01/01/2024"),
            Faixa = 2,
            Porcentagem = 9.5m,
            Valor = 1512m
        };
        _mockInssServico.Setup(x => x.AtualizarInss(It.IsAny<InssDto>())).Returns(Task.CompletedTask);

        var inssDtoResult = await _inssController.Put(1, inssDto);

        Assert.IsInstanceOfType(inssDtoResult, typeof(ActionResult<InssDto>));
    }
    [TestMethod]
    public async Task Delete_Inss_Ok()
    {
        var inssDtoResult = await _inssController.Delete(1);
        Assert.IsInstanceOfType(inssDtoResult, typeof(ActionResult<InssDto>));
    }
}
