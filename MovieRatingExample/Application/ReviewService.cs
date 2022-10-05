using MovieRatingExample.Core.Model;
using MovieRatingExample.Core.Repositories;
using MovieRatingExample.Core.Service;

namespace MovieRatingExample.Application;

public class ReviewService : IReviewService
{
    private IReviewRepository Repository;

    public ReviewService(IReviewRepository repository)
    {
        if (repository == null)
        {
            throw new AggregateException("You are missing the repository");
        }

        Repository = repository;
    }
    
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
    
    public double GetAverageRateFromReviewer(int reviewer)
    {

        var results = Repository.GetAll().Where(r => r.Reviewer == reviewer).Select(r => r.Grade);

        return results.Average();
    }

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

    public double GetAverageRateOfMovie(int movie)
    {
        var results = Repository.GetAll().Where(r => r.Movie == movie).Select(r => r.Grade);

        return results.Average();
    }

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

    public List<int> GetMostProductiveReviewers()
    {
        throw new NotImplementedException();
    }

    public List<int> GetTopRatedMovies(int amount)
    {
        throw new NotImplementedException();
    }

    public List<int> GetTopMoviesByReviewer(int reviewer)
    {
        throw new NotImplementedException();
    }

    public List<int> GetReviewerByMovie(int movie)
    {
        throw new NotImplementedException();
    }
}