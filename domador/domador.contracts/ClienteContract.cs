﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domador.contracts
{
    public class ClienteContract
    {
        public string Id;
        public string Name;
        public List<DiaDeVisitaContract> DiasDeVisita = new List<DiaDeVisitaContract>();
    }
}
