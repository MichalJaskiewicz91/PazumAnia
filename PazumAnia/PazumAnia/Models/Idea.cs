﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PazumAnia.Models
{
    public class Idea
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string UserId { get; set; }
    }
}
