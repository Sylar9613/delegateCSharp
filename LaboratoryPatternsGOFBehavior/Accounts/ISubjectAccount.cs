﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    public interface ISubjectAccount
    {
        void Attach(IObserverAccount observer);

        void Detach(IObserverAccount observer);

        void Notify();
    }
}
