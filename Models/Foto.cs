using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Tarea1_4.Models
{
    [SQLite.Table("Fotos")]
    public class Foto
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string RutaImagen { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
