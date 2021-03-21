using Bemol.Channel.Controller;
using Bemol.Channel.Controller.BuscaCEP;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BemolChannel.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CepTeste()
        {
            string CEP = "69019410";
            BuscaCepRequest ValidaCEP = new BuscaCepRequest();
            BuscaCepResponse response = new BuscaCepResponse();

            response = ValidaCEP.Pesquisar(CEP);
            string cepEsperado = response.Cep.Replace("-", "");

            Assert.AreEqual(cepEsperado, CEP, "Erro no metodo consultar CEP !");
        }

        [TestMethod]
        public void CPFTeste()
        {
            string CPF = "42655696093";
            bool resultado = Validacao.CPF(CPF);

            Assert.IsTrue(resultado, "Erro na digitação do CPF");
        }
    }
}
