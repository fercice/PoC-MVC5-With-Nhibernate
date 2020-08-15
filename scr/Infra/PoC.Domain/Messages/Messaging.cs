namespace PoC.Domain.Messages
{
    public static class Messaging
    {
        public static readonly string MessageSavedOk = "Salvo com sucesso";

        public static readonly string MessageSavedError = "Não foi possível salvar";      

        public static readonly string MessageClienteCadastrado = "Cliente já cadastrado";

        public static readonly string MessageProdutoCadastrado = "Produto já cadastrado";

        public static readonly string MessageClienteAddProdutoSavedOk = "Produto adicionado com sucesso";

        public static readonly string MessageClienteProdutoAdicionado = "Produto já adicionado";

        public static readonly string MessageClienteProdutoRemovido = "Produto desassociado com sucesso";

        public static readonly string MessageClienteProdutoAdicionadoLimite = "Cliente atingiu o limite de 15 produtos associados";
    }
}
