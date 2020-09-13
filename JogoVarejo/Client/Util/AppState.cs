using System;

namespace JogoVarejo.Client.Util
{
    public class AppState
    {
        public string SelectedColour { get; private set; }
        public string SelectFase { get;  set; }

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