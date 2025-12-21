using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsharpLearn.Domain.Components;

namespace CsharpLearn
{
    public interface IUnit
    {
        string GetName();
        Stats GetStats();
    }
}
