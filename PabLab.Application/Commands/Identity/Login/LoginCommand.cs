using MediatR;
using ProductsApp.Application.Dtos;

namespace ProductsApp.Application.Commands.Identity.Login;

public class LoginCommand : IRequest<LoginDto>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
