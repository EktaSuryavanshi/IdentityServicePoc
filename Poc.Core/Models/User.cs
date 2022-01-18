namespace Poc.Core.Models;

public class User
{
    public string UserName { get; set; } = string.Empty;

    public Guid UserGuid { get; set; } = Guid.Empty;

    public string RoleName { get; set; } = string.Empty;

    public int RoleId { get; set; } = int.MinValue;

    public string AplId { get; set; } = string.Empty;

    public bool HasActiveRole { get; set; } = true;
}
