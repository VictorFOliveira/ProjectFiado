﻿using ProjectFiado.Domain.Enum;

namespace ProjectFiado.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public Role  role { get; set; }
        public Status Status { get; set; }

        // atributos de auditoria
        public DateOnly CreationDate { get; set; } = new DateOnly();
        public string LastAlterationName { get;set; }
        public DateTime LastModificationDate { get; set; } = DateTime.Now;
    }
}
