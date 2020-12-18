using System;
using System.Collections.Generic;

namespace AndroidWebApi
{
    public partial class TblPersonal
    {
        public int Idpersonal { get; set; }
        public byte Iding { get; set; }
        public byte Idemrgrp { get; set; }
        public byte Idbetrieb { get; set; }
        public DateTime DtmCreated { get; set; }
        public string FiFirstUser { get; set; }
        public DateTime DtmUpdated { get; set; }
        public string FiLastUser { get; set; }
    }
}
