﻿using Mapster;
using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;
using mhwilds.Application.Interfaces.Repositories;
using mhwilds.Application.Interfaces.Services;
using mhwilds.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace mhwilds.Application.Services
{
    public class CharmService : ICharmService
    {
        private readonly ICharmRepository _charmRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ILogger<CharmService> _logger;

        public CharmService(
            ICharmRepository charmRepository,
            ISkillRepository skillRepository,
            ILogger<CharmService> logger)
        {
            _charmRepository = charmRepository;
            _skillRepository = skillRepository;
            _logger = logger;
        }

        public async Task<List<GetCharmResponse>> GetAllAsync()
        {
            var charms = await _charmRepository.GetAllAsync();

            if (charms.Count == 0)
            {
                _logger.LogInformation("No charms found in database");
                return [];
            }

            return charms.Adapt<List<GetCharmResponse>>();
        }

        public async Task<GetCharmResponse?> GetByIdAsync(int id)
        {
            var charm = await _charmRepository.GetByIdAsync(id);

            if (charm == null)
            {
                _logger.LogInformation("No charm found in database");
                return null;
            }

            return charm.Adapt<GetCharmResponse>();
        }

        public async Task<GetCharmResponse> CreateAsync(CharmRequest request)
        {
            var charm = request.Adapt<Charm>();

            for (int i = 0; i < charm.Ranks.Count; i++)
            {
                await HandleCharmRankSkillAssignment(
                    charm.Ranks[i],
                    request.Ranks[i].Skills
                );
            }

            var createdCharm = await _charmRepository.CreateAsync(charm);
            _logger.LogInformation("Created new charm with ID: {id}", createdCharm.Id);

            return createdCharm.Adapt<GetCharmResponse>();
        }

        public async Task<List<GetCharmResponse>> CreateRangeAsync(List<CharmRequest> requests)
        {
            var charms = requests.Adapt<List<Charm>>();

            for (int i = 0; i < requests.Count; i++)
            {
                var request = requests[i];
                var charm = charms[i];

                for (int j = 0; j < charm.Ranks.Count; j++)
                {
                    await HandleCharmRankSkillAssignment(
                        charm.Ranks[j], 
                        request.Ranks[j].Skills
                    );
                }
            }

            var createdCharms = await _charmRepository.CreateRangeAsync(charms);
            _logger.LogInformation("Created {Count} new charms", createdCharms.Count);

            return createdCharms.Adapt<List<GetCharmResponse>>();
        }

        public async Task<GetCharmResponse> UpdateAsync(int id, CharmRequest request)
        {
            var existingCharm = await _charmRepository.GetByIdAsync(id);

            if (existingCharm == null)
            {
                throw new InvalidOperationException($"Charm with ID {id} not found");
            }

            var charm = request.Adapt<Charm>();
            charm.Id = id;

            // handle skill assignment for charm ranks
            for (int j = 0; j < charm.Ranks.Count; j++)
            {
                await HandleCharmRankSkillAssignment(
                    charm.Ranks[j], 
                    request.Ranks[j].Skills
                );
            }

            var updatedCharm = await _charmRepository.UpdateAsync(charm);

            _logger.LogInformation("Updated charm with ID {Id}", id);
            return updatedCharm.Adapt<GetCharmResponse>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _charmRepository.DeleteAsync(id);

            if (deleted)
            {
                _logger.LogInformation("Successfully deleted charm with ID {Id}", id);
            }
            else
            {
                _logger.LogInformation("No charm with ID {Id} found for deletion", id);
            }

            return deleted;
        }

        private async Task HandleCharmRankSkillAssignment(CharmRank charmRank, List<GetSkillRankResponse>? skills)
        {
            if (skills?.Count > 0)
            {
                var skillRankIds = skills
                    .Select(sr => sr.Id).ToList();

                var skillRanks = await _skillRepository
                    .GetSkillRanksByIdsAsync(skillRankIds);

                charmRank.Skills = skillRanks;
            }
        }
    }
}
