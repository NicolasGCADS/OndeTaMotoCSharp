using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OndeTaMotoApi.Controllers;
using OndeTaMotoBusiness;
using OndeTaMotoModel;
using Xunit;

namespace OndeTaMotoTests
{
    public class UsuarioControllerTests
    {
        [Fact]
        public void Get_WhenNoUsers_ReturnsNoContent()
        {
            var mockService = new Mock<IUsuarioService>();
            mockService.Setup(s => s.ListarTodos()).Returns(new List<UsuarioModel>());

            var controller = new UsuarioController(mockService.Object);

            var result = controller.Get();

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void GetById_WhenNotFound_ReturnsNotFound()
        {
            var mockService = new Mock<IUsuarioService>();
            mockService.Setup(s => s.ObterPorId(It.IsAny<int>())).Returns((UsuarioModel?)null);

            var controller = new UsuarioController(mockService.Object);

            var result = controller.Get(123);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Post_WhenValid_ReturnsCreatedAtAction()
        {
            var input = new UsuarioModel { Email = "teste@local", Senha = "1234", Role = "Usuario" };
            var created = new UsuarioModel { Id = 42, Email = input.Email, Senha = input.Senha, Role = input.Role };

            var mockService = new Mock<IUsuarioService>();
            mockService.Setup(s => s.Criar(It.IsAny<UsuarioModel>())).Returns(created);

            var controller = new UsuarioController(mockService.Object);

            var actionResult = controller.Post(input) as CreatedAtActionResult;

            Assert.NotNull(actionResult);
            Assert.Equal(nameof(UsuarioController.Get), actionResult.ActionName);
            var value = actionResult.Value as UsuarioModel;
            Assert.NotNull(value);
            Assert.Equal(42, value.Id);
        }
    }
}