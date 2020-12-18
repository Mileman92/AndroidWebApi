using System;
using System.Collections.Generic;

namespace AndroidWebApi
{
    public partial class TblPerson
    {
        public int IdPerson { get; set; }
        public string StrPeWinUser { get; set; }
        public string StrPeVorname { get; set; }
        public string StrPeNachname { get; set; }
        public string StrPePosition { get; set; }
        public int? FiPeFirma { get; set; }
        public int? FiPeBetrieb { get; set; }
        public string MemPeNotiz { get; set; }
        public DateTime DtCreated { get; set; }
        public DateTime DtEdited { get; set; }
        public string Creator { get; set; }
        public string Editor { get; set; }
        public string StrPeAccUser { get; set; }
        public string StrPeAccPasswort { get; set; }
    }
}
