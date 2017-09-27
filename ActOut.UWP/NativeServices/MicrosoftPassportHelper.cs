using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Security.Credentials;
using Windows.Security.Credentials.UI;
using ActOut.Interfaces;
using ActOut.Models;
using ActOut.UWP.NativeServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(MicrosoftPassportHelper))]


namespace ActOut.UWP.NativeServices
{
    public class MicrosoftPassportHelper : IWindowsHello
    {

        //Crea una clave en el equipo si es la primera vez que se usa Windows Hello
        private static async Task<bool> CreatePassportKeyAsync(string accountId)
        {
            KeyCredentialRetrievalResult keyCreationResult = await KeyCredentialManager.RequestCreateAsync(accountId, KeyCredentialCreationOption.ReplaceExisting);

            switch (keyCreationResult.Status)
            {
                case KeyCredentialStatus.Success:
                    Debug.WriteLine("Successfully made key");

                    return true;
                case KeyCredentialStatus.UserCanceled:
                    Debug.WriteLine("User cancelled sign-in process.");
                    break;
                case KeyCredentialStatus.NotFound:
                    // User needs to setup Microsoft Passport
                    Debug.WriteLine("Microsoft Passport is not setup!\nPlease go to Windows Settings and set up a PIN to use it.");
                    break;
            }

            return false;
        }

        //Accede a Windows Hello, sea la primera vez o no
        public async Task<bool> GetPassportAuthenticationMessageAsync(LastUser account)
        {
            KeyCredentialRetrievalResult openKeyResult = await KeyCredentialManager.OpenAsync(account.Username);
            var consentResult = await Windows.Security.Credentials.UI.UserConsentVerifier.RequestVerificationAsync(account.Username);

            if (consentResult == UserConsentVerificationResult.Verified)
            {
                if (openKeyResult.Status == KeyCredentialStatus.Success)
                {
                    return true;
                }
                else if (openKeyResult.Status == KeyCredentialStatus.NotFound)
                {
                    bool createPassport = await CreatePassportKeyAsync(account.Username);
                    if (createPassport)
                    {
                        return await GetPassportAuthenticationMessageAsync(account);
                    }
                }
            }

            return false;
        }
    }

}