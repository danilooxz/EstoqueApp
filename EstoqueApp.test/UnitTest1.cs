namespace EstoqueApp.test
{
    public class UnitTest1
    {
        [Fact]
        public void AdicionarProduto_DeveAdicionarProdutoAoEstoque()
        {
            // Arrege
            var estoque = new Estoque();
            string nomeProduto = "Cuecas";
            int quantidade = 10;

            // Act
            estoque.AdicionarProduto(nomeProduto, quantidade);

            // Assert
            Assert.Equal(quantidade, estoque.ObterQuantidade(nomeProduto));
        }


        [Fact]
        public void RemoverProduto_DeveDiminuirQuantidadeDoProduto()
        {
            // Arrege
            var estoque = new Estoque();
            string nomeProduto = "Luvas";
            estoque.AdicionarProduto(nomeProduto, 10);

            // Act
            estoque.RemoverProduto(nomeProduto, 5);

            // Assert
            Assert.Equal(5, estoque.ObterQuantidade(nomeProduto));


        }

        [Fact]
        public void RemoverProduto_QuandoQuantidadeInsuficiente_DeveLancarExecao()
        {
            // Arrege
            var estoque = new Estoque();
            string nomeProduto = "Sapatos";
            estoque.AdicionarProduto(nomeProduto, 5);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(
                () => estoque.RemoverProduto(nomeProduto, 10));
        }


        [Fact]
        public void VerificarEstoque_DeveRetornarProdutosEmEstoque()
        {
            // Arrege
            var estoque = new Estoque();
            estoque.AdicionarProduto("Chapeu", 5);
            estoque.AdicionarProduto("Gravata", 4);

            // Act
            var produtoEmEstoque = estoque.VerificarEstoque();

            // Assert
            Assert.Contains("Chapeu", produtoEmEstoque);
            Assert.Contains("Gravata", produtoEmEstoque);
        }
    }
}