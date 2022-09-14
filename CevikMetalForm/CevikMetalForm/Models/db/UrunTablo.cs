using System;
using System.Collections.Generic;

#nullable disable

namespace CevikMetalForm.Models.db
{
    public partial class UrunTablo
    {
        public UrunTablo()
        {
            SistemTablos = new HashSet<SistemTablo>();
            StokTablos = new HashSet<StokTablo>();
        }

        public int Id { get; set; }
        public string UrunMarka { get; set; }
        public string UrunAdı { get; set; }
        public decimal? UrunFiyatı { get; set; }
        public string UrunTıpı { get; set; }

        public virtual ICollection<SistemTablo> SistemTablos { get; set; }
        public virtual ICollection<StokTablo> StokTablos { get; set; }
    }
}
