namespace CleanArchitectrure.Application.Dto
{
    /// <summary>
    /// User Data Transfer Object
    /// </summary>
    public class UserDto
    {
        //public int UserId { get; set; }
        public string? Company { get; set; }
        public string? Abbreviation { get; set; }
        public required string Client { get; set; }
        public required string Secret { get; set; }
    }
}
