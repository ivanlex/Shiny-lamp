using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Characters.Abstracts
{
    internal delegate void BehaviorAction();

    internal abstract class Character
    {
        //public abstract IEnumerable<BehaviorAction> Think();
        public double PositionLeft { get; set; }
        public double PositionTop { get; set; }
    }
}
