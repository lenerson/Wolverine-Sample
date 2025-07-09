namespace Wolverine.Message;

public sealed record MessageCreated(Guid Id, string Content, DateTime dateTime);
