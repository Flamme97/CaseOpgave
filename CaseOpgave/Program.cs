using CaseOpgave.Operations;
using CsvHelper.Configuration;
using CaseOpgave.models;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Diagnostics.Metrics;
using System.Reflection;
using System;

namespace CaseOpgave
{

    public class Program
    {
        static void Main(string[] args)
        {   // data indhentning af de forskellige lister fra de forskellige pages.
            List<User> userList = new List<User>();
            List<Product> productList = new List<Product>();
            List<CurrentUser> currentUserList = new List<CurrentUser>();
            List<Product> productListsortedbyrating = new List<Product>();
            // oversættelses til at kunne gøre brug af dem i program.cs
            productListsortedbyrating = CsvHelpers.ParseProduct();
            currentUserList = CsvHelpers.ParseCurrentUser();
            userList = CsvHelpers.ParseUser();
            productList = CsvHelpers.ParseProduct();


            Console.WriteLine("######## Movie Rating ############");
            List<Product> SortedList = productListsortedbyrating.OrderByDescending(o => o.rating).ToList();

            foreach (var item in SortedList)
            {
                Console.WriteLine(item.movieName + " with a rating of " + item.rating);
            }
            foreach (var currentuserItem in currentUserList)
            {
                User tempUser = new User();
                Product tempProduct = new Product();
                List<Product> recommendList = new List<Product>();
                foreach (var productItem in productList)
                {
                    if (currentuserItem.productID == productItem.id)
                    {
                        tempProduct = productItem;
                    }
                }
                foreach (User userItem in userList)
                {
                    if (userItem.id == currentuserItem.userID)
                    {
                        tempUser = userItem;
                    }
                }
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
                Console.WriteLine("######## Movie R ecommend List ############");
                List<Product> SortedRecommendList = recommendList.OrderByDescending(o => o.rating).ToList();
                for (int i = 0; i < 3; i++)
                {        
                    Console.WriteLine("user with name" + tempUser.name + " likes movie with name" + SortedRecommendList.ElementAt(i).movieName);
                }
            }
        }
    }
}

// if (productitem2 == tempProduct.KeywordONE)
//   if (productitem2 == tempProduct.KeywordTWO)
//     if (productitem2 == tempProduct.KeywordTHREE)
//       if (productitem2 == tempProduct.KeywordFOUR)
//         if (productitem2 == tempProduct.KeywordFIVE);

