using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JalasoftDevLevel1.ItalianRestaurant
{
    [Flags]
    internal enum PaymentMethod
    {
        Cash = 1,
        Card = 2
    }
}
