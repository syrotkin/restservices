using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Common.Model;

namespace Common {
    // TODO-osy: Entity Framework

    public class MovieBusiness {

        public IList<Movie> ListMoviesByNameAndGenre(string title, string genre) {
            var movies = new List<Movie>();
            const string connectionString = "Data Source=PC16375; Initial Catalog=osytest;integrated security=True";
            
            using (DbConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (DbCommand command = connection.CreateCommand()) {
                    
                    command.CommandText = "sp_getMovie";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Title", title == null ? DBNull.Value : (object)title));
                    command.Parameters.Add(new SqlParameter("@Genre", genre == null ? DBNull.Value : (object)genre));
                    using (var dataReader = command.ExecuteReader()) {
                        while (dataReader.Read()) {
                            var movie = new Movie();
                            var idDbValue = dataReader["ID"];
                            var titleDbValue = dataReader["Title"];
                            movie.Id= Convert.ToInt32(idDbValue);
                            movie.Title= titleDbValue is DBNull ? null : (string)titleDbValue;
                            movie.ReleaseDate =  Convert.ToDateTime(dataReader["ReleaseDate"]);
                            movie.Genre = dataReader["Genre"] is DBNull ? null : (string)dataReader["Genre"];
                            movie.Rating = dataReader["Rating"] is DBNull ? (int?)null : Convert.ToInt32(dataReader["Rating"]);
                            movies.Add(movie);
                        }
                    }
                }
            }
            return movies;
        }

    }
}
