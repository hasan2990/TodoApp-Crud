using CleanCity.Models;
using Dapper;
using TodoApp_Restructuring_Backend.Models.DataSet;

namespace TodoApp_Restructuring_Backend.Repositories.Implementations
{
    public class CleanCityRepository
    {
        private readonly DbContext _dbContext;

        public CleanCityRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Insert
        public async Task<int> AddLocationAsync(LocationEntry location)
        {
            const string query = @"
                INSERT INTO CleanCityLocations
                (Id, OsmId, OsmType, [Class], [Type], Name, DisplayName, Latitude, Longitude,
                 ZoneName, Category, ConditionStatus, Remarks, CreatedBy, CreatedAt, City, State, Country)
                VALUES
                (@Id, @OsmId, @OsmType, @Class, @Type, @Name, @DisplayName, @Latitude, @Longitude,
                 @ZoneName, @Category, @ConditionStatus, @Remarks, @CreatedBy, @CreatedAt, @City, @State, @Country)";

            using var connection = _dbContext.Connection();
            return await connection.ExecuteAsync(query, location);
        }

        // Get All
        public async Task<IEnumerable<LocationEntry>> GetAllLocationsAsync()
        {
            const string query = @"
                SELECT 
                    Id,
                    OsmId,
                    OsmType,
                    [Class],
                    [Type],
                    Name,
                    DisplayName,
                    Latitude,
                    Longitude,
                    ZoneName,
                    Category,
                    ConditionStatus,
                    Remarks,
                    CreatedBy,
                    CreatedAt,
                    UpdatedBy,
                    UpdatedAt,
                    City,
                    State,
                    Country
                FROM CleanCityLocations";

            using var connection = _dbContext.Connection();
            return await connection.QueryAsync<LocationEntry>(query);
        }

        // Get by Id
        public async Task<LocationEntry?> GetLocationByIdAsync(Guid id)
        {
            const string query = @"
                SELECT 
                    Id,
                    OsmId,
                    OsmType,
                    [Class],
                    [Type],
                    Name,
                    DisplayName,
                    Latitude,
                    Longitude,
                    ZoneName,
                    Category,
                    ConditionStatus,
                    Remarks,
                    CreatedBy,
                    CreatedAt,
                    UpdatedBy,
                    UpdatedAt,
                    City,
                    State,
                    Country
                FROM CleanCityLocations
                WHERE Id = @Id";

            using var connection = _dbContext.Connection();
            return await connection.QueryFirstOrDefaultAsync<LocationEntry>(query, new { Id = id });
        }

        // Update
        public async Task<int> UpdateLocationAsync(LocationEntry location)
        {
            const string query = @"
                UPDATE CleanCityLocations
                SET OsmType = @OsmType,
                    [Class] = @Class,
                    [Type] = @Type,
                    Name = @Name,
                    DisplayName = @DisplayName,
                    Latitude = @Latitude,
                    Longitude = @Longitude,
                    ZoneName = @ZoneName,
                    Category = @Category,
                    ConditionStatus = @ConditionStatus,
                    Remarks = @Remarks,
                    UpdatedBy = @UpdatedBy,
                    UpdatedAt = @UpdatedAt,
                    City = @City,
                    State = @State,
                    Country = @Country
                WHERE Id = @Id";

            using var connection = _dbContext.Connection();
            return await connection.ExecuteAsync(query, location);
        }

        // Delete
        public async Task<int> DeleteLocationAsync(Guid id)
        {
            const string query = "DELETE FROM CleanCityLocations WHERE Id = @Id";
            using var connection = _dbContext.Connection();
            return await connection.ExecuteAsync(query, new { Id = id });
        }
    }
}
