using Mhacks.Utils.Enums;
using System;

namespace Mhacks.Models
{
    public class MhackExc : Exception
    {
        public MhackExc(string msg) : base(msg)
        {
        }
        public ErrorStatus Type { get; set; }
    }
}
