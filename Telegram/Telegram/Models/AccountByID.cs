﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telegram.Models
{
    
        public class AccountByID
        {
            public Profile Profile { get; set; }
        }
        public class Profile
        {
            public long Account_id { get; set; }
            public string Personaname { get; set; }
            public string Profileurl { get; set; }
            public string Last_login { get; set; }
            public string Loccountrycode { get; set; }
        }
    
}
