using BeautySalon.Shared.Entities;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;

namespace BeautySalon.Frontend.Pages.Services
{
    public partial class ServicesForm
    {
        private EditContext editContext = null!;

        protected override void OnInitialized()
        {
            editContext = new(Service);
        }

        [EditorRequired, Parameter] public Service Service { get; set; } = null!;
        [EditorRequired, Parameter] public EventCallback OnValidSubmit { get; set; }
        [EditorRequired, Parameter] public EventCallback ReturnAction { get; set; }

        public bool FormPostedSuccessfully { get; set; } = false;

        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        //[Inject] private IStringLocalizer<Literals> Localizer { get; set; } = null!;

        private async Task OnBeforeInternalNavigation(LocationChangingContext context)
        {
            var formWasEdited = editContext.IsModified();

            if (!formWasEdited || FormPostedSuccessfully)
            {
                return;
            }

            var result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmation",
                Text = "LeaveAndLoseChanges",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true
            });

            var confirm = !string.IsNullOrEmpty(result.Value);
            if (confirm)
            {
                return;
            }

            context.PreventNavigation();
        }
    }
}