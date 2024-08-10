using POSAppCore;
using System.Globalization;
using System.Threading;
using System.Windows;
using System;
using System.Linq;

namespace POSAppWPF
{
    internal class LocaliazationManager : ILocalizationManager
    {
        public void Manage(string language)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            var newLanguageResource = new ResourceDictionary() { Source = new Uri($"Styles/Languages/Languages-{language}.xaml", UriKind.Relative) };
            var newFontsResource = new ResourceDictionary() { Source = new Uri($"Styles/Fonts/Fonts-{language}.xaml", UriKind.Relative) };
            var newDirectionsResource = new ResourceDictionary() { Source = new Uri($"Styles/Directions/Directions-{language}.xaml", UriKind.Relative) };

            if (language == "en-US")
            {
                var removedLanguageDictionary = Application.Current.Resources.MergedDictionaries.FirstOrDefault(dic => dic.Source.OriginalString.Contains("Languages-ar-EG"));
                Application.Current.Resources.MergedDictionaries.Remove(removedLanguageDictionary);

                var removedFontsDictionary = Application.Current.Resources.MergedDictionaries.FirstOrDefault(dic => dic.Source.OriginalString.Contains("Fonts-ar-EG"));
                Application.Current.Resources.MergedDictionaries.Remove(removedFontsDictionary);

                var removedDirectionsDictionary = Application.Current.Resources.MergedDictionaries.FirstOrDefault(dic => dic.Source.OriginalString.Contains("Fonts-ar-EG"));
                Application.Current.Resources.MergedDictionaries.Remove(removedDirectionsDictionary);

            }
            else if (language == "ar-EG")
            {
                var removedLanguageDictionary = Application.Current.Resources.MergedDictionaries.FirstOrDefault(dic => dic.Source.OriginalString.Contains("Languages-en-US"));
                Application.Current.Resources.MergedDictionaries.Remove(removedLanguageDictionary);

                var removedFontsDictionary = Application.Current.Resources.MergedDictionaries.FirstOrDefault(dic => dic.Source.OriginalString.Contains("Fonts-en-US"));
                Application.Current.Resources.MergedDictionaries.Remove(removedFontsDictionary);

                var removedDirectionsDictionary = Application.Current.Resources.MergedDictionaries.FirstOrDefault(dic => dic.Source.OriginalString.Contains("Fonts-en-US"));
                Application.Current.Resources.MergedDictionaries.Remove(removedDirectionsDictionary);

            }

            Application.Current.Resources.MergedDictionaries.Add(newLanguageResource);
            Application.Current.Resources.MergedDictionaries.Add(newFontsResource);
            Application.Current.Resources.MergedDictionaries.Add(newDirectionsResource);
        }
    }
}
