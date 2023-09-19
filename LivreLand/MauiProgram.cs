using CommunityToolkit.Maui;
using LivreLand.View;
using LivreLand.ViewModel;
using Microsoft.Extensions.Logging;

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
			.AddSingleton<NavigatorVM>()
			.AddSingleton<BibliothequeView>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
