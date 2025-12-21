using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Morpion.Domain.Components;

namespace Morpion
{
    public interface IUnit
    {
        string GetName();
        Stats GetStats();
    }
}
