using Archable.Application.Helpers;

namespace RCL.Pages
{
    public partial class DeveloperPage
    {
        [Inject] protected Tester Tester { get; init; } = default!;

        protected override void OnAfterRender(bool firstRender)
        {
            if(!firstRender)
                return;

            Tester.Initiate();
        }
    }
}