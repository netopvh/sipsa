using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using sipsa.Dominio._Base;

namespace sipsa.Dados.Repositorios
{
    public class _Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade<TEntidade>
    {
        private readonly SipsaContexto _contexto;
        private DynamoDBOperationConfig _config;

        public _Repositorio(SipsaContexto contexto, string tabela) 
        {
            _contexto = contexto;
            _config = new DynamoDBOperationConfig()
            {
                OverrideTableName = tabela
            };
        }

        protected async Task<List<TEntidade>> ObterComFiltrosAsync(IEnumerable<ScanCondition> filtro)
        {
            return await _contexto.ScanAsync<TEntidade>(filtro, _config).GetRemainingAsync();
        }

        public async Task<List<TEntidade>> ObterTodosAsync()
        {
            return await ObterComFiltrosAsync(null);
        }

        public async Task<TEntidade> ObterPorIdAsync(string id)
        {
            return await _contexto.LoadAsync<TEntidade>(id, _config);
        }

        public async Task SalvarAsync(TEntidade item)
        {
            await _contexto.SaveAsync(item, _config);
        }

        public async Task RemoverAsync(TEntidade item)
        {
            await _contexto.DeleteAsync(item, _config);
        }
    }
}