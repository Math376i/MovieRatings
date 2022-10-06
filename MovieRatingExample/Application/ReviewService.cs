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
        List<int> topRates = new List<int>();
        

        var results = Repository.GetAll().Where(r => r.Grade == 5);
        
        
        var mostCommon = topRates.GroupBy(i => i).OrderByDescending()
        foreach (BEReview n in results)
        {
            
        }

        return ;
    }

    // This method helps getting the most productive reviewers
    public List<int> GetMostProductiveReviewers()
    {
        throw new NotImplementedException();
    }

    // This method helps getting the top rated movies
    public List<int> GetTopRatedMovies(int amount)
    {
        throw new NotImplementedException();
    }

    // This method helps getting the top movie form the reviewer
    public List<int> GetTopMoviesByReviewer(int reviewer)
    {
        throw new NotImplementedException();
    }

    // This method helps getting the reviewers by the movie
    public List<int> GetReviewerByMovie(int movie)
    {
        throw new NotImplementedException();
    }
}