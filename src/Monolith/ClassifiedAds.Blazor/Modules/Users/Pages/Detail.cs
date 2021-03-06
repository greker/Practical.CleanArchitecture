﻿using ClassifiedAds.Blazor.Modules.Core.Components;
using ClassifiedAds.Blazor.Modules.Users.Models;
using ClassifiedAds.Blazor.Modules.Users.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace ClassifiedAds.Blazor.Modules.Users.Pages
{
    public partial class Detail
    {
        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public UserService UserService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public UserModel User { get; set; } = new UserModel();

        public ConfirmDialog SendPasswordResetEmailDialog { get; set; }

        public ConfirmDialog SendEmailAddressConfirmationEmailDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
            User = await UserService.GetUserById(Guid.Parse(Id));
        }

        protected async void ConfirmedSendPasswordResetEmail(bool confirmed)
        {
            await UserService.SendPasswordResetEmail(User.Id);
            SendPasswordResetEmailDialog.Close();
        }

        protected async void ConfirmedSendEmailAddressConfirmation(bool confirmed)
        {
            await UserService.SendEmailAddressConfirmationEmail(User.Id);
            SendEmailAddressConfirmationEmailDialog.Close();
        }
    }
}
