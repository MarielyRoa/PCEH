using PCEH.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCEH.Application.Repositories
{
    public class ConsumeRepository
    {
        private ConsumeRepository() { }

        public static ConsumeRepository Instance { get; } = new();

        public List<ConsumeDto> Consumos { get; set; } = new();
    }
}
