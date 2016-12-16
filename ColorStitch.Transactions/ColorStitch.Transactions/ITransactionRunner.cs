﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorStitch.Transactions
{
    public interface ITransactionRunner
    {
        void RunTransaction(Action action);
        T RunTransaction<T>(Func<T> action);
        T RunSelectTransaction<T>(Func<T> action);
    }
}
