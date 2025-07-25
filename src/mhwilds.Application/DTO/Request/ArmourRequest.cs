﻿using mhwilds.Application.DTO.Response;
using System.ComponentModel.DataAnnotations;

namespace mhwilds.Application.DTO.Request
{
    public class ArmourRequest
    {
        public required string Name { get; set; }
        public string? Slug { get; set; }
        public required string Type { get; set; }
        public required string Rank { get; set; }
        [Range(1, 8)]
        public required int Rarity { get; set; }
        public required int Defense { get; set; }
        public required ResistancesRequest Resistances { get; set; }
        public required List<int> Slots { get; set; } = [];
        public required List<GetSkillRankResponse> Skills { get; set; } = [];
    }
}
