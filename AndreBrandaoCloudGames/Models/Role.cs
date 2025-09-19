namespace AndreBrandaoCloudGamesApi.Models
{
    /// <summary>
    /// Define os níveis de permissão disponíveis na plataforma:
    /// <br/>• <b>User</b> – Acesso padrão para usuários comuns, com funcionalidades básicas.
    /// <br/>• <b>Admin</b> – Acesso administrativo, com privilégios avançados para gerenciamento da plataforma.
    /// </summary>
    /// <summary>
    /// Define os níveis de permissão disponíveis para usuários na plataforma.
    /// </summary>
    public enum Role
    {
        /// <summary>
        /// Permissão padrão para usuários comuns, com acesso às funcionalidades básicas da plataforma.
        /// </summary>
        USER,

        /// <summary>
        /// Permissão administrativa, com acesso a recursos avançados como gestão de usuários,
        /// cadastro de jogos e criação de promoções.
        /// </summary>
        ADMIN
    }

}
