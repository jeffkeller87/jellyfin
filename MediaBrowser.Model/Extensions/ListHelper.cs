﻿using System;

namespace MediaBrowser.Model.Extensions
{
    public static class ListHelper
    {
        public static bool ContainsIgnoreCase(string[] list, string value)
        {
            foreach (var item in list)
            {
                if (string.Equals(item, value, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
