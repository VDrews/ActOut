using System;
using System.Threading.Tasks;
using ActOut.Interfaces;
using Xamarin.Forms;
using SpeechRecognizer = ActOut.UWP.NativeServices.SpeechRecognizer;

[assembly: Dependency(typeof(SpeechRecognizer))]


namespace ActOut.UWP.NativeServices
{
    public class SpeechRecognizer : ISpeechRecognizer
    {
        //Lanza el reconocimiento de voz
        public async Task<string> RecordSpeechFromMicrophoneAsync()
        {
            var speechRecognizer = new Windows.Media.SpeechRecognition.SpeechRecognizer();

            speechRecognizer.Timeouts.InitialSilenceTimeout = TimeSpan.MaxValue;
            speechRecognizer.Timeouts.EndSilenceTimeout = TimeSpan.FromSeconds(1);
            speechRecognizer.UIOptions.AudiblePrompt = "Di aquello que quieres contar";
            speechRecognizer.UIOptions.ExampleText = "El otro dia me paso esta historia...";

            await speechRecognizer.CompileConstraintsAsync();

            // Start recognition.
            var speechRecognitionResult =
                await speechRecognizer.RecognizeWithUIAsync();

            // Do something with the recognition result.
            var result = speechRecognitionResult.Text;

            return result;

        }
    }
}
