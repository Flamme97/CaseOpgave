using CaseOpgave.Operations;
using CaseOpgave.models;

namespace CaseOpgave
{
    public class Program
    {
        static void Main(string[] args)
        {
            // instantiating lists. 
            List<User> userList = new List<User>();
            List<Product> productList = new List<Product>();
            List<CurrentUser> currentUserList = new List<CurrentUser>();
            List<Product> productListSortedbyRating = new List<Product>();

            productListSortedbyRating = CsvHelpers.ParseProduct();
            currentUserList = CsvHelpers.ParseCurrentUser();
            userList = CsvHelpers.ParseUser();
            productList = CsvHelpers.ParseProduct();

            // Sorting and printing highest rated moved. 

            Console.WriteLine("######## Movie Rating ############");
            List<Product> SortedList = productListSortedbyRating.OrderByDescending(o => o.rating).ToList();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(SortedList.ElementAt(i).movieName + " with a rating of " + SortedList.ElementAt(i).rating);
            }
            Console.WriteLine();
            // Looping through sessions data
            foreach (var currentuserItem in currentUserList)
            {
                User tempUser = new User();
                Product tempProduct = new Product();
                List<Product> recommendList = new List<Product>();

                //acquired sessions Product data
                foreach (var productItem in productList)
                {
                    if (currentuserItem.productID == productItem.id)
                    {
                        tempProduct = productItem;
                    }
                }
                // acquried sessons User Data
                foreach (User userItem in userList)
                {
                    if (userItem.id == currentuserItem.userID)
                    {
                        tempUser = userItem;
                    }
                }
                // find Recommended products on keywords
                foreach (var productItem in productList)
                {
                    int counter = 0;
                    foreach (var keyWord in productItem.getKeywordsTolist())
                    {
                        foreach (var currentKeyWord in tempProduct.getKeywordsTolist())
                            if (keyWord == currentKeyWord)
                            {
                                counter++;
                            }
                    }
                    if (counter >= 3)
                    {
                        recommendList.Add(productItem);
                    }
                }
                Console.WriteLine("######## Movie Recommend List ############");
                
                // Sorting and trimming RecommnedList.
                List<Product> SortedRecommendList = recommendList.OrderByDescending(o => o.rating).ToList();
                foreach (Product product in SortedRecommendList)
                {
                    product.movieName = product.movieName.TrimStart();
                    product.movieName = product.movieName.TrimEnd();
                }
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("user with name" + tempUser.name + " Would might be interested in " + SortedRecommendList.ElementAt(i).movieName);
                }
                Console.WriteLine();
            }
        }
    }
}

