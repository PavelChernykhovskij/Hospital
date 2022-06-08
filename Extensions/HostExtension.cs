using Hospital.Models;
using Hospital.EntityFramework;

namespace Hospital
{
    public static class HostExtension
    {
        public static IHost EnsureDatabaseCreated(this IHost host)
        {
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var context = services.GetService<Context>();
                if (context.Database.EnsureCreated())
                {
                    User user = new() { Email = "email", Key = "key", Login = "admin", Password = "admin", Phone = "1234535", Role = Role.Admin};
                    Medcard medcard = new() { DateOfBirth = DateTime.Now, Medpolis = "medpolis", Name = "Name", Passport = "passport", Snils = "snus", User = user};
                    Doctor doctor = new() { Address = "address", Name = "name", Room = "vroooom", Spec = "spec" };
                    Request request = new() { Comment = "comment", DateOfVisit = DateTime.Now, Medcard = medcard, Doctor = doctor };
                    Questionnaire questionnaire = new() { Doctor = doctor };
                    Question question = new() { Answer = "answer", Text = "text", Questionnaire = questionnaire };
                    context.Users.Add(user);
                    context.Medcards.Add(medcard);
                    context.Doctors.Add(doctor);
                    context.Requests.Add(request);
                    context.Questionnairies.Add(questionnaire);
                    context.Questions.Add(question);
                    context.SaveChanges();
                }
            }
            return host;

        }
    }
}
