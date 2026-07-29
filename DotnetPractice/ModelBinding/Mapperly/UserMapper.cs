using ModelBinding.Models;
using Riok.Mapperly.Abstractions;

namespace ModelBinding.Mapperly
{
    [Mapper]
    public partial class UserMapper
    {
        public partial List<UserDTO> getDTOData(List<User> user);

        public partial UserDTO updateUserToUserDTO(User user, User selectedrecord);


    }
}
