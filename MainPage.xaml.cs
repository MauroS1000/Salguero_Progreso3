using Newtonsoft.Json;
using Salguero_Progreso3.Model;

namespace Salguero_Progreso3;


public partial class MainPage : ContentPage
{
    private int posicionRespuestaCorrecta;
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (Connectivity.NetworkAccess == NetworkAccess.Internet)
        {
            using (var client = new HttpClient())
            {
                string url = $"https://opentdb.com/api.php?amount=10";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var rootObject = JsonConvert.DeserializeObject<Rootobject>(json);

                    if (rootObject.response_code == 0 && rootObject.results != null && rootObject.results.Length > 0)
                    {
                        var pregunta = rootObject.results[0];

                        
                        var respuestas = pregunta.incorrect_answers.ToList();
                        respuestas.Add(pregunta.correct_answer);
                        respuestas = respuestas.OrderBy(x => Guid.NewGuid()).ToList();

                        Console.WriteLine(rootObject);
                        questionlabelSalguero.Text = pregunta.question;

                        
                        posicionRespuestaCorrecta = respuestas.IndexOf(pregunta.correct_answer);

                       
                        answer1labelSalguero.Text = respuestas[0];
                        answer2labelSalguero.Text = respuestas[1];
                        answer3labelSalguero.Text = respuestas[2];
                        answer4labelSalguero.Text = respuestas[3];
                    }
                }
            }
        }
    }

    private void CheckAnswer(int selectedAnswer)
    {
        if (posicionRespuestaCorrecta + 1 == selectedAnswer)
        {
            result.Text = "Perfect!";
        }
        else
        {
            result.Text = $"Oops, correct answer was {posicionRespuestaCorrecta + 1}";
        }
    }

    private void Button_Clicked1(object sender, EventArgs e)
    {
        CheckAnswer(1);
    }

    private void Button_Clicked2(object sender, EventArgs e)
    {
        CheckAnswer(2);
    }

    private void Button_Clicked3(object sender, EventArgs e)
    {
        CheckAnswer(3);
    }

    private void Button_Clicked4(object sender, EventArgs e)
    {
        CheckAnswer(4);
    }
}


