using BeautySalon.Frontend.Repositories;
using BeautySalon.Shared.Entities;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Net.Security;

namespace BeautySalon.Frontend.Pages.Services
{
    public partial class ServicesCreate
    {
        private ServicesForm? servicesForm;
        private Service? service = new();

        [Inject] private IRepository Repository { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;

        private async Task CreateAsync()
        {
            var httpResponse = await Repository.PostAsync("api/Services", service);
            if (httpResponse.Error)
            {
                var message = await httpResponse.GetErrorMessageAsync();
                await SweetAlertService.FireAsync("Error", message!, SweetAlertIcon.Error);
            }
            Return();
            var toast = SweetAlertService.Mixin(new SweetAlertOptions
            {
                Toast = true,
                Position = SweetAlertPosition.BottomEnd,
                ShowConfirmButton = true,
                Timer = 3000,
            });
            await toast.FireAsync(icon: SweetAlertIcon.Success, message: "Registro guardado con exito");
        }

        private void Return()
        {
            servicesForm!.FormPostedSuccessfully = true;
            NavigationManager.NavigateTo("/services");
        }
    }
}