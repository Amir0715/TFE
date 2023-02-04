using TFE.Domain.Testing.TestAgregate;

namespace TFE.WebApi.DTOs;

public record AddQuestionDTO(string Title, string Body, QuestionType Type);