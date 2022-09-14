using System;
using System.Collections.Generic;

#nullable disable

namespace CevikMetalForm.Models.db
{
    public partial class FirmaTablo
    {
        public FirmaTablo()
        {
            SistemTablos = new HashSet<SistemTablo>();
        }

        public int Id { get; set; }
        public string Musteri { get; set; }

        public virtual ICollection<SistemTablo> SistemTablos { get; set; }
    }
}
