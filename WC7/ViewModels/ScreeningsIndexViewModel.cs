using System.Collections.Generic;
using WC7.Models;

namespace WC7.ViewModels
{
    public class ScreeningsIndexViewModel
    {
        public ScreeningsIndexViewModel() { }

        public IEnumerable<Screening> Screenings { get; set; }
    }
}
