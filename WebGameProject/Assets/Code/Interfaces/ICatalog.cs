using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Interfaces
{
    internal interface ICatalog
    {
        string Title();
        string Description();
        int Price();
        string Image();
        int Place();
        int Health();
        float Power();

        // Коафицент умнажения мошьности при добовлнения еще одного item в одно и тоже место
        float XPover();
    }
}
