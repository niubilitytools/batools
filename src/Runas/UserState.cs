namespace Runas
{
    /// <summary>
    ///     Enum state
    /// </summary>
    public enum UserState
    {
        /// <summary>
        ///     can't get adminitrator with specific user and password
        /// </summary>
        NoAdministrator,

        /// <summary>
        ///     got administr
        /// </summary>
        Administrator,

        /// <summary>
        ///    Restart a new process to get admin permission
        /// </summary>
        RestartTryGet
    }
}