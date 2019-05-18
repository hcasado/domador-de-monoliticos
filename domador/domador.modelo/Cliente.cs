using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domador.modelo
{
    public class Cliente
    {
        public int ClienteId;
        public string Nombre;
        public List<DiaDeVisita> DiasDeVisita = new List<DiaDeVisita>();
    }
}
