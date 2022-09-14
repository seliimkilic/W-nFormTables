using System;
using System.Collections.Generic;

#nullable disable

namespace CevikMetalForm.Models.db
{
    public partial class StokTablo
    {
        public StokTablo()
        {
            SistemTablos = new HashSet<SistemTablo>();
        }

        public int Id { get; set; }
        public int? UrunId { get; set; }
        public int? StokAdeti { get; set; }
        public decimal? StokMaliyeti { get; set; }
        public decimal? StokTutarı { get; set; }

        public virtual UrunTablo Urun { get; set; }
        public virtual ICollection<SistemTablo> SistemTablos { get; set; }
    }
}
