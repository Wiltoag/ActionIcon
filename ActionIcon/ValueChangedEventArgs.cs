﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ActionIcon
{
    public class ValueChangedEventArgs<TValue> : EventArgs
    {
        public ValueChangedEventArgs(TValue oldValue, TValue newValue) => (OldValue, NewValue) = (oldValue, newValue);

        public TValue NewValue { get; }
        public TValue OldValue { get; }
    }
}