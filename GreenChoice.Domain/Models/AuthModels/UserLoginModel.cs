namespace GreenChoice.Domain.Models.AuthModels;

public partial record UserLoginModel(
        string Username,
        string Password
    );
