using System.Threading.Tasks;

namespace ActOut.Interfaces
{
    //Interface Del Escritor Por Voz
    public interface ISpeechRecognizer
    {
        Task<string> RecordSpeechFromMicrophoneAsync();
    }
}
