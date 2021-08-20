using changelanguage.Resource;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace changelanguage
{
    class MainPageViewModel
    {
        public class LanguagePair
        {
            public Func<string> name;
            public string value;
        }

        public MainPageViewModel()
        {
            CurrentLanguage = new LocalizedString(() => GetCurrentLanguageName());

            ChangeLanguageCommand = new AsyncCommand(ChangeLanguage);
            languageMapping = new List<LanguagePair>();
            languageMapping.Add(new LanguagePair { name = () => AppResource.English, value = "en" });
            languageMapping.Add(new LanguagePair { name = () => AppResource.Spanish, value = "es" });
        }

        List<LanguagePair> languageMapping { get; }
        public LocalizedString CurrentLanguage { get; }
        public ICommand ChangeLanguageCommand { get; }
        private string GetCurrentLanguageName()
        {
            string name = languageMapping.SingleOrDefault(m => m.value == LocalizationResourceManager.Current.CurrentCulture.TwoLetterISOLanguageName).name.ToString();

            return name != null ? name : LocalizationResourceManager.Current.CurrentCulture.DisplayName;
        }

        async Task ChangeLanguage()
        {
            string selectedName = await Application.Current.MainPage.DisplayActionSheet(
                AppResource.ChangeLanguage,
                null, null,
                languageMapping.Select(m => m.name()).ToArray());
            if (selectedName == null)
            {
                return;
            }

            string selectedValue = languageMapping.Single(m => m.name() == selectedName).value;
            LocalizationResourceManager.Current.CurrentCulture = selectedValue == null ? CultureInfo.CurrentCulture : new CultureInfo(selectedValue);
        }
    }
}
