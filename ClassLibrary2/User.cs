﻿using System;

namespace ClassLibrary2
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid UserGuid { get; set; }
        public bool IsActive { get; set; } // eğer bir class a sonradan property eklersek veya silersek bu durumda migrations yapısını kullanmalıyız
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
