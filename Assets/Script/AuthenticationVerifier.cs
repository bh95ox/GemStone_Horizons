using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Core;
using System.Threading.Tasks;
using System.Collections.Generic;
using Unity.Services.CloudSave;

public class AuthenticationVerifier : MonoBehaviour
{

    private async void Start()
    {
        await InitializeUnityServices();
    }

    private async Task InitializeUnityServices()
    {
        try
        {
            // Initialize Unity Services
            await UnityServices.InitializeAsync();
            Debug.Log("Unity Services Initialized");

            // Sign in anonymously
            await SignInAnonymous();
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to initialize Unity Services");
            Debug.LogException(ex);
        }
    }

    async Task SignInAnonymous()
    {
        try
        {
            // Attempt to sign in anonymously
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("Sign in Successful");

            // Get Player ID
            string playerID = AuthenticationService.Instance.PlayerId;
            if (string.IsNullOrEmpty(playerID))
            {
                Debug.LogError("Player ID is null or empty.");
                return;
            }

            // Save Player ID to CloudSave
            var data = new Dictionary<string, object> { { "PlayerID", playerID } };
            await SavePlayerDataToCloud(data);
        }
        catch (AuthenticationException ex)
        {
            Debug.LogError("Authentication failed during sign-in.");
            Debug.LogException(ex);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("An unexpected error occurred during sign-in.");
            Debug.LogException(ex);
        }
    }

    private async Task SavePlayerDataToCloud(Dictionary<string, object> data)
    {
        try
        {
            // Force save the data to the cloud
            await CloudSaveService.Instance.Data.ForceSaveAsync(data);
            Debug.Log("Player data saved to Cloud.");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Failed to save player data to Cloud.");
            Debug.LogException(ex);
        }
    }

}
