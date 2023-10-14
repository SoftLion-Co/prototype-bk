
﻿using DAL.Enums;
using System;

namespace BLL.DTOs.OrderProjectDTO
{
    public class InsertOrderProjectDTO
    {
        public string NumberPhone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;

    }
}
