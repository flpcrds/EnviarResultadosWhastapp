using System.IO;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace EnviarResultadosWhatsapp
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                using (StreamReader sr = new StreamReader("C:/dev/numeros.csv"))
                {
                    string line;


                    while ((line = sr.ReadLine()) != null)
                    {
                        var phone = $"+{line}";
                        var file = $"https://sendpdf-3793.twil.io/{line}.pdf";
                        var accountSid = "ACa72c5531381f08c8d757390b7f7ce85a";
                        var authToken = "86256c63c68121ecacc5306a152b3b20";

                        TwilioClient.Init(accountSid, authToken);

                        var mediaUrl = new[] {
                            new Uri(file)
                            }.ToList();

                        var message = MessageResource.Create(
                            mediaUrl: mediaUrl,
                            from: new Twilio.Types.PhoneNumber($"whatsapp:+14155238886"),
                            to: new Twilio.Types.PhoneNumber($"whatsapp:{phone}")
                        );

                    }
                }
            }
            catch (Exception e)
            {

                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            //var messageOptions = new CreateMessageOptions(
            //    new PhoneNumber($"whatsapp:{phone}"));
            //messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
            //messageOptions.Body = $"O caminho do arquivo correspondente e {file}";

            //var message = MessageResource.Create(messageOptions);
            //Console.WriteLine(message.Body);
            }



        }
    } 
















