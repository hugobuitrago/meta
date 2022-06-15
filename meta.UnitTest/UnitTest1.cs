using meta.Domain;
using meta.DTO;
using meta.Infra.Data.Interfaces.Repositories;
using meta.Service;
using meta.Service.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace meta.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetTest_ReturnOK()
        {
            //ARRANGE
            Caminhao caminhao_1 = new Caminhao()
            {
                Modelo = "FM",
                AnoFabricacao = 2022,
                AnoModelo = 2022,
                Id = 1
            };

            IEnumerable<Caminhao> resultados = new List<Caminhao>() { caminhao_1 };

            var RepositoryMock = new Mock<ICaminhaoRepository>();
            RepositoryMock.Setup(m => m.GetAll()).ReturnsAsync(resultados).Verifiable();

            ICaminhaoService _CaminhaService = new CaminhaoService(RepositoryMock.Object);

            //ACT
            var actual = _CaminhaService.GetCaminhaoAsync().Result;

            //Assert
            RepositoryMock.Verify();
            Assert.IsNotNull(actual);//assert that a result was returned
            Assert.AreEqual(resultados.ToList()[0].Modelo, actual.ToList()[0].Modelo);
            Assert.AreEqual(resultados.ToList()[0].AnoModelo, actual.ToList()[0].AnoModelo);
            Assert.AreEqual(resultados.ToList()[0].AnoFabricacao, actual.ToList()[0].AnoFabricacao);
            Assert.AreEqual(resultados.ToList()[0].Id, actual.ToList()[0].Id);
        }

        [TestMethod]
        public void GetTest_ReturnNotFound()
        {
            //ARRANGE
            IEnumerable<Caminhao> resultados = null;

            var RepositoryMock = new Mock<ICaminhaoRepository>();
            RepositoryMock.Setup(m => m.GetAll()).ReturnsAsync(resultados).Verifiable();

            ICaminhaoService _CaminhaService = new CaminhaoService(RepositoryMock.Object);

            //ACT
            var actual = _CaminhaService.GetCaminhaoAsync().Result;

            //Assert
            RepositoryMock.Verify();
            Assert.IsNull(actual);//assert that a result was returned
        }

        [TestMethod]
        public void DeleteTest_ReturnOK()
        {
            //ARRANGE
            Caminhao caminhao_1 = new Caminhao()
            {
                Modelo = "FM",
                AnoFabricacao = 2022,
                AnoModelo = 2022,
                Id = 1
            };

            int retorno = 1;

            var RepositoryMock = new Mock<ICaminhaoRepository>();
            RepositoryMock.Setup(m => m.GetById(1)).ReturnsAsync(caminhao_1).Verifiable();
            RepositoryMock.Setup(m => m.Delete(caminhao_1)).ReturnsAsync(1).Verifiable();

            ICaminhaoService _CaminhaService = new CaminhaoService(RepositoryMock.Object);

            //ACT
            var actual = _CaminhaService.DeleteCaminhaoAsync(1).Result;

            //Assert
            RepositoryMock.Verify();
            Assert.IsNotNull(actual);//assert that a result was returned
            Assert.AreEqual(retorno, actual.Value);
        }

        [TestMethod]
        public void DeleteTest_ReturnNotFound()
        {
            //ARRANGE
            Caminhao caminhao_1 = null;

            var RepositoryMock = new Mock<ICaminhaoRepository>();
            RepositoryMock.Setup(m => m.GetById(1)).ReturnsAsync(caminhao_1).Verifiable();
            ICaminhaoService _CaminhaService = new CaminhaoService(RepositoryMock.Object);

            //ACT
            var actual = _CaminhaService.DeleteCaminhaoAsync(1).Result;

            //Assert
            RepositoryMock.Verify();
            Assert.IsNull(actual);//assert that a result was returned
        }

        [TestMethod]
        public void EditTest_ReturnOK()
        {
            //ARRANGE
            CaminhaoEditDTO caminhao_1_edit = new CaminhaoEditDTO()
            {
                Modelo = "FM",
                AnoFabricacao = 2022,
                AnoModelo = 2023,
                Id = 1
            };

            Caminhao caminhao_1 = new Caminhao()
            {
                Modelo = caminhao_1_edit.Modelo,
                AnoFabricacao = caminhao_1_edit.AnoFabricacao,
                AnoModelo = caminhao_1_edit.AnoModelo,
                Id = 1
            };

            var RepositoryMock = new Mock<ICaminhaoRepository>();
            RepositoryMock.Setup(m => m.GetById(1)).ReturnsAsync(caminhao_1).Verifiable();
            RepositoryMock.Setup(m => m.Edit(caminhao_1)).Verifiable();

            ICaminhaoService _CaminhaService = new CaminhaoService(RepositoryMock.Object);

            //ACT
            var actual = _CaminhaService.EditCaminhaoAsync(caminhao_1_edit).Result;

            //Assert
            RepositoryMock.Verify();
            Assert.IsNotNull(actual);//assert that a result was returned
            Assert.AreEqual(caminhao_1.Modelo, actual.Modelo);
            Assert.AreEqual(caminhao_1.AnoModelo, actual.AnoModelo);
            Assert.AreEqual(caminhao_1.AnoFabricacao, actual.AnoFabricacao);
        }


        [TestMethod]
        public void EditTest_ReturnNotFound()
        {
            //ARRANGE
            CaminhaoEditDTO caminhao_1_edit = new CaminhaoEditDTO()
            {
                Modelo = "FM",
                AnoFabricacao = 2022,
                AnoModelo = 2023,
                Id = 1
            };

            Caminhao caminhao_1 = null;

            var RepositoryMock = new Mock<ICaminhaoRepository>();
            RepositoryMock.Setup(m => m.GetById(1)).ReturnsAsync(caminhao_1).Verifiable();

            ICaminhaoService _CaminhaService = new CaminhaoService(RepositoryMock.Object);

            //ACT
            var actual = _CaminhaService.EditCaminhaoAsync(caminhao_1_edit).Result;

            //Assert
            RepositoryMock.Verify(); 
            Assert.IsNull(actual); //assert that a result was returned
        }

        [TestMethod]
        public void InsertTest_ReturnOk()
        {
            //ARRANGE
            CaminhaoInsertDTO caminhao_1_insert = new CaminhaoInsertDTO()
            {
                Modelo = "FM",
                AnoFabricacao = 2022,
                AnoModelo = 2023
            };

            Caminhao caminhao_1 = new Caminhao()
            {
                Modelo = caminhao_1_insert.Modelo,
                AnoFabricacao = caminhao_1_insert.AnoFabricacao,
                AnoModelo = caminhao_1_insert.AnoModelo,
                Id = 1
            };

            var RepositoryMock = new Mock<ICaminhaoRepository>();
            RepositoryMock.Setup(m => m.Insert(caminhao_1)).Verifiable();

            ICaminhaoService _CaminhaService = new CaminhaoService(RepositoryMock.Object);

            //ACT
            var actual = _CaminhaService.InsertCaminhaoAsync(caminhao_1_insert).Result;

            //Assert
            Assert.IsNotNull(actual); //assert that a result was returned
            Assert.AreEqual(caminhao_1.Modelo, actual.Modelo);
            Assert.AreEqual(caminhao_1.AnoModelo, actual.AnoModelo);
            Assert.AreEqual(caminhao_1.AnoFabricacao, actual.AnoFabricacao);
        }
    }
}
