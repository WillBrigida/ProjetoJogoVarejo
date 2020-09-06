using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoVarejo_Server.Client.Util
{
    public class AppState
    {
        public string SelectedColour { get; private set; }
        public string SelectFase { get; private set; }

        public event Action OnChange;

        public void SetColour(string colour)
        {
            SelectedColour = colour;
            NotifyStateChanged();
        }
        public void SetFase(string fase)
        {
            SelectFase = fase;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}