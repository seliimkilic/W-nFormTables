using System;
using System.Collections.Generic;

#nullable disable

namespace CevikMetalForm.Models.db
{
    public partial class SistemTablo
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public int? FirmaId { get; set; }
        public int? StokId { get; set; }
        public int? PersonelId { get; set; }
        public int? SatınAlınanMiktar { get; set; }
        public decimal? OdenenMiktar { get; set; }

        public virtual FirmaTablo Firma { get; set; }
        public virtual PersonelTablo Personel { get; set; }
        public virtual StokTablo Stok { get; set; }
        public virtual UrunTablo Urun { get; set; }
    }
}
