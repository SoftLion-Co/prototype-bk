

namespace BLL.DTOs.CustomerDTO
{
    public class InsertCustomerDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

    }
}
