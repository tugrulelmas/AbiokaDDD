using AbiokaDDD.ApplicationService.DTOs;
using AbiokaDDD.Domain;
using System.Collections.Generic;

namespace AbiokaDDD.ApplicationService.Map
{
    public static class UserDTOMapper
    {
        public static UserDTO ToDTO(this User user) {
            var result = new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                ImageUrl = user.ImageUrl,
                Initials = user.Initials
            };
            return result;
        }

        public static IEnumerable<UserDTO> ToDTOs(this IEnumerable<User> users) {
            if (users == null)
                yield break;

            foreach (var item in users)
            {
                yield return item.ToDTO();
            }
        }
    }
}
