
﻿using BLL.DTOs.Base;
using DAL.Enums;
using System;

namespace BLL.DTOs.OrderBlogDTO
{

    public class GetOrderBlogDTO : GetBaseDto
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public bool? OrderType { get; set; }
    }
}
