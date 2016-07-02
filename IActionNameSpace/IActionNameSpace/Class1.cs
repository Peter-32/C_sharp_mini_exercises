﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IActionNameSpace
{
    public interface IAction<TContext>
    {
        void Do(TContext context);
    }
}
