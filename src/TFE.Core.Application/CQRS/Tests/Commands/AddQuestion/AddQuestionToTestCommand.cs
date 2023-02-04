﻿using TFE.Application.CQRS.Abstractions.Messaging;
using TFE.Domain.Testing.TestAgregate;

namespace TFE.Application.CQRS.Tests.Commands.AddQuestion;

public record AddQuestionToTestCommand(int TestId, string Title, string Body, QuestionType QuestionType) : ICommand<int>;