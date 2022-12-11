using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "64293d2a-710d-42ef-b143-3e853a625f89",
                ConcurrencyStamp = "f214a0fd-df65-4ae2-8b72-160043b4c118",
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Id = "be42e99f-b0f1-458e-a4ce-fd11fd1df54a",
                ConcurrencyStamp = "8e612b87-0a89-4281-ab1c-da033c0b7e9a",
                Name = "Moderator",
                NormalizedName = "MODERATOR"
            },
            new IdentityRole
            {
                Id = "fc6a24fb-6667-48b7-b357-2a6f1219ebee",
                ConcurrencyStamp = "02f36689-5a7c-45b8-ba15-9ffd614ae944",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
        );
    }
}
