using CommunityToolkit.Maui;
using LivreLand.View;
using LivreLand.View.ContentViews;
using LivreLand.ViewModel;
using Microsoft.Extensions.Logging;
using Model;
using Stub;
using ViewModels;

namespace LivreLand;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("SF-Compact-Display-Black.otf", "SFCompactDisplayBlack");
				fonts.AddFont("SF-Compact-Display-Bold.otf", "SFCompactDisplayBold");
			});

		builder.Services
			.AddSingleton<BibliothequeView>()
			.AddSingleton<TousView>()
			.AddSingleton<FiltrageAuteurView>()
			.AddSingleton<FiltrageDateView>()
			.AddSingleton<FiltrageNoteView>()
			.AddSingleton<ALirePlusTardView>()
			.AddSingleton<StatutLectureView>()
			.AddSingleton<EmpruntsPretsView>()

            .AddSingleton<NavigatorVM>()

			.AddSingleton<ILibraryManager, LibraryStub>()
			.AddSingleton<IUserLibraryManager, UserLibraryStub>()
			.AddSingleton<Manager>()

			.AddSingleton<ManagerVM>()

			.AddSingleton<BibliothequeVM>()
			.AddSingleton<TousVM>()
            .AddSingleton<FiltrageAuteurVM>()
			.AddSingleton<FiltrageDateVM>()
			.AddSingleton<FiltrageNoteVM>()
			.AddSingleton<ALirePlusTardVM>()
			.AddSingleton<StatutLectureVM>()
			.AddSingleton<EmpruntsPretsVM>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
