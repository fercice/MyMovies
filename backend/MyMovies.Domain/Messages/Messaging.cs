using System;

namespace MyMovies.Domain.Messages
{
    public static class Messaging
    {
        public static readonly string MessageServiceError = "Service Exception: ";

        public static readonly string MessageRepositoryError = "Repository Exception: ";

        public static readonly string MessageRequiredFields = "Preencher todos os campos obrigatórios";

        public static readonly string MessageNoRecord = "Nenhum registro encontrado";

        public static readonly string MessageSavedOk = "Salvo com sucesso";

        public static readonly string MessageSavedError = "Não foi possível salvar";

        public static readonly string MessageDeletedOk = "Excluído com sucesso";

        public static readonly string MessageDeletedError = "Não foi possível excluir";
    }
}
