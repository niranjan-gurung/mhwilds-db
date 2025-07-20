using Mapster;
using mhwilds.Application.DTO.Request;
using mhwilds.Application.DTO.Response;
using mhwilds.Application.Interfaces.Repositories;
using mhwilds.Application.Interfaces.Services;
using mhwilds.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace mhwilds.Application.Services
{
    public class DecorationService : IDecorationService
    {
        private readonly IDecorationRepository _decorationRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly ILogger<DecorationService> _logger;

        public DecorationService(
            IDecorationRepository decorationRepository,
            ISkillRepository skillRepository,
            ILogger<DecorationService> logger)
        {
            _decorationRepository = decorationRepository;
            _skillRepository = skillRepository;
            _logger = logger;
        }

        public async Task<List<GetDecorationResponse>> GetAllAsync()
        {
            var decorations = await _decorationRepository.GetAllAsync();

            if (decorations.Count == 0)
            {
                _logger.LogInformation("No decorations found in database");
                return [];
            }

            return decorations.Adapt<List<GetDecorationResponse>>();
        }

        public async Task<GetDecorationResponse?> GetByIdAsync(int id)
        {
            var decoration = await _decorationRepository.GetByIdAsync(id);

            if (decoration == null)
            {
                _logger.LogInformation("No decoration found in database");
                return null;
            }

            return decoration.Adapt<GetDecorationResponse>();
        }

        public async Task<GetDecorationResponse> CreateAsync(DecorationRequest request)
        {
            var decoration = request.Adapt<Decoration>();

            await HandleDecorationSkillAssignment(decoration, request);

            var createdDecoration = await _decorationRepository.CreateAsync(decoration);
            _logger.LogInformation("Created new decoration with ID: {id}", createdDecoration.Id);

            return createdDecoration.Adapt<GetDecorationResponse>();
        }

        public async Task<List<GetDecorationResponse>> CreateRangeAsync(List<DecorationRequest> requests)
        {
            var decorations = requests.Adapt<List<Decoration>>();

            for (int i = 0; i < requests.Count; i++)
            {
                var request = requests[i];
                var decoration = decorations[i];

                await HandleDecorationSkillAssignment(decoration, request);
            }

            var createdDecorations = await _decorationRepository.CreateRangeAsync(decorations);
            _logger.LogInformation("Created {Count} new decorations", createdDecorations.Count);

            return createdDecorations.Adapt<List<GetDecorationResponse>>();
        }

        public async Task<GetDecorationResponse> UpdateAsync(int id, DecorationRequest request)
        {
            var existingDecoration = await _decorationRepository.GetByIdAsync(id);

            if (existingDecoration == null)
            {
                throw new InvalidOperationException($"Decoration with ID {id} not found");
            }

            var decoration = request.Adapt<Decoration>();
            decoration.Id = id;

            await HandleDecorationSkillAssignment(decoration, request);

            var updatedDecoration = await _decorationRepository.UpdateAsync(decoration);

            _logger.LogInformation("Updated decoration with ID {Id}", id);
            return updatedDecoration.Adapt<GetDecorationResponse>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _decorationRepository.DeleteAsync(id);

            if (deleted)
            {
                _logger.LogInformation("Successfully deleted decoration with ID {Id}", id);
            }
            else
            {
                _logger.LogInformation("No decoration with ID {Id} found for deletion", id);
            }

            return deleted;
        }

        private async Task HandleDecorationSkillAssignment(Decoration decoration, DecorationRequest request)
        {
            if (request.Skills?.Count > 0)
            {
                var skillRankIds = request.Skills
                    .Select(sr => sr.Id).ToList();

                var skillRanks = await _skillRepository
                    .GetSkillRanksBySkillIdsAsync(skillRankIds);
                decoration.Skills = skillRanks;
            }
        }
    }
}
