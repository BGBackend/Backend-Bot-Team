﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendBot.Models
{
    [Serializable]
    public class CurrentUserPreferences
    {
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
    }
}