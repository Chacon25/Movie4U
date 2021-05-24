using Movie4U.Core.Entities;
using Movie4U.Core.Models;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Infrastructure
{
    public class EmailService
    {
            




        

        public async Task SendEmails(string email , List<Genre> Genres)
        {
       

            string result;
            List<Results> selectionMovies = new List<Results>();
            foreach (var item in Genres)
            {
                using (var request = new HttpClient())
                {
                    result = await request.GetStringAsync($"https://api.themoviedb.org/3/discover/movie?api_key=03fdd8f321f29b9e3f052238c9a26c14&with_genres={item.Id}");
                }
                var movies = JsonConvert.DeserializeObject<Results>(result);
                selectionMovies.Add(movies);
            }

            List<Results> uniqueMovies = selectionMovies.Distinct().ToList();

            string viewMovie = "";
            string vieTitle = "";

            string MainView = "";


            foreach (var item in uniqueMovies)
            {

                viewMovie += "<p style=\"text-align: center; \">";
                vieTitle += "<p style=\"text-align: center; \">";
                foreach (var item2 in item.results.Distinct().ToList().Take(4))
                {
                    viewMovie += "<img src=\"http://image.tmdb.org/t/p/w185/" + item2.poster_path + "\" alt=\"\" />&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; ";
                    vieTitle +=  item2.original_title + "&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;";
                
                }
                viewMovie += "</p>";
                vieTitle += "</p>";

                MainView += viewMovie + vieTitle;

                viewMovie = " ";
                vieTitle = " ";
            }

           
            



            var toAddress = new EmailAddress(email);
            toAddress.Name = "Marco";

            var apiKey = "";
            //Environment.GetEnvironmentVariable("EmailSenderKey");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("marco.fernando.chacon@gmail.com" ,"Marco Chacon");
            var subject = "Your Movie a to recommendo you is ";
            var plainTextContent = $"Your Movie to recommendo you is ...";
            var htmlContent = "<h1 style=\"color: #5e9ca0; text-align: center;\">HERE ARE SOME RECOMMENDATIONS FOR YOU!</h1>" +
                "<p><strong>&nbsp;</strong></p>" 
                + MainView +
                "<p style=\"text-align: center; \"><strong>Thank you for using our website!</strong></p>" +
                "<p style=\"text-align: center; \"><strong>&nbsp;</strong></p>";
            var msg = MailHelper.CreateSingleEmail(from, toAddress, subject,plainTextContent,htmlContent);
           // var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, recipients, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response.Body);
        }
    }
}
