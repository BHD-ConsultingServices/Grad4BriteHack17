﻿
namespace Hackathon.Contracts.Initiatives
{
    using System;

    public class Initiative : InitiativeRequest
    {
        public Guid Id { get; set; }

        public decimal Passrate { get; set; }
    }
}
