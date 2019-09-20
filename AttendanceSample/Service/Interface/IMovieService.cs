using System;
using System.Collections.Generic;
using System.Text;
using AttendanceSample.Entity;
using AttendanceSample.Service.DTO;

namespace AttendanceSample.Service.Interface
{
    public interface IMovieService
    {
        Movie GetMovieInfo(int id);
        List<Movie> GetAllMovie();
        bool CreateMovie(MovieDto movie);
        bool UpdateMovie(Movie movie);
    }
}
