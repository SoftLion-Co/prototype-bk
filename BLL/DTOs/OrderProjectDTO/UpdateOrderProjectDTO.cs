
﻿using BLL.DTOs.Base;
using DAL.Enums;
using System;

namespace BLL.DTOs.OrderProjectDTO
{

    public class UpdateOrderProjectDTO : UpdateBaseDTO
    {
        public string NumberPhone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string OrderType { get; set; } = null!;

    }
}
