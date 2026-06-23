namespace Todo.Core.Endpoints.User.PatchPassword;

public record ChangePasswordRequest(
    string CurrentPassword, string NewPassword);
