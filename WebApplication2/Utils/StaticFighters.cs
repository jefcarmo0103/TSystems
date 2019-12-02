using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Utils
{
    public class StaticFighters
    {
        private static List<Lutador> _fighters;

        public static void setAllFighters(List<Lutador> fighters)
        {
            _fighters = fighters;
        }

        public static List<Lutador> getAllFighters()
        {
            return _fighters;
        }

    }
}