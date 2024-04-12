using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class SendGridFunctions
{
    static async Task<SendGridMessage> SendTemplateEmail()
    {
        var templateId = "your_template_id_here";
        var fromEmail = new EmailAddress("sender@example.com", "Sender Name");
        var toEmail = new EmailAddress("recipient@example.com", "Recipient Name");
        var templateData = new
        {
            name = "Name",
            text = "Text",
            id = "123456789"
        };

        // Create SendGrid message
        var message = new SendGridMessage();
        message.SetFrom(fromEmail);
        message.AddTo(toEmail);

        // Set template ID
        message.SetTemplateId(templateId);

        // Set template data
        message.SetTemplateData(templateData);
        return message;
    }

    static async Task<SendGridMessage> SetPersonalization()
    {
        var fromEmail = new EmailAddress("sender@example.com", "Sender Name");
        var toEmail = new EmailAddress("recipient@example.com", "Recipient Name");
        var message = new SendGridMessage();
        message.SetFrom(fromEmail);
        message.AddTo(toEmail);
        var personalizations = new List<Personalization>
        {
            new Personalization
            {
                Tos = new List<EmailAddress>
                {
                    new EmailAddress("recipient1@example.com"),
                    new EmailAddress("recipient2@example.com")
                },

                TemplateData = new Dictionary<string, string>
                {
                    { "name", "Recipient 1" }
                }
            },

            new Personalization
            {
                Tos = new List<EmailAddress>
                {
                    new EmailAddress("recipient3@example.com")

                },
                TemplateData = new Dictionary<string, string>
                {

                    { "name", "Recipient 3" }
                }
            }
}
            };
    message.Personalizations = personalizations;
    return message;
}
