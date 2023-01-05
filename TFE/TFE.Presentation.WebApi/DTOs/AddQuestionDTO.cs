using TFE.Domain.Entities;

namespace TFE.WebApi.DTOs;

public record AddQuestionDTO(string Title, string Body, QuestionType Type);