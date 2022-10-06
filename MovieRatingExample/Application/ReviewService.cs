using MovieRatingExample.Core.Model;
using MovieRatingExample.Core.Repositories;
using MovieRatingExample.Core.Service;

namespace MovieRatingExample.Application;

public class ReviewService : IReviewService
{
    private IReviewRepository Repository;

    // checks if the repository is null or if there is a repository
    public ReviewService(IReviewRepository repository)
    {
        if (repository == null)
        {
            throw new AggregateException("You are missing the repository");
        }

        Repository = repository;
    }
    
    // This method will get a number of the reviews that a Reviewer has made
    public int GetNumberOfReviewsFromReviewer(int reviewer)
    {
        int count = 0;
        foreach (BEReview review in Repository.GetAll())
        {
            if (review.Reviewer == reviewer)
                count++;
        }
        return count;
    }
    
    // This method helps to find the Average rate form the reviewer
    public double GetAverageRateFromReviewer(int reviewer)
    {

        var results = Repository.GetAll().Where(r => r.Reviewer == reviewer).Select(r => r.Grade);

        return results.Average();
    }

    // This method helps to get the number of rates that the reviewer has made.
    public int GetNumberOfRatesByReviewer(int reviewer, int rate)
    {
        
        var results = Repository.GetAll().Where(r => r.Reviewer == reviewer);

        int count = 0;
        foreach (BEReview n in results)
        {
            if (n.Grade == rate)
                count++;
        }
        return count;
    }
    
// This method helps to get the numbers of reviews on a movie
    public int GetNumberOfReviews(int movie)
    {
        var results = Repository.GetAll().Where(r => r.Movie == movie);

        int count = 0;
        foreach (BEReview n in results)
        {
            if (n.Movie == movie)
                count++;
        }

        return count;
    }
    
    // This method helps getting the Average rate in a movie

    public double GetAverageRateOfMovie(int movie)
    {
        var results = Repository.GetAll().Where(r => r.Movie == movie).Select(r => r.Grade);

        return results.Average();
    }
// This method helps getting the number of ratings that a movie have
    public int GetNumberOfRates(int movie, int rate)
    {
        var results = Repository.GetAll().Where(r => r.Movie == movie);

        int count = 0;
        foreach (BEReview n in results)
        {
            if (n.Grade == rate)
                count++;
        }
        return count;
    }
    
    // This method helps getting the movies with the highest number.
    public List<int> GetMoviesWithHighestNumberOfTopRates()
    {
        List<BEReview> allBeReviews = Repository.GetAll().FindAll(b => b.Grade.Equals(5));

        List<int> movieIdList = new List<int>();
        foreach (var review in allBeReviews)
        {
            if (!movieIdList.Contains(review.Movie))
            {
                movieIdList.Add(review.Movie);
            }
        }

        int count = 0;
        int highestMovie = 0;
        List<int> topMovie = new List<int>();

        foreach (var movie in movieIdList)
        {
            count = allBeReviews.FindAll(b => b.Movie.Equals(movie)).Count;

            if (count > highestMovie)
            {
                highestMovie = count;
                topMovie.Clear();
                topMovie.Add(movie);
            }
            else if (count == highestMovie)
            { topMovie.Add(movie); }
        }

        return topMovie;
    }

    // This method helps getting the most productive reviewers
    public List<int> GetMostProductiveReviewers()
    {
        List<BEReview> allBeReviews = Repository.GetAll();

        List<int> reviewerIdList = new List<int>();
        foreach (var review in allBeReviews)
        {
            if (!reviewerIdList.Contains(review.Movie))
            {
                reviewerIdList.Add(review.Movie);
            }
        }

        int count = 0;
        int highestReviewer = 0;
        List<int> topReviewer = new List<int>();

        foreach (var reviewer in reviewerIdList)
        {
            count = allBeReviews.FindAll(r => r.Reviewer.Equals(reviewer)).Count;

            if (count > highestReviewer)
            {
                highestReviewer = count;
                topReviewer.Clear();
                topReviewer.Add(reviewer);
            }
            else if (count == highestReviewer)
            { topReviewer.Add(reviewer); }
        }

        return topReviewer;
    }

    // This method helps getting the top rated movies

    public List<int> GetTopRatedMovies(int amount)
    {
        if (amount < 0) throw new ArgumentException("Amount can't be 0");
        
        var m = Repository.GetAll().Select(r => r.Movie).Distinct();
        
        Dictionary<int, double> movieWithAvgGrade = new Dictionary<int, double>();
        foreach (var movie in m)
        {
            movieWithAvgGrade.Add(movie, GetAverageRateOfMovie(movie));
        }
        
        List<int> movies = new List<int>();
        for (int t = 0; t < amount; t++)
        {
            if (t >= m.Count())
            { break; }

            var maxValue = movieWithAvgGrade.Aggregate((r, v) => r.Value > v.Value ? r : v).Key;
            movieWithAvgGrade.Remove(maxValue);
            movies.Add(maxValue);
        }
        return movies;
    }
    
    // This method helps getting the top movie form the reviewer
    public List<int> GetTopMoviesByReviewer(int reviewer)
    {
        if (reviewer < 0) throw new ArgumentException("Reviewer can't be 0");
        var reviews = Repository.GetAll().Where(r => r.Reviewer == reviewer);
        List<int> result = new List<int>();
        for (int t = 5; t > 0; t--)
        {
            var underList = new List<BEReview>(reviews.Where(a => a.Grade == t));
            underList.Sort((a,b) => a.ReviewDate.CompareTo(b.ReviewDate));
            result.AddRange(underList.Select(r => r.Movie));
        }
        return result;
    }

    // This method helps getting the reviewers by the movie
    public List<int> GetReviewerByMovie(int movie)
    {
        if (movie < 0) throw new ArgumentException("Reviewer can't be 0");
        var reviews = Repository.GetAll().Where(r => r.Movie == movie);
        List<int> result = new List<int>();
        for (int t = 3; t > 0; t--)
        {
            var underList = new List<BEReview>(reviews.Where(a => a.Grade == t));
            underList.Sort((a,b) => a.ReviewDate.CompareTo(b.ReviewDate));
            result.AddRange(underList.Select(r => r.Reviewer));
        }
        return result;
    }
}