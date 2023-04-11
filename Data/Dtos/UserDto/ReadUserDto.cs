using System.ComponentModel.DataAnnotations;

namespace PopCornAndCritics.Data.Dtos.UserDto
{
    public class ReadUserDto
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string bio { get; set; }
        public int evalr { get; set; }
        public string imageUrl { get; set; }
    }
}
