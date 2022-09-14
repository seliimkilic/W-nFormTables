using System;
using System.Collections.Generic;

#nullable disable

namespace CevikMetalForm.Models.db
{
    public partial class PersonelTablo
    {
        public PersonelTablo()
        {
            SistemTablos = new HashSet<SistemTablo>();
        }

        public int Id { get; set; }
        public string PersonelAdSoyad { get; set; }
        public string Departman { get; set; }

        public virtual ICollection<SistemTablo> SistemTablos { get; set; }
    }
}
