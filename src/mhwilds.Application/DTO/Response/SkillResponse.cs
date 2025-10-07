namespace mhwilds.Application.DTO.Response
{
    public record SkillResponse(
        int Id,
        string? Name,
        string? Type,
        string? Description,
        List<SkillRankResponse>? Ranks
    );

    public record SkillRankResponse(
        int Id,
        int Level,
        string? Description,
        int SkillId,
        string? SkillName
    );
}
