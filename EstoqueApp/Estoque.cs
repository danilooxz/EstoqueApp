using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueApp
{
    public class Estoque
    {
        private Dictionary<string, int> _produto = new Dictionary<string, int>();

        public void AdicionarProduto(string nomeProduto, int quantidade)
        {
            if (_produto.ContainsKey(nomeProduto))
            {
                _produto[nomeProduto] += quantidade;
            }

            else
            {
                _produto[nomeProduto] = quantidade;
            }

        }
        public int ObterQuantidade(string nomeProduto)
                {
                    return _produto.ContainsKey(nomeProduto)
                        ? _produto[nomeProduto] : 0;
                }

        public void RemoverProduto(string nomeProduto, int quantidade)
        {
            if (_produto.ContainsKey(nomeProduto) && _produto[nomeProduto] >= quantidade)
            {
                _produto[nomeProduto] -= quantidade;
            }
            else
            {
                throw new InvalidOperationException("Quantidade insuficiente no estoque");
            }
        }
    
    
        public List<string> VerificarEstoque()
        {
            return new List<string>(_produto.Keys);
        }
    }
}

 
