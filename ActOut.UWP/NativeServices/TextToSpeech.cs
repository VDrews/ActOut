using System;
using Windows.UI.Xaml.Controls;
using ActOut.Interfaces;
using ActOut.UWP.NativeServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeech))]

namespace ActOut.UWP.NativeServices
{
    public class TextToSpeech : ITextToSpeech
    {
        //Inicia el dictado por Voz
        public async void Speak(string text)
        {
            var mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            var stream = await synth.SynthesizeTextToStreamAsync(text);

            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
    }

}
