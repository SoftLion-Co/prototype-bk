﻿using BLL.DTOs.Base;

namespace BLL.DTOs.CustomerDTO;

public class UpdateCustomerDto : UpdateBaseDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Facebook { get; set; }
    public string? Google { get; set; }
    public string? Linkedin { get; set; }
}