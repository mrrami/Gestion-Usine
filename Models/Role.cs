﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionUsine.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string NomRole { get; set; }
        public ICollection<Employe> Employes { get; set; }
    }
}
