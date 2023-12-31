﻿namespace BestAuto.Domain.Entities;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(b => b.UserName)
            .HasMaxLength(50)
            .IsRequired();
    }
}