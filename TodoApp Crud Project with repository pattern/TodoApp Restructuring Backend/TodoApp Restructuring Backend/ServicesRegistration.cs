using TodoApp_Restructuring_Backend.Repositories.Implementations;
using TodoApp_Restructuring_Backend.Repositories.Interfaces;
using TodoApp_Restructuring_Backend.Services.Implementations;
using TodoApp_Restructuring_Backend.Services.Interfaces;
namespace TodoApp_Restructuring_Backend
{
    public static class ServicesRegistration
    {
        public static void AddInfrastructure (this IServiceCollection services)
        {

            services.AddTransient<IGetAllTodos, GetAllTodo>();
            services.AddTransient<IGetAllTodoService, GetAllTodoService>();

            services.AddTransient<IGetByIdTodos, GetByIdTodos>();
            services.AddTransient<IGetByIdTodoService,GetByIdTodoService>();

            services.AddTransient<IAddTodos, AddTodos>();
            services.AddTransient<IAddTodoService, AddTodoService>();

            services.AddTransient<IDeleteTodos, DeleteTodos>();
            services.AddTransient<IDeleteTodoService, DeleteTodoService>();

            services.AddTransient<IUpdateTodos, UpdateTodos>();
            services.AddTransient<IUpdateTodoService, UpdateTodoService>();

        }
    }
}
