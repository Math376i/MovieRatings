using MovieRatingExample.Core.Model;

namespace MovieRatingExample.Core.Repositories;


/// <summary>
/// Interface implementere GetAll fra BEReview
/// </summary>
public interface IReviewRepository
{
    
    BEReview[] GetAll();
}