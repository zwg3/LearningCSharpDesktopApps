﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfHello
{
    public class CustomCommands
    {
        public static RoutedUICommand Launch { get; }

        static CustomCommands()
        {
            InputGestureCollection myInputGestures = new ();
            myInputGestures.Add(new KeyGesture(Key.L, ModifierKeys.Control));
            Launch = new RoutedUICommand("Запуск", "Launch", typeof(CustomCommands), myInputGestures);
        }
    }
}
