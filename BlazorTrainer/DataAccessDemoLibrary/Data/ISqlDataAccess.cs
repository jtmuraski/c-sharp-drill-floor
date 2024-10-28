
namespace DataAccessDemoLibrary.Data
{
    //Why turn the SqlDataAcces into an interface, instead of just the class in the main project?
    // When you code against the interface, when you do Unit testing, you can mock the interface and test the code without having to connect to the database
    // Interfaces are also better to use in Dependency Injection, making the code more resilient and easier to change down the road
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connStringName = "Default");
        Task SaveDataAsync(string storedProcedure, object parameters, string connStringName = "Default");
    }
}