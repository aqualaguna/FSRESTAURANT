﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS_REST
{
    class FormValidationFailException:Exception
    {
        public  FormValidationFailException(string msg):base (msg)
        {
           
        }
    }
}
